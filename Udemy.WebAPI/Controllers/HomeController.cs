using Microsoft.AspNetCore.Mvc;

namespace Udemy.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
