using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(gestionSinisterWeb.Startup))]
namespace gestionSinisterWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
