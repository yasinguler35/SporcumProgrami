using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DevFramework.Northwind.MvcWebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Sporcu", action = "Index", id = UrlParameter.Optional }
            );
            //routes.MapRoute(
            //"sporcuodemeleriurl",
            //"sporcu-odemeleri/{id}",
            //new { controller = "SporcuOdemeleri", action = "Index", id = "" }
            //);
            //routes.MapRoute(
            //name:"sporcukategoriurl",
            //url:"sporcu-kategori/{id}",
            //defaults: new { controller = "SporcuKategori", action = "Index", id = "" }
            //);

        }
    }
}
