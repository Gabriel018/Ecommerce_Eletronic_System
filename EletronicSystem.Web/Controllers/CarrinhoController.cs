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

            await cacheRepository.SetCacheValueAsync(clienteNome,produto);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> VisualizarCarrinho(string clienteNome)
        {
            var produtoCarrinho = await cacheRepository.GetCacheValueAsync<ProdutoViewModel>(clienteNome);

            return View(produtoCarrinho);
        }
    }
}
