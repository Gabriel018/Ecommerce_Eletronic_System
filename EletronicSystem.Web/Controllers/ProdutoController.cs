using EletronicSystem.Business.Services.Interface;
using EletronicSystem.Business.ViewModels;
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


        [HttpPost]
        public async Task<IActionResult> Create(ProdutoViewModel produto)
        {
          if(ModelState.IsValid)
            {
                var resultado = await _produtoService.Adicionar(produto);

                if(resultado.OperacaoValida)
                {
                    TempData["Sucesso"] = "Produto Cadastrado com sucesso";
                }
                else
                {
                    TempData["Erros"] = resultado.MsgErro.FirstOrDefault().Value;
                }
            }
          return View(produto);
        }
    }
}
