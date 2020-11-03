using DevFramework.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Northwind.DataAccess.Abstract;
using AutoMapper;
using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.Aspects.Postsharp.PerformanceAspects;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class KusakOdemeleriManager : IKusakOdemeleriService
    {
        private IKusakOdemeleriDal _kusakOdemeleriDal;
        private readonly IMapper _mapper;
        public KusakOdemeleriManager(IKusakOdemeleriDal kusakOdemeleriDal, IMapper mapper)
        {
            _kusakOdemeleriDal = kusakOdemeleriDal;
            _mapper = mapper;
        }
        //[FluentValidationAspect(typeof(KusakOdemeleriValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public KusakOdemeleri Add(KusakOdemeleri kusakOdemeleri)
        {
            return _kusakOdemeleriDal.Add(kusakOdemeleri);
        }

        public void Delete(int Id)
        {
            _kusakOdemeleriDal.Delete(new KusakOdemeleri { Id = Id });
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        //[PerformanceCounterAspect(2)]
        public List<KusakOdemeleri> GetAll()
        {
            var kusakOdemleris = _mapper.Map<List<KusakOdemeleri>>(_kusakOdemeleriDal.GetList());
            return kusakOdemleris;
        }

        public KusakOdemeleri GetById(int id)
        {
            return _kusakOdemeleriDal.Get(p => p.Id == id);
        }
        //[FluentValidationAspect(typeof(KusaklarValidator))]
        public KusakOdemeleri Update(KusakOdemeleri kusakOdemeleri)
        {
            return _kusakOdemeleriDal.Update(kusakOdemeleri);
        }
    }
}
