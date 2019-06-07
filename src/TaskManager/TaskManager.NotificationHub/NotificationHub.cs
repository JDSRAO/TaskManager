using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Business;

namespace TaskManager.NotificationHub
{
    [HubName("TaskManagerHub")]
    public class NotificationHub : Hub
    {
        private NotificationManager notificationManagerManager = new NotificationManager();

        public override Task OnConnected()
        {
            Console.WriteLine($"{Clients.Caller} client connected");
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Console.WriteLine($"{Clients.Caller} client disconnected");
            return base.OnDisconnected(stopCalled);
        }

        public void PushNotifications()
        {
            var startDate = Convert.ToDateTime("2019-05-31 17:00:00.433");
            var notifications = notificationManagerManager.GetNotifications(startDate);
            if (notifications.Any())
            {
                Clients.All.addMessage(notifications);
            }
        }
    }
}
