using Ninject.Modules;
using SmartHive.Providers;
using SmartHive.Providers.Contracts;

namespace SmartHive.Web.App_Start.NinjectModules
{
    public class ProvidersNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IHttpContextProvider>().To<HttpContextProvider>();
            this.Bind<IDateTimeProvider>().To<DateTimeProvider>();
        }
    }
}