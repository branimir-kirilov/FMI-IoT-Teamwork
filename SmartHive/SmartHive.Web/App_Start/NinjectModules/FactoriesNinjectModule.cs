using Ninject.Extensions.Factory;
using Ninject.Modules;
using SmartHive.Factories;

namespace SmartHive.Web.App_Start.NinjectModules
{
    public class FactoriesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            //Models factories
            this.Bind<IUserFactory>().ToFactory().InSingletonScope();
            this.Bind<IHiveFactory>().ToFactory().InSingletonScope();
        }
    }
}