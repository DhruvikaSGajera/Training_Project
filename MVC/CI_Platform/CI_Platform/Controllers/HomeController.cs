using CI_Platform.Controllers;
using CI_Platform.Entities.ViewModels;
using CI_Platform.Models;
using CI_Platform.Repository.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace CI_Platform.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILogin _objILogin;
        private readonly IUserInterface _objUserInterface;

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
                var listofuser = _objILogin.getUsers();
                int validate = _objILogin.validateUser(objlogin);
                if (validate != 0)
                {
                    return RedirectToAction("LandingPage");
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid credentials");
                    return View(objlogin);
                }
            }
            //else
            //{
            //    return View();
            //}
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel objFpvm)
        {
            if (ModelState.IsValid)
            {
                var Email = objFpvm.Email;

                var token = Guid.NewGuid().ToString();
                bool usercheck = _objUserInterface.ValideUserEmail(objFpvm, token);
                if (usercheck)
                {

                    // Send an email with the password reset link to the user's email address
                    var resetLink = Url.Action("ResetPassword", "Home", new { email = Email, token }, Request.Scheme);
                    // Send email to user with reset password link
                   
                    var fromAddress = new MailAddress("gajeravirajpareshbhai@gmail.com", "Sender Name");
                    var toAddress = new MailAddress(objFpvm.Email);
                    var subject = "Password reset request";
                    var body = $"Hi,<br /><br />Please click on the following link to reset your password:<br /><br /><a href='{resetLink}'>{resetLink}</a>";
                    var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true
                    };
                    var smtpClient = new SmtpClient("smtp.gmail.com", 587)
                    {
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential("dhruvikagajera@gmail.com", "kdgoqmqtotntuvvu"),
                        EnableSsl = true
                    };
                    smtpClient.Send(message);
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("Email", "User doesn't Exists");
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
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ResetPassword(ResetPasswordViewModel resetvm)
        {
            bool success = _objUserInterface.ResetPassword(resetvm.Email, resetvm.Token);
            if (success)
            {
                bool update = _objUserInterface.UpdatePassword(resetvm);
                ViewBag.Message = "Successfully Changed Password !!";
            }
            else
            {
                ViewBag.Message = "Something went Wrong!";
            }
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string email, string token)
        {
            var model = new ResetPasswordViewModel
            {
                Email = email,
                Token = token,

            };
            return View(model);
        }

        public IActionResult Registration()
        {        
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationViewModel objredistervm)
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
                    ModelState.AddModelError("Email", "User with this E-mail already Exsits");
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