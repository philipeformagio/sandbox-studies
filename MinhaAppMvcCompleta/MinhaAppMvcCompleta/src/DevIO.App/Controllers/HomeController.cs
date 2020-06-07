using DevIO.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Errors(int id)
        {
            var modelError = new ErrorViewModel();

            if (id == 500)
            {
                modelError.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
                modelError.Titulo = "Ocorreu um erro!";
                modelError.ErrorCode = id;
            }
            else if (id == 404)
            {
                modelError.Mensagem = "A página que está procurando não existe! <br> Em caso de dúvidas entre em contato com nosso suporte";
                modelError.Titulo = "Ops! Página não encontrada.";
                modelError.ErrorCode = id;
            }
            else if(id == 403)
            {
                modelError.Mensagem = "Você não tem premissão para fazer isto.";
                modelError.Titulo = "Acesso Negado";
                modelError.ErrorCode = id;
            }
            else
            {
                return StatusCode(500);
            }

            return View("Error", modelError);
        }
    }
}
