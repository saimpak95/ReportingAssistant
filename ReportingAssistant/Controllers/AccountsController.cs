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
       
        public ActionResult Register()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel rvm)
        {

            return View();
        }
    }
}