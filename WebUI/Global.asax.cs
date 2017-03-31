using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BooksStore.Domain.Entities;
using BooksStore.WebUI.Infrastructure.Binders;

namespace WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
            //var info = new System.Globalization.CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.ToString());
            ////info.NumberFormat.CurrencyDecimalSeparator = "."
            ////info.NumberFormat.NumberDecimalSeparator = "."
            ////info.NumberFormat.PercentDecimalSeparator = "."
            ////info.NumberFormat.CurrencyGroupSeparator = ","
            ////info.NumberFormat.NumberGroupSeparator = ","
            ////info.NumberFormat.PercentGroupSeparator = ","
            ////info.NumberFormat.
            //info.NumberFormat.CurrencySymbol = "Z.";
            //System.Threading.Thread.CurrentThread.CurrentCulture = info;
        }
    }
}
