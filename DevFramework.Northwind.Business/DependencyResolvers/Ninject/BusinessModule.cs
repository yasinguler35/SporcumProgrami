﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAccess;
using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Core.DataAccess.NHihabernate;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.Concrete.Managers;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using DevFramework.Northwind.DataAccess.Concrete.NHibernate;
using DevFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using Ninject.Modules;

namespace DevFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>();
            Bind<IUserDal>().To<EfUserDal>();

            Bind<ISporcuService>().To<SporcuManager>();
            Bind<ISporcuDal>().To<EfSporcuDal>();

            Bind<ISporcuFotoService>().To<SporcuFotoManager>();
            Bind<ISporcuFotoDal>().To<EfSporcuFotoDal>();

            Bind<ISporcuKategoriService>().To<SporcuKategoriManager>();
            Bind<ISporcuKategoriDal>().To<EfSporcuKategoriDal>();
            //Sporcu Ödemleri 
            Bind<ISporcuOdemeleriService>().To<SporcuOdemeleriManager>();
            Bind<ISporcuOdemeleriDal>().To<EfSporcuOdemeleriDal>();

            Bind<IKusaklarService>().To<KusaklarManager>();
            Bind<IKusaklarDal>().To<EfKusaklarDal>();

            Bind<IKusakOdemeleriService>().To<KusakOdemeleriManager>();
            Bind<IKusakOdemeleriDal>().To<EfKusakOdemeleriDal>();

            Bind<ITesisFaturamService>().To<TesisFaturamManager>();
            Bind<ITesisFaturamDal>().To<EfTesisFaturamDal>();

            Bind<IFaturaTurleriService>().To<FaturaTurleriManager>();
            Bind<IFaturaTurleriDal>().To<EfFaturaTurleriDal>();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
