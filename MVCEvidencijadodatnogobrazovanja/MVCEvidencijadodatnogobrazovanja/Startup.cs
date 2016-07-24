using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCEvidencijadodatnogobrazovanja.Startup))]
namespace MVCEvidencijadodatnogobrazovanja
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
