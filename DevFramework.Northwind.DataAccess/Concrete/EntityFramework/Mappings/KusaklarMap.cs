using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class KusaklarMap : EntityTypeConfiguration<Kusaklar>
    {
        public KusaklarMap()
        {
            ToTable(@"Kusaklars", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.KusakAdi).HasColumnName("KusakAdi");
        }
    }
}
