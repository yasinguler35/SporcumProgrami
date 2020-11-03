using DevFramework.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Northwind.DataAccess.Abstract;
using AutoMapper;
using DevFramework.Core.Aspects.Postsharp.PerformanceAspects;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Core.Aspects.Postsharp.ValidationAspects;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class KusaklarManager : IKusaklarService
    {
        private IKusaklarDal _kusaklarDal;
        private readonly IMapper _mapper;
        public KusaklarManager(IKusaklarDal kusaklarDal, IMapper mapper)
        {
            _kusaklarDal = kusaklarDal;
            _mapper = mapper;
        }
        [FluentValidationAspect(typeof(KusaklarValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Kusaklar Add(Kusaklar kusaklar)
        {
            return _kusaklarDal.Add(kusaklar);
        }

        public void Delete(int Id)
        {
            _kusaklarDal.Delete(new Kusaklar { Id = Id });
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(2)]
        public List<Kusaklar> GetAll()
        {
            var kusaklars = _mapper.Map<List<Kusaklar>>(_kusaklarDal.GetList());
            return kusaklars;
        }

        public Kusaklar GetById(int id)
        {
            return _kusaklarDal.Get(p => p.Id == id);
        }
        [FluentValidationAspect(typeof(KusaklarValidatior))]
        public Kusaklar Update(Kusaklar kusaklar)
        {
            return _kusaklarDal.Update(kusaklar);
        }
    }
}
