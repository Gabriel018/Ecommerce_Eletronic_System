using AutoMapper;
using EletronicSystem.Business.Services.Interface;
using EletronicSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EletronicSystem.Web.Controllers
{
    public class HomeController(IProdutoService produtoService) : Controller
    {
        private readonly IProdutoService _produtoService = produtoService;

        public async Task<IActionResult> Index()
        {
            var obter = await _produtoService.ObterTodos();

            return View(obter);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
