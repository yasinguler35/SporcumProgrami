using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevFramework.Northwind.MvcWebUI.Models
{
    public class TesisDemirbaslarListViewModel
    {
        public List<TesisDemirbaslar> tesisDemirbaslars { get; set; }
        public TesisDemirbaslar tesisDemirbaslarGet { get; set; }
    }
}