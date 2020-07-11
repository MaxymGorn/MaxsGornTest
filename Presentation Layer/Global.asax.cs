using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using Presentation_Layer.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Presentation_Layer
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            NinjectModule ninjectModule = new ServiceModule();
            NinjectModule serviceModule = new Business_Logic_Layer.Infrastructure.ServiceModule();
            var kernel = new StandardKernel(ninjectModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
        protected void Application_BeginRequest()
        {
            cookies = new HttpCookie("id", Guid.NewGuid().ToString());
        }
        public static HttpCookie cookies { get; set; }
    }
}
