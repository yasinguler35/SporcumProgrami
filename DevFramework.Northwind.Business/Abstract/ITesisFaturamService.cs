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
    public interface ITesisFaturamService
    {
        [OperationContract]
        List<TesisFaturam> GetAll();
        [OperationContract]
        TesisFaturam GetById(int id);
        [OperationContract]
        TesisFaturam Add(TesisFaturam tesisFaturam);
        [OperationContract]
        TesisFaturam Update(TesisFaturam tesisFaturam);
        [OperationContract]
        void Delete(int Id);
        List<TesisFaturalariDetay> GetTesisFaturamDetay();
    }
}
