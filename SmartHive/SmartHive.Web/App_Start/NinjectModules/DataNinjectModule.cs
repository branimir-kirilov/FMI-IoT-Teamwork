using Ninject.Modules;
using Ninject.Web.Common;
using SmartHive.Data;
using SmartHive.Data.Contracts;

namespace SmartHive.Web.App_Start.NinjectModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ISmartHiveEntities>().To<SmartHiveEntities>().InRequestScope();
            this.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            this.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
        }
    }
}