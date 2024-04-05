using Microsoft.AspNetCore.Mvc;

namespace Silicon_Website_App.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
