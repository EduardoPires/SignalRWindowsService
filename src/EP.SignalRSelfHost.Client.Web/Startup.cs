using Owin;

namespace EP.SignalRSelfHost.Client.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}