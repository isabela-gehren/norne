using Norne.Business;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Norne.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InjetaDependecias();
        }

        private void InjetaDependecias()
        {
            var container = new Container();

            container.Register<ICorrentistaBusiness, CorrentistaBusiness>(Lifestyle.Transient);
            container.Register<IFuncionarioBusiness, FuncionarioBusiness>(Lifestyle.Transient);
            container.Register<IPapelBusiness, PapelBusiness>(Lifestyle.Transient);
            container.Register<IStatusContaBusiness, StatusContaBusiness>(Lifestyle.Transient);

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
