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
    public class MainWindowModel : BaseViewModel
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
        private DispatcherTimer dispatcherTimer { get; set; }
        private NotificationManager notificationManagerManager { get; }

        public MainWindowModel()
        {
            notificationManagerManager = new NotificationManager();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            var startDate = Convert.ToDateTime("2019-05-31 17:00:00.433");
            var notifications = notificationManagerManager.GetNotifications(startDate);
            if(notifications.Any())
            {
                PublishNotifications?.Invoke(this, notifications);
            }
            Console.WriteLine("Notification triggered");
        }
    }
}
