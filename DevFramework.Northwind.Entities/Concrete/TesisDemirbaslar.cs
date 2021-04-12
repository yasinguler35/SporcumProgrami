using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Entities.Concrete
{
    public class TesisDemirbaslar:IEntity
    {
        public virtual int Id { get; set; }
        public virtual int? AlimFiyati { get; set; }
        public virtual string DemirBasAdi { get; set; }
        public virtual string KullanimAmaci { get; set; }
        public virtual string KullanimYeri { get; set; }
    }
}
