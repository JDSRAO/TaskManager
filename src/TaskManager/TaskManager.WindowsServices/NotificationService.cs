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
using Logging;
using log4net;

namespace TaskManager.WindowsServices
{
    public partial class NotificationService : ServiceBase
    {
        private NotificationManager notificationManagerManager = new NotificationManager();
        private ILog Logger = AppLogger.GetLogger<NotificationService>();

        private Timer timer { get; set; }

        public NotificationService()
        {
            InitializeComponent();
            AppLogger.ConfigureFileAppender("ServiceLogs", true);
        }

        protected override void OnStart(string[] args)
        {
            Logger.Info("Service started");
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(PushNotificationsToClient);
            timer.Interval = 5000;
            timer.Enabled = true;
            timer.Start();
        }

        protected override void OnStop()
        {
            Logger.Info("Service stopped");
        }

        private void PushNotificationsToClient(object sender, ElapsedEventArgs e)
        {
            Logger.Info("Service triggering notification");
        }
    }
}
