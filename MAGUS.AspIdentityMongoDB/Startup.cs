using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MAGUS.AspIdentityMongoDB.Startup))]
namespace MAGUS.AspIdentityMongoDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
