using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager.Business;
using TaskManager.Models.DTO;
using TaskManager.UI.WPF.Commands;

namespace TaskManager.UI.WPF.Views.TaskListView
{
    public class TaskListViewModel
    {
        public List<UserTaskDto> Tasks { get; set; }
        public ICommand StartTaskCommand { get; set; }
        public ICommand PauseTaskCommand { get; set; }
        public ICommand EndTaskCommand { get; set; }
        public ICommand DeleteTaskCommand { get; set; }

        public event EventHandler ActionExecuted;

        private TaskManagerService taskManager { get; }

        public TaskListViewModel()
        {
            taskManager = new TaskManagerService();
            GetTasks();
            StartTaskCommand = new RelayCommand(StartTask);
            PauseTaskCommand = new RelayCommand(PauseTask);
            EndTaskCommand = new RelayCommand(EndTask);
            DeleteTaskCommand = new RelayCommand(DeleteTask);
        }

        public void Refresh()
        {
            GetTasks();
        }

        private void StartTask(object obj)
        {
            var id = (Guid)obj;
            taskManager.ResumeTask(id);
            Notify();
        }

        private void PauseTask(object obj)
        {
            var id = (Guid)obj;
            taskManager.PauseTask(id);
            Notify();
        }

        private void EndTask(object obj)
        {
            var id = (Guid)obj;
            taskManager.EndTask(id);
            Notify();
        }

        private void DeleteTask(object obj)
        {
            var id = (Guid)obj;
            taskManager.DeleteTask(id);
            Notify();
        }

        private void GetTasks(bool isEnded = false)
        {
            Tasks = taskManager.GetTasks(x => x.IsEnded == isEnded).OrderByDescending(x => x.TargetDate).ToList();
        }

        private void Notify()
        {
            ActionExecuted?.Invoke(this, new EventArgs());
        }

        
    }
}
