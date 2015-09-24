using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CampanhaBD.Startup))]
namespace CampanhaBD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
