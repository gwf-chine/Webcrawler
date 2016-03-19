using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Antuo.Web.Startup))]
namespace Antuo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
