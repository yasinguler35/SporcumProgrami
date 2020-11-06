using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevFramework.Northwind.MvcWebUI.Models
{
    public class KusakOdemeleriListViewModel
    {
        public List<KusakOdemeleri> kusakOdemleris { get; set; }
        public KusakOdemeleri kusakOdemeleriGet { get; set; }
    }
}