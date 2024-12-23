using Microsoft.AspNetCore.Mvc;

namespace EletronicSystem.Web.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CriarUsuario()
        {
            return View();
        }
    }
}
