using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SteelcaseVQI.Startup))]
namespace SteelcaseVQI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
