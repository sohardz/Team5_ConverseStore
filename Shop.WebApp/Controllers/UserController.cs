using Microsoft.AspNetCore.Mvc;

namespace Shop.WebApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
