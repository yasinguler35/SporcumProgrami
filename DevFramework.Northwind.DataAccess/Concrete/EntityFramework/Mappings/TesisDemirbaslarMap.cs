using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class TesisDemirbaslarMap : EntityTypeConfiguration<TesisDemirbaslar>
    {
        public TesisDemirbaslarMap()
        {
            ToTable(@"TesisDemirbaslars", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.DemirBasAdi).HasColumnName("DemirBasAdi");
            Property(x => x.AlimFiyati).HasColumnName("AlimFiyati");
            Property(x => x.KullanimAmaci).HasColumnName("KullanimAmaci");
            Property(x => x.KullanimYeri).HasColumnName("KullanimYeri");
        }
    }
}
