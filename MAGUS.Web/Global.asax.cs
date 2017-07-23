using MAGUS.Services;
using MAGUS.Web.Facade;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MAGUS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            //UnityConfig.RegisterComponents();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            JsonSerializerSettings serializerSettings = new Newtonsoft.Json.JsonSerializerSettings();
            serializerSettings.TypeNameHandling = TypeNameHandling.Auto;
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings = serializerSettings;

            StartApp.InitConfigs();
        }
    }
}
