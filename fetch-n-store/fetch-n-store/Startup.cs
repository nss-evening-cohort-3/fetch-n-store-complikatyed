using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(fetch_n_store.Startup))]
namespace fetch_n_store
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
