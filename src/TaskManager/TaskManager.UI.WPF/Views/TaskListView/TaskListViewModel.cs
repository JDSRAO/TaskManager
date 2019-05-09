using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Business;
using TaskManager.Models.DTO;

namespace TaskManager.UI.WPF.Views.TaskListView
{
    public class TaskListViewModel
    {
        public List<UserTaskDto> Tasks { get; set; }

        private TaskManagerService taskManager = new TaskManagerService();

        public TaskListViewModel()
        {
            Tasks = taskManager.GetTasks().OrderByDescending(x => x.TargetDate).ToList();
        }
    }
}
