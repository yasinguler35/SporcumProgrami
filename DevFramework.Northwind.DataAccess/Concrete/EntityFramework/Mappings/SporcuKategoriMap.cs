using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class SporcuKategoriMap : EntityTypeConfiguration<SporcuKategori>
    {
        public SporcuKategoriMap()
        {
            ToTable(@"SporcuKategoris", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.KategoriAdi).HasColumnName("KategoriAdi");
        }
    }
}
