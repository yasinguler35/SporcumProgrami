using DevFramework.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Northwind.DataAccess.Abstract;
using AutoMapper;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.Aspects.Postsharp.PerformanceAspects;
using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.Entities.ComplexTypes;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class SporcuOdemeleriManager : ISporcuOdemeleriService
    {
        private ISporcuOdemeleriDal _sporcuOdemeleriDal;
        private readonly IMapper _mapper;
        public SporcuOdemeleriManager(ISporcuOdemeleriDal sporcuOdemeleriDal, IMapper mapper)
        {
            _sporcuOdemeleriDal = sporcuOdemeleriDal;
            _mapper = mapper;
        }
        [FluentValidationAspect(typeof(SporcuOdemeleriValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public SporcuOdemeleri Add(SporcuOdemeleri sporcuOdemeleri)
        {
          return  _sporcuOdemeleriDal.Add(sporcuOdemeleri);
        }

        public void Delete(int Id)
        {
            _sporcuOdemeleriDal.Delete(new SporcuOdemeleri { Id = Id });
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(2)]
        public List<SporcuOdemeleri> GetAll()
        {
            var sporcuOdemeleris = _mapper.Map<List<SporcuOdemeleri>>(_sporcuOdemeleriDal.GetList());
            return sporcuOdemeleris;
        }

        public SporcuOdemeleri GetById(int id)
        {
            return _sporcuOdemeleriDal.Get(p => p.Id == id);
        }
        [FluentValidationAspect(typeof(SporcuOdemeleriValidatior))]
        public SporcuOdemeleri Update(SporcuOdemeleri sporcuOdemeleri)
        {
            return _sporcuOdemeleriDal.Update(sporcuOdemeleri);
        }

        public List<SporcuOdemeleriDetay> GetSporcuOdemeleriDetay()
        {
            return _sporcuOdemeleriDal.GetSporcuOdemeleriDetay();
        }
    }
}
