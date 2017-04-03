using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(null,
                            "",
                            new
                            {
                                controller = "Product",
                                action = "List",
                                type = (string)null,
                                category = (string)null,
                                page = 1
                            }
                            );

            routes.MapRoute(null,
            "Admin/Edit/{productId}",
            new { controller = "Admin", action = "Edit" }
            );
            routes.MapRoute(null,
            "Admin/Edit",
            new { controller = "Admin", action = "Edit" }
            );
            routes.MapRoute(null,
          "Admin/Create",
          new { controller = "Admin", action = "Create" }
          );
            
            routes.MapRoute(null,
           "Admin/Delete/{productId}",
           new { controller = "Admin", action = "Delete" }
           );
            routes.MapRoute(null,
           "{type}/{category}/Page{page}",
           new { controller = "Product", action = "List" }
           );
            routes.MapRoute(null,
          "{type}/Page{page}",
          new { controller = "Product", action = "List" }
          );
            routes.MapRoute(null,
           "Admin",
           new { controller = "Admin", action = "Index" }
           );
            routes.MapRoute(null,
            "Page{page}",
            new { controller = "Product", action = "List", category = (string)null, type= (string)null },
            new { page = @"\d+" }
            );
            routes.MapRoute(null,
           "{type}/{category}/Page{page}",
           new { controller = "Product", action = "List" }
           );
            
            
            routes.MapRoute(null,
            "{type}",
            new { controller = "Product", action = "List", page = 1 },
            new { page = @"\d+" }
            );
          routes.MapRoute(null,
           "All/{category}",
           new { controller = "Product", action = "List", type = (string)null, page = 1 }
           );
            

            routes.MapRoute(null,
            "All/{category}/Page{page}",
            new { controller = "Product", action = "List", type = (string)null },
            new { page = @"\d+" }
            );
            
            routes.MapRoute(null, "{controller}/{action}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Product", action = "List", id = UrlParameter.Optional }
            //);
        }
    }
}
