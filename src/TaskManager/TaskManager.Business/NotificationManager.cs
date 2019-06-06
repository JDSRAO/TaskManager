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
        private TaskDataContext context { get; }

        public NotificationManager()
        {
            context = new TaskDataContext();
        }

        public List<UserTaskDto> GetNotifications(DateTime? dateTime = null)
        {
            var currentTime = dateTime ?? DateTime.Now;
            var upperLimit = currentTime.AddHours(-1);
            var notifications = context.UserTasks.Where(x => x.TargetDate < currentTime && x.TargetDate > upperLimit).ToList();
            var notificationsDto = DataMapper.Convert<List<UserTaskDto>>(notifications);
            return notificationsDto;
        }

    }
}
