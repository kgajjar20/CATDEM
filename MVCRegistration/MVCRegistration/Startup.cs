using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCRegistration.Startup))]
namespace MVCRegistration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
