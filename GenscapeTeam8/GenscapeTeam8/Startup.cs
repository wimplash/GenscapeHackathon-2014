using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GenscapeTeam8.Startup))]
namespace GenscapeTeam8
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
