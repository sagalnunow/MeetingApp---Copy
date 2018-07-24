using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MeetingApp.DAL;

namespace MeetingApp.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Employee employee)
        {
            if (Membership.ValidateUser(employee.Email, employee.Password))
            {
                FormsAuthentication.SetAuthCookie(employee.Email, false);
                return RedirectToAction("Index", "Home");
            }

            TempData["Msg"] = "Login Failed, please try again";
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}