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
    public interface ISporcuOdemeleriService
    {
        [OperationContract]
        List<SporcuOdemeleri> GetAll();
        [OperationContract]
        SporcuOdemeleri GetById(int id);
        [OperationContract]
        SporcuOdemeleri Add(SporcuOdemeleri sporcuOdemeleri);
        [OperationContract]
        SporcuOdemeleri Update(SporcuOdemeleri sporcuOdemeleri);
        [OperationContract]
        void Delete(int Id);

        List<SporcuOdemeleriDetay> GetSporcuOdemeleriDetay();
    }
}
