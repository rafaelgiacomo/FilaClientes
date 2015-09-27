using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CampanhaBD.UI.WEB.Startup))]
namespace CampanhaBD.UI.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
