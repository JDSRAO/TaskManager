using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Business;
using System.Timers;
using TaskManager.Models.DTO;

namespace TaskManager.WindowsServices
{
    public partial class NotificationService : ServiceBase
    {
        private static NotificationManager notificationManagerManager = new NotificationManager();
        private Timer timer { get; }


        public NotificationService()
        {
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(PushNotificationsToClient);
            timer.Interval = 5000;
            timer.Enabled = true;
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }

        private void PushNotificationsToClient(object sender, ElapsedEventArgs e)
        {
            var startDate = Convert.ToDateTime("2019-05-31 17:00:00.433");
            var notifications = new List<UserTaskDto>();
            notifications = notificationManagerManager.GetNotifications(startDate);
            if (notifications.Any())
            {
                //call hub
            }
        }
    }
}
