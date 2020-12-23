using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using NLayerApp.BLL.Infrastructure;
using NLayerApp.PL.Util;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;


namespace NLayerApp.PL
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // внедрение зависимостей
            NinjectModule bookingModule = new BookingModule();
            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            var kernel = new StandardKernel(bookingModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}

//сопоставитель зависимостей 
