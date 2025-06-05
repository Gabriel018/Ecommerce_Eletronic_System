using EletronicSystem.Business.Services.Interface;
using EletronicSystem.Business.ViewModels;
using EletronicSystem.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EletronicSystem.Web.Controllers
{
    public class CarrinhoController(IProdutoService produtoService, ICacheRepository cacheRepository) : Controller
    {
#pragma warning disable S6967
        public async Task<IActionResult> AdicionarItemAlista(Guid produtoId, string clienteNome)
        {
            var produto = await produtoService.ObterPorId(produtoId);

            var lista = await cacheRepository.GetCacheValueAsync<List<ProdutoViewModel>>(clienteNome) ?? [];

            lista.Add(produto);

            var resultado = cacheRepository.SetCacheValueAsync(clienteNome, lista);

            if (resultado.IsCompleted)
            {
                TempData["Sucesso"] = "Produto adicionado com sucesso!!";
            }
            else
            {
                TempData["Erros"] = "Produto nao foi adicionado ao carrinho";
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> VisualizarCarrinho(string clienteNome)
        {
            var produtoCarrinho = await cacheRepository.GetCacheValueAsync<List<ProdutoViewModel>>(clienteNome);

            return View(produtoCarrinho);
        }

        public async Task<IActionResult> ExcluirItemCarrinho(Guid produtoId, string clienteNome)
        {
            var lista = await cacheRepository.GetCacheValueAsync<List<ProdutoViewModel>>(clienteNome) ?? [];

            var itemRemovido = lista.FirstOrDefault(x => x.Id == produtoId)!;

            lista.Remove(itemRemovido);

            var resultado =  cacheRepository.SetCacheValueAsync(clienteNome, lista);

            if (resultado.IsCompleted)
            {
                TempData["Sucesso"] = "Produto exluido com sucesso!!";
            }
            else
            {
                TempData["Erros"] = "Produto nao foi excluido do carrinho";
            }

            return RedirectToAction("VisualizarCarrinho", "Carrinho", new { clienteNome });
        }
    }
}
