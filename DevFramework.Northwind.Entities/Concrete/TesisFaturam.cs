using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Entities.Concrete
{
    public class TesisFaturam:IEntity
    {
        public virtual int Id { get; set; }
        public virtual int? TesisFaturaTuruId { get; set; }
        public virtual int? TesisFaturaTutari { get; set; }
        public virtual string IslemTarihi { get; set; }
        public virtual string SonOdeme { get; set; }
    }
}
