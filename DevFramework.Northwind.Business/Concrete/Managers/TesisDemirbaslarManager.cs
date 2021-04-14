using DevFramework.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Entities.Concrete;
using AutoMapper;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.Aspects.Postsharp.PerformanceAspects;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class TesisDemirbaslarManager : ITesisDemirbaslarService
    {
        private ITesisDemirbaslarDal _tesisDemirbaslarDal;
        private readonly IMapper _mapper;
        public TesisDemirbaslarManager(ITesisDemirbaslarDal tesisDemirbaslarDal, IMapper mapper)
        {
            _tesisDemirbaslarDal = tesisDemirbaslarDal;
            _mapper = mapper;
        }
        [FluentValidationAspect(typeof(TesisDemirbaslarValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public TesisDemirbaslar Add(TesisDemirbaslar tesisDemirbaslar)
        {
            return _tesisDemirbaslarDal.Add(tesisDemirbaslar);
        }

        public void Delete(int Id)
        {
            _tesisDemirbaslarDal.Delete(new TesisDemirbaslar { Id = Id });
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(2)]
        public List<TesisDemirbaslar> GetAll()
        {
            var tesisDemirbaslars = _mapper.Map<List<TesisDemirbaslar>>(_tesisDemirbaslarDal.GetList());
            return tesisDemirbaslars;
        }

        public TesisDemirbaslar GetById(int id)
        {
            return _tesisDemirbaslarDal.Get(td=> td.Id == id);
        }
        [FluentValidationAspect(typeof(TesisDemirbaslarValidator))]
        public TesisDemirbaslar Update(TesisDemirbaslar tesisDemirbaslar)
        {
            return _tesisDemirbaslarDal.Update(tesisDemirbaslar);
        }
    }
}
