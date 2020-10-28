using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevFramework.Northwind.MvcWebUI.Models
{
    public class SporcuKategoriListViewModel
    {
        public List<SporcuKategori> SporcuKategories { get; set; }
        public SporcuKategori SporcuKategoriGet { get; set; }
    }
}