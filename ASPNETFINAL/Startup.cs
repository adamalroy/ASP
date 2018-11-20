using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPNETFINAL.Startup))]
namespace ASPNETFINAL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
