using LivingAssistance2.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LivingAssistance2.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(Login l)
        {
            //if(! string.IsNullOrEmpty(login.Username)&&string.IsNullOrEmpty(login.Password))
            //{

            //}

            ClaimsIdentity identity = null;
            bool isAuthenticate = false;
            if(l.Username == "" && l.Password=="")//get grom Database
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,l.Username),
                    new Claim(ClaimTypes.Role,"Patient")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticate = true;
            }
            if (l.Username == "" && l.Password == "")//get grom Database
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,l.Username),
                    new Claim(ClaimTypes.Role,"CareGiver")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticate = true;
            }
            if (l.Username == "" && l.Password == "")//get grom Database
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,l.Username),
                    new Claim(ClaimTypes.Role,"Employee")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticate = true;
            }
            if (isAuthenticate)
            {
                var principle = new ClaimsPrincipal(identity);
                //var login = HttpContent.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
