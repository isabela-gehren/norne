using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Norne.Web.Startup))]
namespace Norne.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
