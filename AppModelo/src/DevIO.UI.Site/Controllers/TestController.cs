using DevIO.UI.Site.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DevIO.UI.Site.Controllers
{
    public class TestController : Controller
    {
        public OperacaoService _operacaoService { get; }
        public OperacaoService _operacaoService2 { get; }

        public TestController(OperacaoService operacaoService, OperacaoService operacaoService2)
        {
            this._operacaoService = operacaoService;
            this._operacaoService2 = operacaoService2;
        }

        public string Index()
        {
            return
                "Primeira instância: " + Environment.NewLine +
                _operacaoService.Transient.OperacaoId + Environment.NewLine +
                _operacaoService.Scoped.OperacaoId + Environment.NewLine +
                _operacaoService.Singleton.OperacaoId + Environment.NewLine +
                _operacaoService.SingletonInstance.OperacaoId + Environment.NewLine +

                Environment.NewLine +
                Environment.NewLine +

                "Segunda instância: " + Environment.NewLine +
                _operacaoService2.Transient.OperacaoId + Environment.NewLine +
                _operacaoService2.Scoped.OperacaoId + Environment.NewLine +
                _operacaoService2.Singleton.OperacaoId + Environment.NewLine +
                _operacaoService2.SingletonInstance.OperacaoId + Environment.NewLine;
        }
    }
}