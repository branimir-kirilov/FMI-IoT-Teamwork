using Ninject.Modules;
using SmartHive.Authentication.Providers;

namespace SmartHive.Web.App_Start.NinjectModules
{
    public class AuthenticationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IAuthenticationProvider>().To<HttpContextAuthenticationProvider>();
        }
    }
}