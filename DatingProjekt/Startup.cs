using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DatingProjekt.Startup))]
namespace DatingProjekt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
