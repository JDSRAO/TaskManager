using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.Models.DTO;

namespace TaskManager.UI.WPF.Views.TaskListView
{
    /// <summary>
    /// Interaction logic for TaskListView.xaml
    /// </summary>
    public partial class TaskListView : UserControl
    {
        public TaskListView()
        {
            InitializeComponent();
            DataContext = new TaskListViewModel();
        }

        private void Tasks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = tasks.SelectedItem as UserTaskDto;
            var taskWindow = new TaskWindow.TaskWindow(selectedItem);
            taskWindow.ShowDialog();
        }

        private void Btn_ModifyTask_Click(object sender, RoutedEventArgs e)
        {
            var context = (TaskListViewModel)DataContext;
            var btn = sender as Button;
            Guid taskId = Guid.NewGuid();
            switch (btn.Name)
            {
                case "StartTask":
                    context.StartTaskCommand.Execute(taskId);
                    break;
                case "PauseTask":
                    context.PauseTaskCommand.Execute(taskId);
                    break;
                case "StopTask":
                    context.StartTaskCommand.Execute(taskId);
                    break;
                default:
                    break;
            }
        }
    }
}
