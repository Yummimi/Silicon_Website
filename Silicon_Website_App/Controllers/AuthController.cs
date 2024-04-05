using Microsoft.AspNetCore.Mvc;

namespace Silicon_Website_App.Controllers
{
    public class AuthController : Controller
    {
        [Route("/signup")]
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
