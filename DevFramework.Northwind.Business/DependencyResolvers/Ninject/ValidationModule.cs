using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using Ninject.Modules;

namespace DevFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class ValidationModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidatior>().InSingletonScope();
            Bind<IValidator<Sporcu>>().To<SporcuValidatior>().InSingletonScope();
            Bind<IValidator<SporcuOdemeleri>>().To<SporcuOdemeleriValidatior>().InSingletonScope();
            Bind<IValidator<SporcuKategori>>().To<SporcuKategoriValidatior>().InSingletonScope();
            Bind<IValidator<SporcuFoto>>().To<SporcuFotoValidatior>().InSingletonScope();
            Bind<IValidator<Kusaklar>>().To<KusaklarValidatior>().InSingletonScope();
            Bind<IValidator<KusakOdemeleri>>().To<KusakOdemeleriValidatior>().InSingletonScope();
            Bind<IValidator<TesisFaturam>>().To<TesisFaturamValidatior>().InSingletonScope();
        }
    }
}
