using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BankingManagement.Startup))]
namespace BankingManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
