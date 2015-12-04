using System.Diagnostics;
using System.ServiceProcess;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using System.Timers;

namespace EP.SignalRSelfHost.Server.WindowsService
{
    [assembly: OwinStartup(typeof(EP.SignalRSelfHost.Server.WindowsService.Startup))]
    public partial class Broadcast : ServiceBase
    {
        private Timer _timer;

        public Broadcast()
        {
            InitializeComponent();
            AutoLog = false;
        }

        protected override void OnStart(string[] args)
        {
            if (!EventLog.SourceExists("SignalRServer"))
            {
                EventLog.CreateEventSource("SignalRServer", "Application");
            }

            EventLogService.Source = "SignalRServer";
            EventLogService.Log = "Application";
            EventLogService.WriteEntry("SignalRServer Started");

            InitializeSelfHosting();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            BroadcastGenerator.Run();
        }

        protected override void OnStop()
        {
            _timer.Stop();
            _timer.Dispose();
            EventLogService.WriteEntry("SignalRServer Stoped");
        }

        public void InitializeSelfHosting()
        {
            const string url = "http://localhost:8080";
            WebApp.Start(url);

            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }
    }
}
