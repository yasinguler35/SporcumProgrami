using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    public class SporcuFotoMap : EntityTypeConfiguration<SporcuFoto>
    {
        public SporcuFotoMap()
        {
            ToTable(@"SporcuFotoes", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Name).HasColumnName("Name");
            Property(x => x.ContentType).HasColumnName("ContentType");
            Property(x => x.Data).HasColumnName("Data");

        }
    }
}
