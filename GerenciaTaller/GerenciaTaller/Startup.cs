using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GerenciaTaller.Startup))]
namespace GerenciaTaller
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
