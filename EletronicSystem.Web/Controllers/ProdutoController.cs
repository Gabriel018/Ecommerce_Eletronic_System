using EletronicSystem.Business.Services.Interface;
using EletronicSystem.Business.ViewModels;
using EletronicSystem.Domain;
using EletronicSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EletronicSystem.Web.Controllers
{
    public class ProdutoController(IProdutoService produtoService) : Controller
    {
        private readonly IProdutoService _produtoService = produtoService;

        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.ObterTodos();

            if (produtos == null)
            {
                Console.WriteLine("Produto nao encontrado");
            }

            return View(produtos);
        }

        public IActionResult Create()
        {
            ViewData["Categoria"] = Enum.GetValues(typeof(EnumCategoria));

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                byte[] conversaoFoto;

                if(produto.Arquivo != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await produto.Arquivo.CopyToAsync(memoryStream);
                        conversaoFoto = memoryStream.ToArray();
                    }

                    produto.Foto = conversaoFoto;
                }
             

                var resultado = await _produtoService.Adicionar(produto);

                if (resultado.OperacaoValida)
                    TempData["Sucesso"] = "Produto Cadastrado com sucesso";
                else
                    TempData["Erros"] = resultado.MsgErro.FirstOrDefault().Value;

            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var retorno = await _produtoService.ObterPorId(id);

            return View(retorno);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProdutoViewModel produto)
        {
            var response = await _produtoService.Atualizar(produto);

            if (response.OperacaoValida == true)
                TempData["Sucesso"] = "Produto atualizado com sucesso";
            else
                TempData["Erros"] = response.MsgErro.FirstOrDefault().Value;

            return View(produto);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _produtoService.Deletar(id);

            if (response.OperacaoValida == true)
                TempData["Sucesso"] = "Produto excluido com sucesso";
            else
                TempData["Erros"] = response.MsgErro.FirstOrDefault().Value;

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> FiltrarPorCategoria(string categoria)
        {
            var produto = await _produtoService.FiltrarPorCategoria(categoria);

            return View(produto);
        }
    }
}
