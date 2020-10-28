using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Entities.Concrete
{
    public class Kusaklar:IEntity
    {
        public virtual int  Id { get; set; }
        public virtual string KusakAdi { get; set; }
    }
}
