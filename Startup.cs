using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutomobileServiceStation.Startup))]
namespace AutomobileServiceStation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
