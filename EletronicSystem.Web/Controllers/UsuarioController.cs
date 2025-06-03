using EletronicSystem.Business.Services.Interface;
using EletronicSystem.Business.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EletronicSystem.Web.Controllers
{
    public class UsuarioController(IUsuarioService usuarioService) : Controller
    {
        private readonly IUsuarioService _usuarioService = usuarioService;

        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioService.ObterTodos();

            return View(usuarios);
        }

        public IActionResult Create()
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

        #pragma warning disable S6967
        public async Task<ActionResult> Update(Guid id)
        {
            var usuario = await _usuarioService.ObterPorId(id);

            if (usuario != null) // NOSONAR

            {
                return Ok(usuario);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult> Update([FromForm] UsuarioViewModel usuario)
        {
            var response = await _usuarioService.Atualizar(usuario);

            if (!response.Succeeded)
            {
                TempData["Error"] = response.Errors.FirstOrDefault();
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<ActionResult> Delete(Guid id)
        {
            var response = await _usuarioService.Deletar(id);

            if (response.MsgErro.Values != null)
                TempData["Error"] = response.MsgErro.FirstOrDefault().Value;            else
                TempData["Sucesso"] = "Excluido com sucesso";

            return RedirectToAction(nameof(Index));
        }
    }
}
