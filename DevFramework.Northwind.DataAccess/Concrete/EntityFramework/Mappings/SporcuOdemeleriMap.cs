using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class SporcuOdemeleriMap : EntityTypeConfiguration<SporcuOdemeleri>
    {
        public SporcuOdemeleriMap()
        {
            ToTable(@"SporcuOdemeleris", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Ocak).HasColumnName("Ocak");
            Property(x => x.Subat).HasColumnName("Subat");
            Property(x => x.Mart).HasColumnName("Mart");
            Property(x => x.Nisan).HasColumnName("Nisan");
            Property(x => x.Mayis).HasColumnName("Mayis");
            Property(x => x.Haziran).HasColumnName("Haziran");
            Property(x => x.Temmuz).HasColumnName("Temmuz");
            Property(x => x.Agustos).HasColumnName("Agustos");
            Property(x => x.Eylul).HasColumnName("Eylul");
            Property(x => x.Ekim).HasColumnName("Ekim");
            Property(x => x.Kasim).HasColumnName("Kasim");
            Property(x => x.Aralik).HasColumnName("Aralik");
            Property(x => x.SporcuId).HasColumnName("SporcuId");
            Property(x => x.KiyafetParasi).HasColumnName("KiyafetParasi");
            Property(x => x.Yil).HasColumnName("Yil");
            Property(x => x.KayitTarihi).HasColumnName("KayitTarihi");
        }
    }
}
