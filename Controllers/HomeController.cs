using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vulcan.Models;

namespace Vulcan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Import()
        {
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateForm(IFormFile CsvFile)
        {
            long size = CsvFile.Length;
           
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