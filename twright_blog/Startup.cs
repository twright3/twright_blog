using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(twright_blog.Startup))]
namespace twright_blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
