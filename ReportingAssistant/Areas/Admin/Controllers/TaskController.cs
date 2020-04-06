using ReportingAssistant.DomainModel;
using ReportingAssistant.ServiceLayer;
using ReportingAssistant.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReportingAssistant.Areas.Admin.Controllers
{
    public class TaskController : Controller
    {
        ITaskService ts;
        ReportingAssistantDBContext db;
        public TaskController(ITaskService ts)
        {
            this.ts = ts;
            db = new ReportingAssistantDBContext();
        }
        public ActionResult Index()
        {
            List<TaskViewModel> tvm = this.ts.GetTasks();
            return View(tvm);
        }

        public ActionResult Create()
        {
            int SessionID = Convert.ToInt32(Session["CurrentUserID"]);
            List<Projects> projects = db.projects.Where(temp => temp.AdminID == SessionID).ToList();
            List<Users> users = db.users.Where(temp=>temp.Role!="Admin").ToList();
            ViewBag.Projects = projects;
            ViewBag.User = users;
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewTaskViewModel ntvm)
        {
            ntvm.AdminID = Convert.ToInt32(Session["CurrentUserID"]);
            ntvm.DateOfTask = DateTime.Now;
            if (ModelState.IsValid)
            {
                 if (Request.Files.Count >= 1)
                    {
                        var File = Request.Files[0];
                        var ImgByte = new Byte[File.ContentLength - 1];
                        File.InputStream.Read(ImgByte, 0, ImgByte.Length);
                        var Base64String = Convert.ToBase64String(ImgByte, 0, ImgByte.Length);
                    ntvm.Attachments = Base64String;
                    }
              
                this.ts.InsertTask(ntvm);
            }
            else
            {
                int SessionID = Convert.ToInt32(Session["CurrentUserID"]);
                ModelState.AddModelError("x", "Invalid");
                List<Projects> projects = db.projects.Where(temp => temp.AdminID == SessionID).ToList();
                List<Users> users = db.users.Where(temp => temp.Role != "Admin").ToList();
                ViewBag.Projects = projects;
                ViewBag.User = users;
                return View();
            }
            return RedirectToAction("Index", "Task", new { area = "Admin" });
            
        }

        public ActionResult Edit(int ID)
        {
            TaskViewModel tvm = this.ts.GetTasksByID(ID);
            List<Projects> projects = db.projects.ToList();
            List<Users> users = db.users.Where(temp => temp.Role != "Admin").ToList();
            ViewBag.Projects = projects;
            ViewBag.User = users;
            return View(tvm);
        }

        [HttpPost]
        public ActionResult Edit(EditTaskViewModel tvm)
        {
            tvm.AdminID = Convert.ToInt32(Session["CurrentUserID"]);
            tvm.DateOfTask = DateTime.Now;
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var File = Request.Files[0];
                    var ImgByte = new Byte[File.ContentLength - 1];
                    File.InputStream.Read(ImgByte, 0, ImgByte.Length);
                    var Base64String = Convert.ToBase64String(ImgByte, 0, ImgByte.Length);
                    tvm.Attachments = Base64String;
                }

                this.ts.UpdateTask(tvm);
            }
            else
            {
                int SessionID = Convert.ToInt32(Session["CurrentUserID"]);
                ModelState.AddModelError("x", "Invalid");
                List<Projects> projects = db.projects.Where(temp => temp.AdminID == SessionID).ToList();
                List<Users> users = db.users.Where(temp => temp.Role != "Admin").ToList();
                ViewBag.Projects = projects;
                ViewBag.User = users;
                return View();
            }
            return RedirectToAction("Index", "Task", new { area = "Admin" });
        }

        public ActionResult Delete(int ID)
        {
            TaskViewModel tvm = this.ts.GetTasksByID(ID);
            return View(tvm);
        }

        [HttpPost]
        public ActionResult Delete(int ID,TaskViewModel tvm)
        {
            this.ts.DeleteTask(ID);
            return RedirectToAction("Index", "Task", new { area = "Admin" });
        }

        public ActionResult Detail(int ID)
        {
            TaskViewModel tvm = this.ts.GetTasksByID(ID);
            return View(tvm);
        }
    }
}