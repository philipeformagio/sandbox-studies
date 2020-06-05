using AutoMapper;
using DevIO.App.ViewModels;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.App.Controllers
{
    public class FornecedoresController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IFornecedorService _fornecedorService;

        public FornecedoresController(IMapper mapper,
                                      IFornecedorRepository fornecedorRepository, 
                                      IFornecedorService fornecedorService,                                      
                                      INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _fornecedorRepository = fornecedorRepository;
            _fornecedorService = fornecedorService;
        }


        [Route("lista-de-fornecedores")]
        public async Task<IActionResult> Index()
        {
            var fornecedoresViewModel = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return View(fornecedoresViewModel);
        }

        [Route("dados-do-fornecedor/{id:guid}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var fornecedorViewModel = await this.ObterFornecedorEndereco(id.Value);
            if (fornecedorViewModel == null)
            {
                return NotFound();
            }

            return View(fornecedorViewModel);
        }

        [Route("novo-fornecedor")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-fornecedor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid) return View(fornecedorViewModel);

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            await _fornecedorService.Adicionar(fornecedor);
            if (!OperacaoValida()) return View(fornecedorViewModel);

            return RedirectToAction(nameof(Index));
        }

        [Route("editar-fornecedor/{id:guid}")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var fornecedorViewModel = await this.ObterFornecedorProdutosEndereco(id.Value);
            if (fornecedorViewModel == null)
                return NotFound();

            return View(fornecedorViewModel);
        }

        [Route("editar-fornecedor/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(fornecedorViewModel);

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            await _fornecedorService.Atualizar(fornecedor);
            if (!OperacaoValida()) return View(await ObterFornecedorProdutosEndereco(id));

            return RedirectToAction(nameof(Index));
        }

        [Route("excluir-fornecedor/{id:guid}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var fornecedorViewModel = await this.ObterFornecedorEndereco(id.Value);
            if (fornecedorViewModel == null) return NotFound();

            return View(fornecedorViewModel);
        }

        [Route("excluir-fornecedor/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorEndereco(id);

            if (fornecedorViewModel == null) return NotFound();

            await _fornecedorService.Remover(id);
            if (!OperacaoValida()) return View(fornecedorViewModel);

            return RedirectToAction(nameof(Index));
        }

        [Route("obter-endereco-fornecedor/{id:guid}")]
        public async Task<IActionResult> ObterEndereco(Guid id)
        {
            var fornecedor = await ObterFornecedorEndereco(id);

            if (fornecedor == null) return NotFound();

            return PartialView("_DetalhesEndereco", fornecedor);
        }

        [Route("atualizar-endereco-fornecedor/{id:guid}")]
        public async Task<IActionResult> AtualizarEndereco(Guid id)
        {
            var fornecedor = await ObterFornecedorEndereco(id);

            if (fornecedor == null) return NotFound();

            return PartialView("_AtualizarEndereco", new FornecedorViewModel { Endereco = fornecedor.Endereco });
        }

        [Route("atualizar-endereco-fornecedor/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtualizarEndereco(FornecedorViewModel fornecedorViewModel)
        {
            ModelState.Remove("Nome");
            ModelState.Remove("Documento");

            if (!ModelState.IsValid) return PartialView("_AtualizarEndereco", fornecedorViewModel);

            var endereco = _mapper.Map<Endereco>(fornecedorViewModel.Endereco);
            await _fornecedorService.AtualizarEndereco(endereco);
            if (!OperacaoValida()) return PartialView("AtualizarEndereco", fornecedorViewModel);

            var url = Url.Action("ObterEndereco", "Fornecedores", new { id = fornecedorViewModel.Endereco.FornecedorId });

            return Json(new { success = true, url });
        }


        #region .: Private Methods :.
        private async Task<FornecedorViewModel> ObterFornecedorEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorEndereco(id));
        }

        private async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
        }
        #endregion
    }
}
