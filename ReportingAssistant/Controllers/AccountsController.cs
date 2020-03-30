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
                Session["CurrentUserIsAdmin"] = false;
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("x", "Invalid");
                return View();
            }
         
        }
    }
}