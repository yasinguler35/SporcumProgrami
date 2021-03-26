using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class TesisFaturamMap : EntityTypeConfiguration<TesisFaturam>
    {
        public TesisFaturamMap()
        {
            ToTable(@"TesisFaturams", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.IslemTarihi).HasColumnName("IslemTarihi");
            Property(x => x.SonOdeme).HasColumnName("SonOdeme");
            Property(x => x.TesisFaturaTuruId).HasColumnName("TesisFaturaTuru");
            Property(x => x.TesisFaturaTutari).HasColumnName("TesisFaturaTutari");
        }
    }
}
