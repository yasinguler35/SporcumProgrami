using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.Abstract
{
    [ServiceContract]
    public interface IKusaklarService
    {
        [OperationContract]
        List<Kusaklar> GetAll();
        [OperationContract]
        Kusaklar GetById(int id);
        [OperationContract]
        Kusaklar Add(Kusaklar kusaklar);
        [OperationContract]
        Kusaklar Update(Kusaklar kusaklar);
        [OperationContract]
        void Delete(int Id);
    }
}
