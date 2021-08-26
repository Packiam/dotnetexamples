using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Autofac;
using Autofac.Integration.Mvc;
using MVC.Samples.Web.Areas.Guru;
using MVC.Samples.Web.Areas.Ravi;

namespace MVC.Samples.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Autofac Registration Process
            RegisterServices();
        }




        private void RegisterServices()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterType<RegistrationService>().As(typeof(IRegistration)).InstancePerRequest();
            GuruDataManager.AddDepandancies(builder);
            RaviDataManager.AddDepandancies(builder);

            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
