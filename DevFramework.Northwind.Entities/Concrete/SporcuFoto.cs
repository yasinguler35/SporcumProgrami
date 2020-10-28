using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Entities.Concrete
{
    public class SporcuFoto:IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string ContentType { get; set; }
        public virtual Byte[] Data { get; set; }
    }
}
