using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.Abstract
{
    public interface ISporcuFotoService
    {
        [OperationContract]
        List<SporcuFoto> GetAll();
        [OperationContract]
        SporcuFoto GetById(int id);
        [OperationContract]
        SporcuFoto Add(SporcuFoto sporcuFoto);
        [OperationContract]
        SporcuFoto Update(SporcuFoto sporcuFoto);
        [OperationContract]
        void Delete(int Id);
    }
}
