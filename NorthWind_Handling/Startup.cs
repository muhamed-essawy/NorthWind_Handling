using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NorthWind_Handling.Startup))]
namespace NorthWind_Handling
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
