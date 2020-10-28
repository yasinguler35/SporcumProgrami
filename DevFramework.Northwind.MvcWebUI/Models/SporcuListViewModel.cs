using DevFramework.Northwind.Entities.ComplexTypes;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevFramework.Northwind.MvcWebUI.Models
{
    public class SporcuListViewModel
    {
        public List<Sporcu> Sporcus { get; set; }
        public List<SporcuKategoriDetay> SporcuKategoriDetays { get; set; }
        public Sporcu SporcuGet { get; set; }
    }
}