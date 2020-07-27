using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Merchants.Startup))]
namespace Merchants
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
