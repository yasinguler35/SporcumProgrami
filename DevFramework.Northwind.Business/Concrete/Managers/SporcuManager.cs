using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Core.Aspects.Postsharp;
using DevFramework.Core.Aspects.Postsharp.AuthorizationAspects;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.Aspects.Postsharp.LogAspects;
using DevFramework.Core.Aspects.Postsharp.PerformanceAspects;
using DevFramework.Core.Aspects.Postsharp.TransactionAspects;
using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using DevFramework.Core.DataAccess;
using DevFramework.Core.Utilities.Mappings;
using PostSharp.Aspects.Dependencies;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class SporcuManager : ISporcuService
    {
        private ISporcuDal _sporcuDal;
        private readonly IMapper _mapper;
        public SporcuManager(ISporcuDal sporcuDal, IMapper mapper)
        {
            _sporcuDal = sporcuDal;
            _mapper = mapper;
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(2)]
        //[SecuredOperation(Roles = "Admin,Editor,Student")]
        public List<Sporcu> GetAll()
        {
            var sporcus = _mapper.Map<List<Sporcu>>(_sporcuDal.GetList());
            return sporcus;
        }

        public Sporcu GetById(int id)
        {
            return _sporcuDal.Get(p => p.Id == id);
        }
        [FluentValidationAspect(typeof(SporcuValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Sporcu Add(Sporcu sporcu)
        {
            return _sporcuDal.Add(sporcu);
         }
        [FluentValidationAspect(typeof(SporcuValidatior))]
        public Sporcu Update(Sporcu sporcu)
        {
            return _sporcuDal.Update(sporcu);
        }


        public void Delete(int Id)
        {
            _sporcuDal.Delete(new Sporcu { Id = Id });
        }
    }
}
