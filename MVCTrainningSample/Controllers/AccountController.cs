using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.ComponentModel.DataAnnotations;
using MVCTrainningSample.DAL.Security;
using MVCTrainningSample.DAL;
using MVCTrainningSample.Models;
using Newtonsoft.Json;
using System.Web.Security;

namespace MVCTrainningSample.Controllers
{
    public class AccountController : Controller
    {
        TestAppDbContext db = null;
        public AccountController()
        {
            db = new TestAppDbContext();
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Where(u => u.Username == model.Username && u.Password == model.Password).FirstOrDefault();
                if (user != null)
                {
                    var roles = user.Roles.Select(m => m.RoleName).ToArray();

                    CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                    serializeModel.UserId = user.UserId;
                    serializeModel.FirstName = user.FirstName;
                    serializeModel.LastName = user.LastName;
                    serializeModel.roles = roles;

                    string userData = JsonConvert.SerializeObject(serializeModel);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                             1,
                             user.Email,
                             DateTime.Now,
                             DateTime.Now.AddMinutes(15),
                             false,
                             userData);

                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);
                    
                    if (roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (roles.Contains("User"))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("AccessDenied", "Error");
                    }
                }

                ModelState.AddModelError("", "Incorrect username and/or password");
            }

            return View(model);
        }

        public ActionResult UserProfile()
        {
            var userProfile = db.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault(); 
            return View("UserProfile", userProfile);
        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }

    }
}
