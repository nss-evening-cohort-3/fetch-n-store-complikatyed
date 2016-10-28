using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(fands2.Startup))]
namespace fands2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
