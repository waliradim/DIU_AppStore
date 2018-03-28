using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppStore.Startup))]
namespace AppStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
