using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using TaskManager.Business;
using TaskManager.Models.DTO;

namespace TaskManager.UI.WPF.Views.Shell
{
    public class MainWindowModel : BaseViewModel, IDisposable
    {
        public ObservableCollection<UserTaskDto> Notifications
        {
            get => notifications;
            set
            {
                notifications = value;
                OnPropertyChanged("Notifications");
            }
        }

        public event EventHandler<List<UserTaskDto>> PublishNotifications;

        private ObservableCollection<UserTaskDto> notifications { get; set; }
        private NotificationManager notificationManagerManager { get; }
        private HubConnection NotificationHubConnection { get; set; }
        private IHubProxy NotificationHubProxy { get; set; }


        public MainWindowModel()
        {
            notificationManagerManager = new NotificationManager();
            NotificationHubConnection = new HubConnection(AppConfiguration.NotificationHub_Url);
            NotificationHubProxy = NotificationHubConnection.CreateHubProxy(AppConfiguration.NotificationHub_Name);
            NotificationHubProxy.On<List<UserTaskDto>>(AppConfiguration.NotificationHub_Actions_UnReadNotifications, OnNotificationsArrival);
            NotificationHubConnection.Start().Wait();
        }

        private void OnNotificationsArrival(List<UserTaskDto> notifications)
        {
            Console.WriteLine(notifications.Count);
            if (notifications.Any())
            {
                PublishNotifications?.Invoke(this, notifications);
            }
        }

        public void Dispose()
        {
            NotificationHubConnection.Stop();
        }
    }
}
