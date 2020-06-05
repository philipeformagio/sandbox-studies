using AutoMapper;
using DevIO.App.ViewModels;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DevIO.App.Controllers
{
    public class ProdutosController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IFornecedorRepository _fornecedorRepository;

        public ProdutosController(IMapper mapper,
                                  IProdutoRepository produtoRepository,
                                  IProdutoService produtoService,
                                  IFornecedorRepository fornecedorRepository,
                                  INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _fornecedorRepository = fornecedorRepository;
        }

        
        [Route("lista-de-produtos")]
        public async Task<IActionResult> Index()
        {
            var produtoViewModel = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterProdutosFornecedores());
            return View(produtoViewModel);
        }

        [Route("dados-do-produto/{id:guid}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var produtoViewModel = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id.Value));

            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        [Route("novo-produto")]
        public async Task<IActionResult> Create()
        {
            var produtoViewModel = await PopularFornecedores(new ProdutoViewModel());

            return View(produtoViewModel);
        }

        [Route("novo-produto")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            produtoViewModel = await PopularFornecedores(produtoViewModel);

            if (!ModelState.IsValid) return View(produtoViewModel);

            var imgPrefixo = Guid.NewGuid() + "_";
            if(! await this.UploadArquivo(produtoViewModel.ImagemUpload, imgPrefixo))
            {
                return View(produtoViewModel);
            }

            produtoViewModel.Imagem = imgPrefixo + produtoViewModel.ImagemUpload.FileName;
            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));
            if (!OperacaoValida()) return View(produtoViewModel);

            return RedirectToAction(nameof(Index));
        }

        [Route("editar-produto/{id:guid}")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var produtoViewModel = await this.ObterProduto(id.Value);

            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        [Route("editar-produto/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return NotFound();

            var produtoAtualizacao = await this.ObterProduto(id);

            produtoViewModel.Fornecedor = produtoAtualizacao.Fornecedor;
            produtoViewModel.Imagem = produtoAtualizacao.Imagem;
            if (!ModelState.IsValid) return View(produtoViewModel);

            if (produtoViewModel.ImagemUpload != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";
                if (!await this.UploadArquivo(produtoViewModel.ImagemUpload, imgPrefixo))
                {
                    return View(produtoViewModel);
                }

                produtoAtualizacao.Imagem = imgPrefixo + produtoViewModel.ImagemUpload.FileName;
            }

            produtoAtualizacao.Nome = produtoViewModel.Nome;
            produtoAtualizacao.Descricao = produtoViewModel.Descricao;
            produtoAtualizacao.Valor = produtoViewModel.Valor;
            produtoAtualizacao.Ativo = produtoViewModel.Ativo;

            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoAtualizacao));
            if (!OperacaoValida()) return View(produtoViewModel);

            return RedirectToAction(nameof(Index));
        }

        [Route("excluir-produto/{id:guid}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var produtoViewModel = await this.ObterProduto(id.Value);
            
            if (produtoViewModel == null) return NotFound();

            return View(produtoViewModel);
        }

        [Route("excluir-produto/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null) return NotFound();

            await _produtoService.Remover(id);
            if (!OperacaoValida()) return View(produtoViewModel);

            return RedirectToAction(nameof(Index));
        }


        #region .: Private Methods :.
        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            var produto = await _produtoRepository.ObterProdutoFornecedor(id);

            var produtoViewModel = _mapper.Map<ProdutoViewModel>(produto);
            produtoViewModel.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());

            return produtoViewModel;
        }

        private async Task<ProdutoViewModel> PopularFornecedores(ProdutoViewModel produtoViewModel)
        {
            produtoViewModel.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());

            return produtoViewModel;
        }

        private async Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imgPrefixo + arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com esse nome!");
                return false;
            }

            using(var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }
        #endregion
    }
}
