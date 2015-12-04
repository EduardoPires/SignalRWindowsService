using System;
using Microsoft.AspNet.SignalR;

namespace EP.SignalRSelfHost.Server.WindowsService
{
    public class BroadcastHub : Hub
    {
        public void TimeNow()
        {
            Clients.All.showTime(DateTime.Now.ToString("dd/MM/yyyy   HH:mm:ss"));
        }

        public void BrokerStatus(int num, string color)
        {
            Clients.All.showBrokerStatus(num, color);
        }

        public void SendMessage(string name, string msg)
        {
            Clients.All.sendChatMessage(name, msg);
        }
    }
}