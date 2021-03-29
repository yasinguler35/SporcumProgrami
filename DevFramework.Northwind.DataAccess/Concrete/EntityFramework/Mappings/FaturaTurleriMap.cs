using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class FaturaTurleriMap : EntityTypeConfiguration<FaturaTurleri>
    {
        public FaturaTurleriMap()
        {
            ToTable(@"FaturaTurleries", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.FaturaTuru).HasColumnName("FaturaTuru");
        }
    }
}
