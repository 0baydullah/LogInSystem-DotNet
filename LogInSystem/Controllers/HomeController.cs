using LogInSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LogInSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext context;

        public HomeController(MyDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserTbl user)
        {
            var myUser = context.UserTbls.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            if(myUser != null)
            {
                HttpContext.Session.SetString("UserSession",myUser.Email);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Message = "Login Failed...!!";
            }
            return View();
        }

        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login");
            }
            return View();
        }




        public IActionResult Privacy()
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
