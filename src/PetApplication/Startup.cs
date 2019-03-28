using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetApplication.Startup))]
namespace PetApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
