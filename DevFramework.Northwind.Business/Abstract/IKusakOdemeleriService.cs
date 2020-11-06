using DevFramework.Northwind.Entities.ComplexTypes;
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
    public interface IKusakOdemeleriService
    {
        [OperationContract]
        List<KusakOdemeleri> GetAll();
        [OperationContract]
        KusakOdemeleri GetById(int id);
        [OperationContract]
        KusakOdemeleri Add(KusakOdemeleri kusakOdemeleri);
        [OperationContract]
        KusakOdemeleri Update(KusakOdemeleri kusakOdemeleri);
        [OperationContract]
        void Delete(int Id);
        List<KusakOdemeleriDetay> GetKusakOdemleriDetay();
    }
}
