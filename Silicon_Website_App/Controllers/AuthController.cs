using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Silicon_Website_App.ViewModels;

namespace Silicon_Website_App.Controllers
{
    public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, ApplicationContext context) : Controller
    {
        private readonly UserManager<UserEntity> _userManager = userManager;
        private readonly SignInManager<UserEntity> _signInManager = signInManager;
        private readonly ApplicationContext _context = context;





        [HttpGet]
        [Route("/signup")]
        public IActionResult SignUp()
        {
            var viewModel = new SignUpViewModel();
            return View(viewModel);
        }


        [Route("/signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(!await _context.Users.AnyAsync(x => x.Email == model.Email))
                {
                    var userEntity = new UserEntity
                    {
                        Email = model.Email,
                        UserName = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName
                    };

                    if ((await _userManager.CreateAsync(userEntity, model.Password)).Succeeded)
                    {
                        if ((await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false)).Succeeded)
                        {
                            return LocalRedirect("/");
                        }
                        else
                        {
                            return LocalRedirect("/signin");
                        }
                    }
                    else
                    {
                        model.ErrorMessage = "Something went wrong, try again later or contact customer service";
                    }
                }
                else
                {
                    model.ErrorMessage = "User with the same email already exists";
                }
            }
            return View(model);
        }




        [HttpGet]
        [Route("/signin")]
        public IActionResult SignIn(string returnUrl)
        {

            ViewData["ReturnUrl"] = returnUrl ?? "/";
            var viewModel = new SignInViewModel();
            return View(viewModel);

        }


        [Route("/signin")]
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model, string returnUrl)
        {
            var signInViewModel = new SignInViewModel();

            if (ModelState.IsValid)
            {

                if ((await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false)).Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }
            }

            ViewData["ReturnUrl"] = returnUrl;
            model.ErrorMessage = "Incorrect email or password";
            return View(model);


        }


        [Route("/signout")]
        public new async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Home", "Default");
        }
    }
}
