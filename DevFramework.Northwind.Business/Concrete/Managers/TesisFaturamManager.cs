using DevFramework.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Northwind.DataAccess.Abstract;
using AutoMapper;

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
        public TesisFaturam Add(TesisFaturam tesisFaturam)
        {
            return _tesisFaturamDal.Add(tesisFaturam);
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<TesisFaturam> GetAll()
        {
            throw new NotImplementedException();
        }

        public TesisFaturam GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TesisFaturam Update(TesisFaturam tesisFaturam)
        {
            throw new NotImplementedException();
        }
    }
}
