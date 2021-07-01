using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ebook.Startup))]
namespace ebook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
