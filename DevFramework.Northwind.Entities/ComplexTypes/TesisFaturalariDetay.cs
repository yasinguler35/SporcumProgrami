using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Entities.ComplexTypes
{
    public class TesisFaturalariDetay
    {
        public virtual int Id { get; set; }
        public virtual string FaturaTuru { get; set; }
        public virtual int TesisFaturaTuruId { get; set; }
        public virtual int? TesisFaturaTutari { get; set; }
        public virtual string IslemTarihi { get; set; }
        public virtual int SonOdeme { get; set; }
    }
}
