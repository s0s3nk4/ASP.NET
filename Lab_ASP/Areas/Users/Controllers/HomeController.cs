using Microsoft.AspNetCore.Mvc;

namespace Lab_ASP.Areas.Users.Controllers
{
    [Area("Users")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
