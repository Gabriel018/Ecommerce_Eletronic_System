using EletronicSystem.Business.Services.Interface;
using EletronicSystem.Business.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EletronicSystem.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
          _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CriarUsuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoUsuario(UsuarioViewModel usuario )
        {
            try
            {
             await _usuarioService.Criar(usuario);
                if(usuario.OperacaoValida == true)
                {
                    TempData["Msg"] = "Cadastro efetuado!";
                }
                else
                {
                    TempData["Msg"] = "Erro ao finalizar o cadastro";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return RedirectToAction("CriarUsuario");
        }
    }
}
