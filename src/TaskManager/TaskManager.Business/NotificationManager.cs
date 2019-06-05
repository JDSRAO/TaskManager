using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TaskManager.Data;
using TaskManager.Models;
using TaskManager.Models.DTO;

namespace TaskManager.Business
{
    public class NotificationManager : BaseManager
    {
        public event EventHandler<List<UserTaskDto>> Notifications;

        private TaskDataContext context { get; }
        private Timer timer { get; }

        public NotificationManager()
        {
            context = new TaskDataContext();
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(PushNotificationsToClient);
            timer.Interval = 5000;
            timer.Enabled = true;
        }

        public List<UserTaskDto> GetNotifications(DateTime? dateTime = null)
        {
            var currentTime = dateTime ?? DateTime.Now;
            var notifications = context.UserTasks.Where(x => (x.TargetDate - currentTime).Minutes <= 30).ToList();
            var notificationsDto = DataMapper.Convert<List<UserTaskDto>>(notifications);
            return notificationsDto;
        }

        private void PushNotificationsToClient(object sender, ElapsedEventArgs e)
        {
            var notifications = GetNotifications();
            Notifications?.Invoke(this, notifications);
        }
    }
}
