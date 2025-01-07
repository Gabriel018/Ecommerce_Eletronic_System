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

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioViewModel usuario )
        {

            if(ModelState.IsValid)
            {
                var resultado = await _usuarioService.Criar(usuario);

                if (resultado.Succeeded)
                {
                    TempData["Sucesso"] = "Cadastrado com sucesso";
                }
                else
                {
                    TempData["Erros"] = resultado.Errors.FirstOrDefault()?.Description;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }


        public async Task<IActionResult> Update()
        {
            return View();
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var usuario = await _usuarioService.ObterPorId(id);

            if (usuario == null)
            {
                Console.WriteLine("Usuario ausente");
                return View(nameof(Update));
            }
            else
            {
                await _usuarioService.Atualizar(usuario);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
