using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.Abstract
{
    public interface ISporcuService
    {
        [OperationContract]
        List<Sporcu> GetAll();
        [OperationContract]
        Sporcu GetById(int id);
        [OperationContract]
        Sporcu Add(Sporcu sporcu);
        [OperationContract]
        Sporcu Update(Sporcu sporcu);
        [OperationContract]
        void Delete(int Id);
    }
}
