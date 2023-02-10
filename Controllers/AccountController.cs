using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ben_Technical_Test.Models;
using Ben_Technical_Test.ViewModels;

//not used in this format

namespace Ben_Technical_Test.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> _signInManager; // for signing in user
        private UserManager<User> _userManager; //for creating a user
        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        //get
        public IActionResult Login()
        {
            if(this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Login(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {
                var result=await _signInManager.PasswordSignInAsync(loginViewModel.UserName,loginViewModel.Password,loginViewModel.RememberMe, lockoutOnFailure:false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");  //site redirects too when loggedin
                }
            }
            ModelState.AddModelError("", "Failed to login");
            return View();
        }

    }
}
