using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevFramework.Northwind.MvcWebUI.Helper
{
    public static class HtmlHelpers
    {
        public static string Sec(this HtmlHelper htmlHelper, string ID)
        {
            if (ID == null)
            {
                return "Seçiniz";
            }
            return ID;
        }
    }
}