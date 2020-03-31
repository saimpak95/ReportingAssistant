using ReportingAssistant.ServiceLayer;
using System.Web.Http;
using System.Web.Mvc;
using Unity;

namespace ReportingAssistant
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IUsersService, UsersService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IProjectService, ProjectService>();

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}