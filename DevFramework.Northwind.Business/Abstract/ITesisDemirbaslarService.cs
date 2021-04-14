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
    public interface ITesisDemirbaslarService
    {
        [OperationContract]
        List<TesisDemirbaslar> GetAll();
        [OperationContract]
        TesisDemirbaslar GetById(int id);
        [OperationContract]
        TesisDemirbaslar Add(TesisDemirbaslar tesisDemirbaslar);
        [OperationContract]
        TesisDemirbaslar Update(TesisDemirbaslar tesisDemirbaslar);
        [OperationContract]
        void Delete(int Id);
    }
}
