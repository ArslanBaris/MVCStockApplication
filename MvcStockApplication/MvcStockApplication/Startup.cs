using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcStockApplication.Startup))]
namespace MvcStockApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
