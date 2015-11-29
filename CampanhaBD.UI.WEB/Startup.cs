using Microsoft.Owin;
using Owin;
using System.Web.ModelBinding;

[assembly: OwinStartupAttribute(typeof(CampanhaBD.UI.WEB.Startup))]
namespace CampanhaBD.UI.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            ConfigureAuth(app);
        }
    }
}
