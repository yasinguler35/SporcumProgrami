using DevFramework.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Northwind.DataAccess.Abstract;
using AutoMapper;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.Aspects.Postsharp.PerformanceAspects;
using DevFramework.Core.Aspects.Postsharp.ValidationAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class SporcuKategoriManager : ISporcuKategoriService
    {
        private ISporcuKategoriDal _sporcuKategoriDal;
        private readonly IMapper _mapper;
        public SporcuKategoriManager(ISporcuKategoriDal sporcuKategoriDal, IMapper mapper)
        {
            _sporcuKategoriDal = sporcuKategoriDal;
            _mapper = mapper;
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(2)]
        //[SecuredOperation(Roles = "Admin,Editor,Student")]
        public List<SporcuKategori> GetAll()
        {
            var sporcuKategories = _mapper.Map<List<SporcuKategori>>(_sporcuKategoriDal.GetList());
            return sporcuKategories;
        }

        public SporcuKategori GetById(int id)
        {
            return _sporcuKategoriDal.Get(p => p.Id == id);
        }
        [FluentValidationAspect(typeof(SporcuKategoriValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public SporcuKategori Add(SporcuKategori sporcuKategori)
        {
            return _sporcuKategoriDal.Add(sporcuKategori);
        }
        [FluentValidationAspect(typeof(SporcuKategoriValidatior))]
        public SporcuKategori Update(SporcuKategori sporcuKategori)
        {
            return _sporcuKategoriDal.Update(sporcuKategori);
        }
        public void Delete(int Id)
        {
            _sporcuKategoriDal.Delete(new SporcuKategori { Id = Id });
        }
    }
}
