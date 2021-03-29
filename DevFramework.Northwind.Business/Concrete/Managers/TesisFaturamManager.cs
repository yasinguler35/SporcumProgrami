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
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.Aspects.Postsharp.PerformanceAspects;
using DevFramework.Northwind.Entities.ComplexTypes;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class TesisFaturamManager : ITesisFaturamService
    {
        private ITesisFaturamDal _tesisFaturamDal;
        private readonly IMapper _mapper;
        public TesisFaturamManager(ITesisFaturamDal tesisFaturamDal, IMapper mapper)
        {
            _mapper = mapper;
            _tesisFaturamDal = tesisFaturamDal;
        }
        [FluentValidationAspect(typeof(TesisFaturamValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public TesisFaturam Add(TesisFaturam tesisFaturam)
        {
            return _tesisFaturamDal.Add(tesisFaturam);
        }

        public void Delete(int Id)
        {
            _tesisFaturamDal.Delete(new TesisFaturam { Id = Id });
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(2)]
        public List<TesisFaturam> GetAll()
        {
            var tesisfaturams = _mapper.Map<List<TesisFaturam>>(_tesisFaturamDal.GetList());
            return tesisfaturams;
        }

        public TesisFaturam GetById(int id)
        {
            return _tesisFaturamDal.Get(p => p.Id == id);
        }
        [FluentValidationAspect(typeof(TesisFaturamValidatior))]
        public TesisFaturam Update(TesisFaturam tesisFaturam)
        {
            return _tesisFaturamDal.Update(tesisFaturam);
        }

        public List<TesisFaturalariDetay> GetTesisFaturamDetay()
        {
            return _tesisFaturamDal.GetTesisFaturamDetay();
        }
    }
}
