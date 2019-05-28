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
            Tasks = taskManager.GetTasks().Where(x => x.IsEnded != true).OrderByDescending(x => x.TargetDate).ToList();
            StartTaskCommand = new RelayCommand(ModifyTask);
            PauseTaskCommand = new RelayCommand(ModifyTask);
            EndTaskCommand = new RelayCommand(ModifyTask);
        }

        private void ModifyTask(object obj)
        {
            Task.Run(() => 
            {
                Console.WriteLine("Async task");
            });
        }
    }
}
