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
        public IActionResult Index()
        {
            var produto = _produtoService.ObterTodos();

            if (produto == null)
            {
                Console.WriteLine("Produto nao encontrado");
            }

            return View(produto);
        }
    }
}
