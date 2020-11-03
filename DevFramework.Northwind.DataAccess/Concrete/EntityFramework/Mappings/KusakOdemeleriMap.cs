using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class KusakOdemeleriMap : EntityTypeConfiguration<KusakOdemeleri>
    {
        public KusakOdemeleriMap()
        {
            ToTable(@"KusakOdemeleris", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.KusakId).HasColumnName("KusakId");
            Property(x => x.SporcuId).HasColumnName("SporcuId");
            Property(x => x.OdemeTarihi).HasColumnName("OdemeTarihi");
  
        }
    }
}
