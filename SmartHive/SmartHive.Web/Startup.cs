using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartHive.Web.Startup))]
namespace SmartHive.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
