using Autofac;
using MVC.Samples.BLL.Interfaces.Guru;
using MVC.Samples.BLL.Services.Guru;


namespace MVC.Samples.Web.Areas.Guru
{
    public static class GuruDataManager
    {
        public static void AddDepandancies(ContainerBuilder builder)
        {
            builder.RegisterType<RegistrationService>().As(typeof(IRegistration)).InstancePerRequest();
        }
    }
}