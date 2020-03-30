using ReportingAssistant.ServiceLayer;
using ReportingAssistant.ViewModel;
using System;
using System.Web.Mvc;

namespace ReportingAssistant.Controllers
{
    public class AccountsController : Controller
    {
        private IUsersService us;

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
                Session["CurrentUserPhone"] = rvm.Phone;
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
                    Session["CurrentUserName"] = user.UserName;
                    Session["CurrentUserEmail"] = user.Email;
                    Session["CurrentUserPhone"] = user.Phone;
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

        public ActionResult ChangeProfile()
        {
            int UserID = Convert.ToInt32(Session["CurrentUserID"]);
            UserViewModel user = this.us.GetUsersByUserID(UserID);
            EditUserProfileViewModel eupm = new EditUserProfileViewModel { Email = user.Email, UserName = user.UserName, Phone = user.Phone, Gender = user.Gender, UserID = user.UserID };
            return View(eupm);
        }

        [HttpPost]
        public ActionResult ChangeProfile(EditUserProfileViewModel euvm)
        {
            this.us.UpdateUserDetails(euvm);
            Session["CurrentUserName"] = euvm.UserName;
            Session["CurrentUserPhone"] = euvm.Phone;
            Session["CurrentUserGender"] = euvm.Gender;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangePassword()
        {
            int UserID = Convert.ToInt32(Session["CurrentUserID"]);
            UserViewModel user = this.us.GetUsersByUserID(UserID);
            EditUserPasswordViewModel eupm = new EditUserPasswordViewModel { UserID = user.UserID };
            return View(eupm);
        }

        [HttpPost]
        public ActionResult ChangePassword(EditUserPasswordViewModel eupvm)
        {
            if (ModelState.IsValid)
            {
                this.us.UpdateUserPassword(eupvm);
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