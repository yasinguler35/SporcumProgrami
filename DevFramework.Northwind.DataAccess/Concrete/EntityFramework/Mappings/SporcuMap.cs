using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class SporcuMap : EntityTypeConfiguration<Sporcu>
    {
        public SporcuMap()
        {
            ToTable(@"Sporcus", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.AdSoyad).HasColumnName("AdSoyad");
            Property(x => x.FotoID).HasColumnName("FotoId");
            Property(x => x.TelNo).HasColumnName("TelNo");
            Property(x => x.LisansFotoID).HasColumnName("LisansFotoId");
            Property(x => x.Aciklama).HasColumnName("Aciklama");
            Property(x => x.DogumTarihi).HasColumnName("DogumTarihi");
            Property(x => x.VeliAdi).HasColumnName("VeliAdi");
            Property(x => x.VeliTelNo).HasColumnName("VeliTelNo");

        }

    }
}
