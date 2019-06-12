using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager.Business;
using TaskManager.Models.DTO;
using TaskManager.UI.WPF.Commands;

namespace TaskManager.UI.WPF.Views.NotificationWindow
{
    public class NotificationWindowModel : BaseViewModel
    {
        public ICommand SnoozeTaskCommand { get; set; }

        public ObservableCollection<UserTaskDto> Tasks
        {
            get => tasks;
            set
            {
                tasks = value;
                OnPropertyChanged("Tasks");
            }
        }

        private TaskManagerService taskManager { get; }
        private ObservableCollection<UserTaskDto> tasks { get; set; }

        public NotificationWindowModel(List<UserTaskDto> notifications)
        {
            taskManager = new TaskManagerService();
            SnoozeTaskCommand = new RelayCommand(SnoozeTask);
            SetTasks(notifications);
        }

        public void UpdateNotifications(List<UserTaskDto> notifications)
        {
            notifications.ForEach((x) => 
            {
                if(tasks.Where(a => a.ID == x.ID).Count() == 0)
                {
                    tasks.Add(x);
                }
            });
            OnPropertyChanged("Tasks");
        }

        private void SnoozeTask(object obj)
        {
        }

        private void SetTasks(List<UserTaskDto> newTasks)
        {
            tasks = new ObservableCollection<UserTaskDto>(newTasks);
            OnPropertyChanged("Tasks");
        }
    }
}
