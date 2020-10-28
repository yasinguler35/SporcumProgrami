using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Entities.Concrete
{
    public class SporcuOdemeleri:IEntity
    {
        public virtual int Id { get; set; }
        public virtual int SporcuId { get; set; }
        public virtual int ?Ocak { get; set; }
        public virtual int ?Subat { get; set; }
        public virtual int ?Mart { get; set; }
        public virtual int ?Nisan { get; set; }
        public virtual int ?Mayis { get; set; }
        public virtual int ?Haziran { get; set; }
        public virtual int ?Temmuz { get; set; }
        public virtual int ?Agustos { get; set; }
        public virtual int ?Eylul { get; set; }
        public virtual int ?Ekim { get; set; }
        public virtual int ?Kasim { get; set; }
        public virtual int ?Aralik { get; set; }
        public virtual int ?KiyafetParasi { get; set; }
        public virtual int ?Yil { get; set; }
        public virtual string KayitTarihi { get; set; }
       
    }
}
