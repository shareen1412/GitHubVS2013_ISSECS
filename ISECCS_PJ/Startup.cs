using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ISECCS_PJ.Startup))]
namespace ISECCS_PJ
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
