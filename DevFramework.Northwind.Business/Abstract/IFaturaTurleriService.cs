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
    public interface IFaturaTurleriService
    {
        [OperationContract]
        List<FaturaTurleri> GetAll();
        [OperationContract]
        FaturaTurleri GetById(int id);
        [OperationContract]
        FaturaTurleri Add(FaturaTurleri faturaTurleri);
        [OperationContract]
        FaturaTurleri Update(FaturaTurleri faturaTurleri);
        [OperationContract]
        void Delete(int Id);
    }
}
