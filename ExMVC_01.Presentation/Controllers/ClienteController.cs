using ExMVC_01.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExMVC_01.Presentation.Controllers
{
    public class ClienteController : Controller
    {
        
        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Consulta()
        {
            return View();
        }
    }
}
