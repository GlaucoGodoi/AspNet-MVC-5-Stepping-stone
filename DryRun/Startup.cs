using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DryRun.Startup))]
namespace DryRun
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
