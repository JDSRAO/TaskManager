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
        private TaskManagerService taskManager { get; }

        public TaskListViewModel()
        {
            taskManager = new TaskManagerService();
            GetTasks();
            StartTaskCommand = new RelayCommand(StartTask);
            PauseTaskCommand = new RelayCommand(PauseTask);
            EndTaskCommand = new RelayCommand(StopTask);
        }

        private void StartTask(object obj)
        {
            var id = (Guid)obj;
            taskManager.ResumeTask(id);
        }

        private void PauseTask(object obj)
        {
            var id = (Guid)obj;
            taskManager.PauseTask(id);
        }

        private void StopTask(object obj)
        {
            var id = (Guid)obj;
            taskManager.EndTask(id);
        }

        private void GetTasks()
        {
            Tasks = taskManager.GetTasks().Where(x => x.IsEnded != true).OrderByDescending(x => x.TargetDate).ToList();
        }

        public void Refresh()
        {
            GetTasks();
        }
    }
}
