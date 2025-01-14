using EletronicSystem.Business.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EletronicSystem.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        public async Task<IActionResult> Index()
        {
            var produto = await _produtoService.ObterTodos();

            if (produto == null)
            {
                Console.WriteLine("Produto nao encontrado");
            }

            return View(produto);
        }

        public IActionResult Create() { 


            return View();
        }
    }
}
