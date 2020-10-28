using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.Abstract
{
    public interface ISporcuKategoriService
    {
        [OperationContract]
        List<SporcuKategori> GetAll();
        [OperationContract]
        SporcuKategori GetById(int id);
        [OperationContract]
        SporcuKategori Add(SporcuKategori sporcuKategori);
        [OperationContract]
        SporcuKategori Update(SporcuKategori sporcuKategori);
        [OperationContract]
        void Delete(int Id);
    }
}
