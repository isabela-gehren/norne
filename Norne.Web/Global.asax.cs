using Norne.Business;
using Norne.Utils;
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

            InjetaDependencias();
        }

        private void InjetaDependencias()
        {
            var container = new Container();

            container.Register<ICorrentistaBusiness, CorrentistaBusiness>(Lifestyle.Transient);
            container.Register<IFuncionarioBusiness, FuncionarioBusiness>(Lifestyle.Transient);
            container.Register<IPapelBusiness, PapelBusiness>(Lifestyle.Transient);
            container.Register<IStatusContaBusiness, StatusContaBusiness>(Lifestyle.Transient);
            container.Register<IContaCorrenteBusiness, ContaCorrenteBusiness>(Lifestyle.Transient);
            container.Register<IContaPoupancaBusiness, ContaPoupancaBusiness>(Lifestyle.Transient);
            container.Register<ICriptografia, CriptografiaHash>(Lifestyle.Transient);

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
