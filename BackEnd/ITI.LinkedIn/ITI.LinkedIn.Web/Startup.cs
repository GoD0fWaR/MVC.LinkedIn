using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITI.LinkedIn.Web.Startup))]
namespace ITI.LinkedIn.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
