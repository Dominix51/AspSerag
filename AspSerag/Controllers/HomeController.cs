using AspSerag.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspSerag.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Kontakt()
        {
            return View();
        }
        public IActionResult Pojisteni()
        {
            return View();
        }

        public IActionResult Prihlaseni()
        {
            return View();
        }

        public IActionResult Udalosti()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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