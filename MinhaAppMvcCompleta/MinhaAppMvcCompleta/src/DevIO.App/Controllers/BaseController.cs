using DevIO.Business.Interfaces;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.App.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificador _notificador;
        protected BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }
    }
}
