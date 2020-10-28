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
    public class SporcuFotoManager : ISporcuFotoService
    {
        private ISporcuFotoDal _sporcuFotoDal;
        private readonly IMapper _mapper;
        public SporcuFotoManager(ISporcuFotoDal sporcuFotoDal, IMapper mapper)
        {
            _sporcuFotoDal = sporcuFotoDal;
            _mapper = mapper;
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(2)]
        //[SecuredOperation(Roles = "Admin,Editor,Student")]
        public List<SporcuFoto> GetAll()
        {
            var sporcuFotos = _mapper.Map<List<SporcuFoto>>(_sporcuFotoDal.GetList());
            return sporcuFotos;
        }

        public SporcuFoto GetById(int id)
        {
            return _sporcuFotoDal.Get(p => p.Id == id);
        }
        [FluentValidationAspect(typeof(SporcuFotoValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public SporcuFoto Add(SporcuFoto sporcuFoto)
        {
            return _sporcuFotoDal.Add(sporcuFoto);
        }
        [FluentValidationAspect(typeof(SporcuFotoValidatior))]
        public SporcuFoto Update(SporcuFoto sporcuFoto)
        {
            return _sporcuFotoDal.Update(sporcuFoto);
        }
        public void Delete(int Id)
        {
            _sporcuFotoDal.Delete(new SporcuFoto { Id = Id });
        }
    }
}
