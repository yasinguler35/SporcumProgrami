using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Entities.Concrete
{
    public class KusakOdemeleri:IEntity
    {
        public virtual int Id { get; set; }
        public virtual int KusakId { get; set; }
        public virtual int SporcuId { get; set; }
        public virtual int ?OdemeTutari { get; set; }
        public virtual string OdemeTarihi { get; set; }
    }
}
