using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XCommerce.Startup))]
namespace XCommerce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
