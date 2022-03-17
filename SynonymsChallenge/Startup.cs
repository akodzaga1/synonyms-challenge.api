using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SynonymsChallenge.Startup))]

namespace SynonymsChallenge
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }
    }
}
