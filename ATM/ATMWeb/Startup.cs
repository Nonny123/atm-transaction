using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ATMWeb.Startup))]
namespace ATMWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
