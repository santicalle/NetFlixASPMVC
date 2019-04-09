using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nexflix.Startup))]
namespace Nexflix
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
