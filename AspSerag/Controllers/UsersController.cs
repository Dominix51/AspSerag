using Microsoft.AspNetCore.Mvc;

namespace AspSerag.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
