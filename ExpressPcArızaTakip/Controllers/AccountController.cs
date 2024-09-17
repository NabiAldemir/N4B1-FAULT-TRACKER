using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpressPcArızaTakip.Models;
using ExpressPcArızaTakip.Controllers;
using System.Data.SqlClient;
using System.Web.Security;
using ExpressPcArızaTakip.Models.Entity;

namespace ExpressPcArızaTakip.Controllers
{

    public class AccountController : Controller
    {
        expresspcEntities db = new expresspcEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verify(string Name, string Password)
        {
            var user = db.User.FirstOrDefault(u => u.UserName == Name && u.Password == Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                Session["UserName"] = user.UserName;
                Session["Roles"] = user.Role.Roles;
                Session["UserId"] = user.Id;
                Session["Users"]=user.Users;
                return RedirectToAction("Index", "Admin");
            }
            TempData["ErrorMessage"] = "Invalid username or password";
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}