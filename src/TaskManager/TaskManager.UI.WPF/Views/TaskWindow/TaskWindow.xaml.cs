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
using System.Windows.Shapes;
using TaskManager.Models.DTO;

namespace TaskManager.UI.WPF.Views.TaskWindow
{
    /// <summary>
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        private TaskWindowModel context;

        public TaskWindow(UserTaskDto task = null)
        {
            if (task == null)
            {
                IsEditMode = false;
                context = new TaskWindowModel();
                DataContext = context;
            }
            else
            {
                IsEditMode = true;
                context = new TaskWindowModel(task);
                DataContext = context;
            }

            InitializeComponent();
            SetTitle();
            SetVisibilityOfButtons();
        }

        private void SetVisibilityOfButtons()
        {
            if (IsEditMode)
            {
                Btn_AddTask.Visibility = Visibility.Collapsed;
            }
            else
            {
                Btn_UpdateTask.Visibility = Visibility.Collapsed;
            }
        }

        private void SetTitle()
        {
            if (IsEditMode)
            {
                Title = "Edit Task";
            }
            else
            {
                Title = "Add Task";
            }
        }

        private bool IsEditMode { get; }

        private void Btn_AddTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var context = (TaskWindowModel)DataContext;
                context.AddTaskCommand.Execute(null);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while adding task");
            }
        }
    }
}
