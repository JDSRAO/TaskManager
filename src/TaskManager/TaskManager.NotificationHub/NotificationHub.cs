using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.NotificationHub
{
    [HubName("TaskManagerHub")]
    public class NotificationHub : Hub
    {
        public void PushNotifications()
        {
            Clients.All.addMessage("");
        }
    }
}
