using AutoMapper;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.Aspects.Postsharp.PerformanceAspects;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class FaturaTurleriManager : IFaturaTurleriService
    {
        private IFaturaTurleriDal _faturaTurleriDal;
        private readonly IMapper _mapper;
        public FaturaTurleriManager(IFaturaTurleriDal faturaTurleriDal, IMapper mapper)
        {
            _faturaTurleriDal = faturaTurleriDal;
            _mapper = mapper;
        }
        [FluentValidationAspect(typeof(FaturaTurleriValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public FaturaTurleri Add(FaturaTurleri faturaTurleri)
        {
            return _faturaTurleriDal.Add(faturaTurleri);
        }

        public void Delete(int Id)
        {
            _faturaTurleriDal.Delete(new FaturaTurleri { Id = Id });
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(2)]
        public List<FaturaTurleri> GetAll()
        {
            var faturaTurleries = _mapper.Map<List<FaturaTurleri>>(_faturaTurleriDal.GetList());
            return faturaTurleries;
        }

        public FaturaTurleri GetById(int id)
        {
            return _faturaTurleriDal.Get(ft => ft.Id == id);
        }
        [FluentValidationAspect(typeof(KusaklarValidatior))]
        public FaturaTurleri Update(FaturaTurleri faturaTurleri)
        {
            return _faturaTurleriDal.Update(faturaTurleri);
        }
    }
}
