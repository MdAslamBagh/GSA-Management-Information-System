using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GSA_Management_Information_System.Startup))]
namespace GSA_Management_Information_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
