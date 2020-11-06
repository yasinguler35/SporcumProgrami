using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Entities.ComplexTypes
{
    public class KusakOdemeleriDetay
    {
        public virtual int Id { get; set; }
        public virtual int KusakId { get; set; }
        public virtual int SporcuId { get; set; }
        public virtual string OdemeTarihi { get; set; }
        public virtual string KusakAdi { get; set; }
        public virtual string AdSoyad { get; set; }
    }
}
