using AdvancedTechniques.UP.Web;
using AdvancedTechniques.Web.App_Start;
using AdvancedTechniques.Web.ModelBinder;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdvancedTechniques.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            UnityConfig.RegisterComponents();
            BundleConfig.RegisterBundles();

            var binder = new DateTimeModelBinder("dd/MM/yyyy HH:mm");
            ModelBinders.Binders.Add(typeof(DateTime), binder);
        }
    }
}
