using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportingAssistant.ServiceLayer;
using ReportingAssistant.ViewModel;

namespace ReportingAssistant.Controllers
{
    public class AccountsController : Controller
    {
        IUsersService us;
        public AccountsController(IUsersService us)
        {
            this.us = us;
        }
        public ActionResult Register()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                int LatestUserID = this.us.InserUser(rvm);

                Session["CurrentUserID"] = LatestUserID;
                Session["CurrentUserName"] = rvm.UserName;
                Session["CurrentUserEmail"] = rvm.Email;
                Session["CurrentUserPassword"] = rvm.Password;
                Session["CurrentUserGender"] = rvm.Gender;
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("x", "Invalid");
                return View();
            }
         
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                UserViewModel user = this.us.GetUsersByEmailAndPassword(lvm.Email, lvm.Password);
                if (user != null)
                {

                    Session["CurrentUserID"] = user.UserID;
                    Session["CurrentUserName"] =user.UserName;
                    Session["CurrentUserEmail"] = user.Email;
                    Session["CurrentUserPassword"] = user.PasswordHash;
                    Session["CurrentUserGender"] = user.Gender;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("x", "Invalid Email And Password");
                    return View();
                }
                  
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Email And Password");
                return View();
            }
          
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}