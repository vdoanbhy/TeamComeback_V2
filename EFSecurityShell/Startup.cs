using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamComeback_V2.Startup))]
namespace TeamComeback_V2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
