using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Festispec.Web.Startup))]
namespace Festispec.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
