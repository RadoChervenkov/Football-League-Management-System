using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FLMS.Web.Startup))]
namespace FLMS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
