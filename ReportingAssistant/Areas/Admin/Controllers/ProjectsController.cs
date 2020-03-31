using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportingAssistant.ServiceLayer;
using ReportingAssistant.DomainModel;
using ReportingAssistant.ViewModel;

namespace ReportingAssistant.Areas.Admin.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Admin/Projects
        ICategoryService cs;
        ReportingAssistantDBContext db;
        IProjectService ps;
        public ProjectsController(ICategoryService cs,IProjectService ps)
        {
            this.cs = cs;
            this.ps = ps;
            db = new ReportingAssistantDBContext();
        }
        public ActionResult Index()
        {
            List<ProjectViewModel> pvm = this.ps.GetProject();
            return View(pvm);
        }

        public ActionResult Create()
        {
            ViewBag.Categories = db.categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(NewProjectViewModel npvm)
        {
            npvm.AdminID = Convert.ToInt32(Session["CurrentUserID"]);
            npvm.DateOfStart = DateTime.Now;
            if(ModelState.IsValid)
            {
                if (npvm.Attachments != null)
                {
                    if (Request.Files.Count >= 1)
                    {
                        var File = Request.Files[0];
                        var ImgByte = new Byte[File.ContentLength - 1];
                        File.InputStream.Read(ImgByte, 0, ImgByte.Length);
                        var Base64String = Convert.ToBase64String(ImgByte, 0, ImgByte.Length);
                        npvm.Attachments = Base64String;
                    }
                }
                this.ps.InsertProject(npvm);
               return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else
            {
                ViewBag.Categories = db.categories.ToList();
                ModelState.AddModelError("X", "Invalid");
                return View();
            }
            
        }
    }
}