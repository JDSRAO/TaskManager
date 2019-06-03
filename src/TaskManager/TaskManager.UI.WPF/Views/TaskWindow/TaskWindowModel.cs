using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager.Business;
using TaskManager.Models.DTO;
using TaskManager.UI.WPF.Commands;

namespace TaskManager.UI.WPF.Views.TaskWindow
{
    public class TaskWindowModel : BaseViewModel
    {
        public Guid ID
        {
            get => id;
            set { id = value; OnPropertyChanged("ID"); }
        }

        public string Title
        {
            get => title;
            set { title = value; OnPropertyChanged("Title"); }
        }

        public string Description
        {
            get => description;
            set { description = value; OnPropertyChanged("Description"); }
        }

        public DateTime StartDate
        {
            get => startDate;
            set { startDate = value; OnPropertyChanged("StartDate"); }
        }

        public DateTime TargetDate
        {
            get => targetDate;
            set { targetDate = value; OnPropertyChanged("TargetDate"); }
        }

        public ICommand AddTaskCommand { get; set; }

        public ICommand UpdateTaskCommand { get; set; }

        private Guid id { get; set; }
        private string title { get; set; }
        private string description { get; set; }
        private DateTime startDate { get; set; }
        private DateTime targetDate { get; set; }

        private TaskManagerService taskManager = new TaskManagerService();

        public TaskWindowModel(UserTaskDto task = null)
        {
            if(task != null)
            {
                ID = task.ID;
                Title = task.Title;
                Description = task.Description;
                TargetDate = task.TargetDate;
                StartDate = task.StartedAt;
            }
            else
            {
                startDate = DateTime.Now;
                TargetDate = DateTime.Now.AddDays(1);
            }

            AddTaskCommand = new RelayCommand(AddTask);
            UpdateTaskCommand = new RelayCommand(UpdateTask);
        }

        private void UpdateTask(object obj)
        {
            var task = new UserTaskDto
            {
                ID = id,
                Title = title,
                Description = description,
                StartedAt = startDate,
                TargetDate = targetDate
            };
            taskManager.UpdateTask(task);
        }

        private void AddTask(object obj)
        {
            var task = new UserTaskDto
            {
                Title = title,
                Description = description,
                StartedAt = startDate,
                TargetDate = targetDate
            };
            taskManager.AddTask(task);
        }
    }
}
