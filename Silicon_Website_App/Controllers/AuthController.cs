using Microsoft.AspNetCore.Mvc;
using Silicon_Website_App.ViewModels;

namespace Silicon_Website_App.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        [Route("/signup")]
        public IActionResult SignUp()
        {
            var viewModel = new SignUpViewModel();
            return View(viewModel);
        }


        [Route("/signup")]
        [HttpPost]
        public IActionResult SignUp(SignUpViewModel model)
        {
            var viewModel = new SignUpViewModel();
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            return RedirectToAction("SignIn", "Auth");
        }
    }
}
