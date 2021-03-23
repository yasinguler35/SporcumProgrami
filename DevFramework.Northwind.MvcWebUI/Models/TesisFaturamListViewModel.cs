using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevFramework.Northwind.MvcWebUI.Models
{
    public class TesisFaturamListViewModel
    {
        public List<TesisFaturam> tesisFaturams { get; set; }
        public TesisFaturam tesisFaturamGet { get; set; }
    }
}