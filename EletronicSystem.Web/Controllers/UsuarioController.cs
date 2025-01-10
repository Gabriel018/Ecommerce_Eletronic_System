using EletronicSystem.Business.Services.Interface;
using EletronicSystem.Business.ViewModels;
using EletronicSystem.Domain.Entities;
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

        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioService.ObterTodos();

            return View(usuarios);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioViewModel usuario)
        {

            if (ModelState.IsValid)
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


        public async Task<IActionResult> Update(Guid id)
        {
            var usuario = await _usuarioService.ObterPorId(id);

            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UsuarioViewModel usuario)
        {
            var response = await _usuarioService.Atualizar(usuario);

            if (response.MsgErro.Values != null)
            {
                TempData["Error"] = response.MsgErro.FirstOrDefault().Value;
            }

            return RedirectToAction(nameof(Index));
        }

      
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _usuarioService.Deletar(id);

            if (response.MsgErro.Values != null)
            {
                TempData["Error"] = response.MsgErro.FirstOrDefault().Value;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
