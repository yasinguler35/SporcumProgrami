using DevFramework.Northwind.Entities.ComplexTypes;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevFramework.Northwind.MvcWebUI.Models
{
    public class SporcuOdemeleriListViewModel
    {
        public List<SporcuOdemeleriDetay> sporcuOdemeleridetay { get; set; }
        public SporcuOdemeleri SporcuOdemeGet { get; set; }
    }
}