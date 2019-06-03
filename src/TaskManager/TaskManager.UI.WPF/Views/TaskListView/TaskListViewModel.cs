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

namespace TaskManager.UI.WPF.Views.TaskListView
{
    public class TaskListViewModel
    {
        public ObservableCollection<UserTaskDto> Tasks { get; set; }
        public ICommand StartTaskCommand { get; set; }
        public ICommand PauseTaskCommand { get; set; }
        public ICommand EndTaskCommand { get; set; }
        public ICommand DeleteTaskCommand { get; set; }
        public ICommand SearchTasksCommand { get; set; }

        public string SearchQuery
        {
            get => searchQuery;
            set { searchQuery = value; }
        }

        public event EventHandler ActionExecuted;

        private TaskManagerService taskManager { get; }
        private string searchQuery { get; set; }

        public TaskListViewModel()
        {
            taskManager = new TaskManagerService();
            GetTasks();
            StartTaskCommand = new RelayCommand(StartTask);
            PauseTaskCommand = new RelayCommand(PauseTask);
            EndTaskCommand = new RelayCommand(EndTask);
            DeleteTaskCommand = new RelayCommand(DeleteTask);
            SearchTasksCommand = new RelayCommand(SearchTasks);
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

        private void SearchTasks(object obj)
        {
            var query = searchQuery.ToLower();
            var tasks = taskManager.GetTasks(x => x.Title.ToLower().Contains(query) || x.Description.ToLower().Contains(query)).OrderByDescending(x => x.TargetDate).ToList();
            Tasks = new ObservableCollection<UserTaskDto>(tasks);
        }

        private void GetTasks(bool isEnded = false)
        {
            var tasks = taskManager.GetTasks(x => x.IsEnded == isEnded).OrderByDescending(x => x.TargetDate).ToList();
            Tasks = new ObservableCollection<UserTaskDto>(tasks);
        }

        private void Notify()
        {
            ActionExecuted?.Invoke(this, new EventArgs());
        }

        
    }
}
