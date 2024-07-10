using Microsoft.AspNetCore.Mvc;

namespace ExMVC_01.Presentation.Controllers
{
    public class HomeController : Controller
    {
        //Método necessário para abrir a página Index deste controlador:
        public IActionResult Index()
        {
            return View();
        }
    }
}
