using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(COMP1640_TEAM4.Startup))]
namespace COMP1640_TEAM4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
