using Autofac;
using MVC.Samples.BLL.Interfaces.Ravi;
using MVC.Samples.BLL.Services.Ravi;

namespace MVC.Samples.Web.Areas.Ravi
{
    public static class RaviDataManager
    {
        public static void AddDepandancies(ContainerBuilder builder)
        {
            builder.RegisterType<RegistrationService>().As(typeof(IRegistration)).InstancePerRequest();
        }
    }
}