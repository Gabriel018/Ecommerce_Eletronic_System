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

        public async Task< IActionResult> Index()
        {
            var usuarios = await _usuarioService.ObterTodos();

            return View(usuarios);
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

              var resultado = await _usuarioService.Criar(usuario);

                if(resultado.Succeeded)
                {
                    TempData["Sucesso"] = "Cadastrado com sucesso";
                }
                else
                {
                    TempData["Erros"] = resultado.Errors.FirstOrDefault()?.Description; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return RedirectToAction("CriarUsuario","Usuario");
        }
    }
}
