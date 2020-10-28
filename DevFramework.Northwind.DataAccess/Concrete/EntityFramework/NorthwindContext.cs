using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext:DbContext
    {
        public NorthwindContext()
        {
            Database.SetInitializer<NorthwindContext>(null);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        //
        public DbSet<Sporcu> Sporcus { get; set; }
        public DbSet<SporcuFoto> SporcuFotoes { get; set; }
        public DbSet<SporcuKategori> SporcuKategoris { get; set; }
        public DbSet<SporcuOdemeleri> SporcuOdemeleris { get; set; }

        public DbSet<Kusaklar> Kusaklars { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new SporcuMap());
            modelBuilder.Configurations.Add(new SporcuFotoMap());
            modelBuilder.Configurations.Add(new SporcuKategoriMap());
            modelBuilder.Configurations.Add(new SporcuOdemeleriMap());
            modelBuilder.Configurations.Add(new KusaklarMap());
            //
        }
    }
}
