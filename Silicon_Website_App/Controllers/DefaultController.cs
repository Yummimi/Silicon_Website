using Microsoft.AspNetCore.Mvc;

namespace Silicon_Website_App.Controllers
{
    public class DefaultController : Controller
    {

        public IActionResult Home()
        {
            return View();
        }
    }
}
