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
    public class TaskWindowModel
    {
        public Guid ID
        {
            get => id;
            set { id = value; }
        }

        public string Title
        {
            get => title;
            set { title = value; }
        }

        public string Description
        {
            get => description;
            set { description = value; }
        }

        public DateTime StartDate
        {
            get => startDate;
            set { startDate = value; }
        }

        public DateTime TargetDate
        {
            get => targetDate;
            set { targetDate = value; }
        }

        public ICommand AddTaskCommand
        {
            get;
            set;
        }

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
