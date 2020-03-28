using AutoMapper;
using ReportingAssistant.DomainModel;
using ReportingAssistant.Repository;
using ReportingAssistant.ViewModel;
using System.Collections.Generic;

namespace ReportingAssistant.ServiceLayer
{
    public interface ICategoryService
    {
        void InsertCategory(NewCategoriesViewModel cvm);

        void UpdateCategory(EditCategoryViewModel cvm);

        void DeleteCategory(int CategoryID);

        List<CategoriesViewModel> GetCategory();

        CategoriesViewModel GetCategoryByID(int CategoryID);
    }

    public class CategoryService : ICategoryService
    {
        private ICategoryRepository cr;

        public CategoryService()
        {
            cr = new CategoryRepository();
        }

        public void DeleteCategory(int CategoryID)
        {
            cr.DeleteCategory(CategoryID);
        }

        public List<CategoriesViewModel> GetCategory()
        {
            List<Categories> categories = cr.GetCategory();
            var Config = new MapperConfiguration(cfg => { cfg.CreateMap<Categories, CategoriesViewModel>(); });
            IMapper mapper = Config.CreateMapper();
            List<CategoriesViewModel> cvm = mapper.Map<List<Categories>, List<CategoriesViewModel>>(categories);
            return cvm;
        }

        public CategoriesViewModel GetCategoryByID(int CategoryID)
        {
            Categories categories = cr.GetCategoryByID(CategoryID);
            CategoriesViewModel cvm = null;
            if (categories != null)
            {
                var Config = new MapperConfiguration(cfg => { cfg.CreateMap<Categories, CategoriesViewModel>(); });
                IMapper mapper = Config.CreateMapper();
                cvm = mapper.Map<Categories, CategoriesViewModel>(categories);
                return cvm;
            }
            else
                return cvm;
        }

        public void InsertCategory(NewCategoriesViewModel cvm)
        {
            var Config = new MapperConfiguration(cfg => { cfg.CreateMap<NewCategoriesViewModel, Categories>(); });
            IMapper mapper = Config.CreateMapper();
            Categories categories = mapper.Map<NewCategoriesViewModel, Categories>(cvm);
            cr.InsertCategory(categories);
        }

        public void UpdateCategory(EditCategoryViewModel cvm)
        {
            var Config = new MapperConfiguration(cfg => { cfg.CreateMap<EditCategoryViewModel, Categories>(); });
            IMapper mapper = Config.CreateMapper();
            Categories categories = mapper.Map<EditCategoryViewModel, Categories>(cvm);
            cr.UpdateCategory(categories);
        }
    }
}