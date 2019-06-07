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
using Microsoft.AspNet.SignalR.Client;

namespace TaskManager.WindowsServices
{
    public partial class NotificationService : ServiceBase
    {
        private ILog Logger = AppLogger.GetLogger<NotificationService>();

        private Timer timer { get; set; }
        private HubConnection NotificationHubConnection { get; set; }
        private IHubProxy NotificationHubProxy { get; set; }

        public NotificationService()
        {
            InitializeComponent();
            AppLogger.ConfigureFileAppender("ServiceLogs", true);
            NotificationHubConnection = new HubConnection("http://localhost:8080");
            NotificationHubProxy = NotificationHubConnection.CreateHubProxy("TaskManagerHub");
        }

        protected async override void OnStart(string[] args)
        {
            await NotificationHubConnection.Start();
            //NotificationHubConnection.Closed += OnNotificationHubConnectionClosed;
            Logger.Info($"Connected connection id : {NotificationHubConnection.ConnectionId}");
            Logger.Info("Service started");
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(PushNotificationsToClient);
            timer.Interval = 5000;
            timer.Enabled = true;
            timer.Start();
        }

        protected override void OnStop()
        {
            timer.Elapsed -= new ElapsedEventHandler(PushNotificationsToClient);
            NotificationHubConnection.Stop();
            Logger.Info($"Disconnected connection id : {NotificationHubConnection.ConnectionId}");
            Logger.Info("Service stopped");
        }

        private void OnNotificationHubConnectionClosed()
        {
            var t = NotificationHubConnection.Start();

            bool result = false;
            t.ContinueWith(task =>
            {
                if (!task.IsFaulted)
                {
                    result = true;
                }
            }).Wait();

            if (!result)
            {
                OnNotificationHubConnectionClosed();
            }
        }

        private void PushNotificationsToClient(object sender, ElapsedEventArgs e)
        {
            Logger.Info("Service triggering notification");
            try
            {
                NotificationHubProxy.Invoke("PushNotifications");
            }
            catch (Exception ex)
            {
                Logger.Error("Error occurred while sending request to signalR hub", ex);
            }
        }
    }
}
