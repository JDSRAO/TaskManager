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
