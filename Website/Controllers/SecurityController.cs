using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Website.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        MakeupApiContext db = new MakeupApiContext();

        // GET: Security
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var users = db.Users.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
            if (users != null)
            {
                FormsAuthentication.SetAuthCookie(users.Username, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Incorrect username and password!";
                return View(users);

                //}
            }
        }

        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Register(User user)
        {
            using(var context=new MakeupApiContext())
            {
                
                context.Users.Add(user);
                context.SaveChanges();
            }
           return RedirectToAction("Login");
            

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}