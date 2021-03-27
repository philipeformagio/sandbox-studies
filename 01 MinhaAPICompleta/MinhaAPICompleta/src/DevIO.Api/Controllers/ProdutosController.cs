using AutoMapper;
using DevIO.Api.Extensions;
using DevIO.Api.ViewModels;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DevIO.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProdutosController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IProdutoService _produtoService;
        private readonly IProdutoRepository _produtoRepository;
        public ProdutosController(IMapper mapper,
                                  IUser user,
                                  INotificador notificador,
                                  IProdutoRepository produtoRepository,
                                  IProdutoService produtoService) : base(user, notificador)
        {
            _mapper = mapper;
            _produtoService = produtoService;
            _produtoRepository = produtoRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            var produtoViewModel = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosFornecedores());
            return produtoViewModel;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> ObterPorId(Guid id)
        {
            var produtoViewModel = await this.ObterProdutoPorId(id);
            if (produtoViewModel == null) return NotFound();
            return produtoViewModel;
        }

        [ClaimsAuthorize("Produto", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var imagemNome = Guid.NewGuid() + "_" + produtoViewModel.Imagem;
            if (!this.UploadArquivo(produtoViewModel.ImagemUpload, imagemNome)) return CustomResponse(produtoViewModel);

            produtoViewModel.Imagem = imagemNome;
            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            return CustomResponse(produtoViewModel);
        }

        [ClaimsAuthorize("Produto", "Adicionar")]
        [HttpPost("adicionar-alternativo")]
        public async Task<ActionResult<ProdutoViewModel>> AdicionarAlternativo(ProdutoImagemViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await this.UploadArquivoAlternativo(produtoViewModel.ImagemUpload, imgPrefixo)) return CustomResponse(produtoViewModel);

            produtoViewModel.Imagem = imgPrefixo + produtoViewModel.ImagemUpload.FileName;
            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            return CustomResponse(produtoViewModel);
        }

        [RequestSizeLimit(400000000)]
        [ClaimsAuthorize("Produto", "Adicionar")]
        [HttpPost("adicionar-imagem")]
        public ActionResult AdicionarImagem(IFormFile file)
        {
            return Ok(file);
        }

        [ClaimsAuthorize("Produto", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Atualizar(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais.");
                return CustomResponse();
            }

            var produtoAtualizacao = await this.ObterProdutoPorId(id);
            produtoViewModel.Imagem = produtoAtualizacao.Imagem;
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (produtoViewModel.ImagemUpload != null)
            {
                var imagemNome = Guid.NewGuid() + "_" + produtoViewModel.Imagem;
                if (!UploadArquivo(produtoViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(ModelState);
                }
                produtoAtualizacao.Imagem = imagemNome;
            }

            produtoAtualizacao.Nome = produtoViewModel.Nome;
            produtoAtualizacao.Descricao = produtoViewModel.Descricao;
            produtoAtualizacao.Valor = produtoViewModel.Valor;
            produtoAtualizacao.Ativo = produtoViewModel.Ativo;
            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoAtualizacao));
            return CustomResponse(produtoViewModel);
        }

        [ClaimsAuthorize("Produto", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id)
        {
            var produtoViewModel = await this.ObterProdutoPorId(id);
            if (produtoViewModel == null) return NotFound();

            await _produtoService.Remover(id);
            return CustomResponse(produtoViewModel);
        }


        #region .: Private Methods :.
        private async Task<ProdutoViewModel> ObterProdutoPorId(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoFornecedore(id));
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça uma imagem para esse produto!");
                return false;
            }
            var imageDataByteArray = Convert.FromBase64String(arquivo);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/app/demo-webapi/src/assets", imgNome);
            if (System.IO.File.Exists(filePath))
            {
                NotificarErro("Já existe um arquivo com esse nome");
                return false;
            }
            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);
            return true;
        }

        private async Task<bool> UploadArquivoAlternativo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo == null || arquivo.Length == 0)
            {
                NotificarErro("Forneça uma imagem para esse produto!");
                return false;
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/app/demo-webapi/src/assets", imgPrefixo + arquivo.FileName);
            if (System.IO.File.Exists(path))
            {
                NotificarErro("Já existe um arquivo com esse nome");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }
        #endregion
    }
}
