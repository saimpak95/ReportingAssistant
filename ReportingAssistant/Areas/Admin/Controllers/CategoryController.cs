using ReportingAssistant.ServiceLayer;
using ReportingAssistant.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ReportingAssistant.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService cs;

        public CategoryController(ICategoryService cs)
        {
            this.cs = cs;
        }

        public ActionResult Index()
        {
            List<CategoriesViewModel> cvm = cs.GetCategory();
            return View(cvm);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewCategoriesViewModel ncvm)
        {
            if (ModelState.IsValid)
            {
                this.cs.InsertCategory(ncvm);
            }
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        public ActionResult Edit(int ID)
        {
            CategoriesViewModel cvm = this.cs.GetCategoryByID(ID);
            return View(cvm);
        }

        [HttpPost]
        public ActionResult Edit(EditCategoryViewModel ecvm)
        {
            this.cs.UpdateCategory(ecvm);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        public ActionResult Delete(int ID)
        {
            CategoriesViewModel cvm = this.cs.GetCategoryByID(ID);
            return View(cvm);
        }

        [HttpPost]
        public ActionResult Delete(int ID, CategoriesViewModel csm)
        {
            this.cs.DeleteCategory(ID);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        public ActionResult Detail(int ID)
        {
            CategoriesViewModel cvm = this.cs.GetCategoryByID(ID);
            return View(cvm);
        }
    }
}