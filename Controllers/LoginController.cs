using LivingAssistance2.Models;
using LivingAssistance2.Security;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LivingAssistance2.Controllers
{
    public class LoginController : Controller
    {
	    private readonly ORGContext _context;

        //constructor
        public LoginController (ORGContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Log in page
        [HttpGet]
        public IActionResult LogInPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogInPage(Login L)
        {
            bool userexists = CheckExitingUser(L);
            if (userexists)
            {
                return View("Index","Home");
            }
            else
            {
                return RedirectToAction("LogInPage");
            }
        }


        private bool CheckExitingUser(Login L)
        {
            try
            {
                //Get Salt Key From Database
                var getUser = (from s in _context.UserDetails where s.Username == L.Username select s).FirstOrDefault();

            if (getUser != null)
            {
                //Encrypt Password according to Salt Key
                var encodedPasswordString = Encrypt.EncodePassword(L.Password, getUser.Saltvalue);
                //Check Login Detail User Name Or Password    
                var query = (from s in _context.UserDetails where (s.Username == L.Username) && s.Password.Equals(encodedPasswordString) select s).FirstOrDefault();
                if (query != null)
                {
                        //User Exist
                       // Authorization(L,query.UserTypeId);    //Authorize 
                    return true;
                }
                return false;
            }
            else
            {
                    //Wrong User Id or Password
                    return false;
            }
            }
            catch (Exception e)
            {
                return false;
            }
        }


        private void Authorization(Login l, string Usertype)
        {
            
            ClaimsIdentity identity = null;
            bool isAuthenticate = false;
            //For Patient
            if (Usertype.Contains("P"))
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,l.Username),
                    new Claim(ClaimTypes.Role,"Patient")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticate = true;
            }
            //For Care Giver
            if (Usertype.Contains("C"))
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,l.Username),
                    new Claim(ClaimTypes.Role,"CareGiver")
                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticate = true;
            }
            //For Employee
            if (Usertype.Contains("E"))
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
                //var login = HttpContent.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme);
               
            }
        }
        
    }
}
