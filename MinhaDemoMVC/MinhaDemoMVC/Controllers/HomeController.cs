using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinhaDemoMVC.Models;

namespace MinhaDemoMVC.Controllers
{
    [Route("")]
    [Route("gestao-clientes")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("pagina-inicial")]
        [Route("pagina-inicial/{id:int}/{categoria:guid}")]
        public IActionResult Index(string id, Guid categoria)
        {
            var filme = new Filme()
            {
                Titulo = "Oi",
                DataLacamento = DateTime.Now,
                Genero = null,
                Avaliacao = 10,
                Valor = 20000
            };
            return RedirectToAction("Privacy", filme);
            //return View();
        }

        [Route("privacidade")]
        [Route("politica-de-privacidade")]
        public IActionResult Privacy(Filme filme)
        {
            //return Json("{'nome':'Eduardo'}");

            //var fileBytes = System.IO.File.ReadAllBytes(@"C:\Users\phili\Desktop\ASPNET-CORE.txt");
            //var fileName = "arquivo.txt";
            //return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

            //return Content("Qualquer coisa");

            if (ModelState.IsValid)
            {

            }

            foreach (var error in ModelState.Values.SelectMany(x => x.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("erro-encontrado")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
