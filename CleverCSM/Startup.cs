using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CleverCSM.Startup))]
namespace CleverCSM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
