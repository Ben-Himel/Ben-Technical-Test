using Ben_Technical_Test.Helper;
using Ben_Technical_Test.Models;
using Ben_Technical_Test.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Net;

namespace Ben_Technical_Test.Controllers
{
    public class HomeController : Controller
    {
        private ArrayAuthentication _arrayAuthentication;

        private readonly ILogger<HomeController> _logger;

        public string userNamedisplay()
        {
            return _arrayAuthentication.UserFullName;
        }

        public HomeController(ArrayAuthentication arrayAuthentication, ILogger<HomeController> logger)
        {
            _arrayAuthentication = arrayAuthentication;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();

        }

        [HttpPost]
        public  IActionResult Login(LoginViewModel loginViewModel)
        {
            var result = _arrayAuthentication.Authenticate(loginViewModel.UserName, loginViewModel.Password, CSVReader.ReadCSVRaw("wwwroot//Credentials//logindata.csv"));
            if (result)
            {
                return RedirectToAction("Index", "Home");  //site redirects too when loggedin
            }
            ModelState.AddModelError("", "Failed to login");
            return View();
            
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}