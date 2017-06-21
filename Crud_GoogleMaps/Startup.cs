using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Crud_GoogleMaps.Startup))]
namespace Crud_GoogleMaps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
