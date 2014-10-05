using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NesclPms.WebUI.Startup))]
namespace NesclPms.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
