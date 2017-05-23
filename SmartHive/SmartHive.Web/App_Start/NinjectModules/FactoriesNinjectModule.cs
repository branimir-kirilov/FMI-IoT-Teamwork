using Ninject.Extensions.Factory;
using Ninject.Modules;
using SmartHive.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHive.Web.App_Start.NinjectModules
{
    public class FactoriesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            //Models factories
            this.Bind<IUserFactory>().ToFactory().InSingletonScope();
        }
    }
}