using CI_Platform.Controllers;
using CI_Platform.Entities.ViewModels;
using CI_Platform.Models;
using CI_Platform.Repository.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CI_Platform.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly ILogin _objILogin;
        private readonly IUserInterface _objUserInterface;
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(ILogger<HomeController> logger, ILogin objLogin, IUserInterface objUserInterface)
        {
            _logger = logger;
            _objILogin = objLogin;
            _objUserInterface = objUserInterface;
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
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel objlogin)
        {
            if (ModelState.IsValid)
            {
                var listofuser = _objILogin.GetUsers();
                int validate = _objILogin.validateUser(objlogin);
                if (validate != 0)
                {
                    return RedirectToAction("LandingPage");
                }
                else
                {
                    ModelState.AddModelError("Email", "Your credentials are wrong");
                    return View(objlogin);
                }
            }
            else
            {
                return View();
            }
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPaasword(ForgotPasswordViewModel objFpvm)
        {
            if (ModelState.IsValid)
            {
                bool usercheck = _objUserInterface.ValideUserEmail(objFpvm);
                if (usercheck)
                {

                    return RedirectToAction("ResetPassword");
                }
                else
                {
                    ModelState.AddModelError("Email", "User don't Exists");
                    return View(objFpvm);
                }
            }
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResetPAssword(ResetPAsswordViewModel objresetuser)
        {
            bool success = _objUserInterface.ResetPassword(objresetuser);
            if (success)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
            return View();
        }

        public IActionResult Registration()
        {        
            return View();
        }

        [HttpPost]
        public IActionResult registration(RegistrationViewModel objredistervm)
        {
            if (ModelState.IsValid)
            {
                bool addUser = _objUserInterface.AddUser(objredistervm);
                if (addUser)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("Email", "User with this E-mail Exsits");
                    return View(objredistervm);
                }
            }
            return View(objredistervm);
        }

        public IActionResult LandingPage()
        {
            return View();
        }

        public IActionResult NoMissionFound()
        {
            return View();
        }

		public IActionResult VolunteeringMissionPage()
		{
			return View();
		}

		public IActionResult StoryListingPage()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}