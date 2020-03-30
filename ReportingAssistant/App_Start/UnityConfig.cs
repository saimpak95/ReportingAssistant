using System.Web.Http;
using Unity;
using Unity.WebApi;
using Unity.Mvc5;
using ReportingAssistant.ServiceLayer;
using System.Web.Mvc;

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
            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}