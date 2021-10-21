using DevIO.App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace DevIO.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("error/{id:length(3,3)}")]
        public IActionResult Errors(int id)
        {
            var modelError = new ErrorViewModel();

            if (id == 500)
            {
                modelError.Mensagem = "Ocorreu um error! Tente novamente mais tarde ou contate o suporte!";
                modelError.Titulo = "Ocorreu um error";
                modelError.ErrorCode = id;
            }
            else if (id == 404)
            {
                modelError.Mensagem = "A página que está procurando não existe!<br /> Em caso de dúvida entre em contato com o suporte.";
                modelError.Titulo = "Ops! Página não encontrada";
                modelError.ErrorCode = id;
            }
            else if (id == 403)
            {
                modelError.Mensagem = "Usuário sem premissão!";
                modelError.Titulo = "Acesso Negado";
                modelError.ErrorCode = id;
            }
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelError);
        }
    }
}
