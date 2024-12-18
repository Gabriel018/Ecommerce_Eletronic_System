using AutoMapper;
using EletronicSystem.Business.Services.Interface;
using EletronicSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EletronicSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;


        public HomeController(ILogger<HomeController> logger,IProdutoService produtoService,IMapper mapper)
        {
            _logger = logger;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var obter = await _produtoService.ObterTodos();

            return View(obter);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
