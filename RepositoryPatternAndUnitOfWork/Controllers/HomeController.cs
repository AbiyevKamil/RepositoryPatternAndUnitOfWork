using Microsoft.AspNetCore.Mvc;
using RepositoryPatternAndUnitOfWork.Core.IConfiguration;
using RepositoryPatternAndUnitOfWork.Entities;
using RepositoryPatternAndUnitOfWork.Models;
using System.Diagnostics;

namespace RepositoryPatternAndUnitOfWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            Note n = new Note()
            {
                Title = "Title",
                Description = $"Description {Guid.NewGuid()}",
            };
            var result = await _unitOfWork.Notes.Add(n);
            await _unitOfWork.CompleteAsync();
            return View();
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