using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoreFrontLab.UI.MVC.Startup))]
namespace StoreFrontLab.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
