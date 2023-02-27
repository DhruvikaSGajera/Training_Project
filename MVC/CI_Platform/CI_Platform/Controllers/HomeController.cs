using CI_Platform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CI_Platform.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
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
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Registration()
        {
            
                //string strpass = encryptpass(registerUser.Password);
                //CIDbContext _db = new CIDbContext();
                //Models.DataModels.User db = new Models.DataModels.User();

                //if (ModelState.IsValid)
                //{
                //    var userexist = _db.Users.Any(x => x.Email == registerUser.Email);
                //    if (userexist)
                //    {
                //        ModelState.AddModelError("username", "User with this name already exists");
                //        return View(registerUser);
                //    }
                //    else
                //    {
                //        db.Password = strpass;
                //        db.Email = registerUser.Email.ToString();
                //        db.FirstName = registerUser.FirstName.ToString();
                //        db.LastName = registerUser.LastName.ToString();
                //        db.PhoneNumber = registerUser.PhoneNumber;

                //        _db.Users.Add(db);
                //        _db.SaveChanges();
                //        return RedirectToAction("Login");

                //    }


                //}
            return View();
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