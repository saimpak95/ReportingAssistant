using ReportingAssistant.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace ReportingAssistant.Repository
{
    public interface ICategoryRepository
    {
        void InsertCategory(Categories categories);

        void UpdateCategory(Categories categories);

        void DeleteCategory(int CategoryID);

        List<Categories> GetCategory();

        Categories GetCategoryByID(int CategoryID);
    }

    public class CategoryRepository : ICategoryRepository
    {
        private ReportingAssistantDBContext db;

        public CategoryRepository()
        {
            db = new ReportingAssistantDBContext();
        }

        public void DeleteCategory(int CategoryID)
        {
            Categories categories = db.categories.Where(temp => temp.CategoryID == CategoryID).FirstOrDefault();
            db.categories.Remove(categories);
            db.SaveChanges();
        }

        public void InsertCategory(Categories categories)
        {
            db.categories.Add(categories);
            db.SaveChanges();
        }

        public void UpdateCategory(Categories categories)
        {
            Categories ExistingCategory = db.categories.Where(temp => temp.CategoryID == categories.CategoryID).FirstOrDefault();
            ExistingCategory.CategoryName = categories.CategoryName;
            db.SaveChanges();
        }

        public List<Categories> GetCategory()
        {
            List<Categories> categories = db.categories.OrderBy(temp => temp.CategoryID).ToList();
            return categories;
        }

        public Categories GetCategoryByID(int CategoryID)
        {
            Categories categories = db.categories.Where(temp => temp.CategoryID == CategoryID).FirstOrDefault();
            return categories;
        }
    }
}