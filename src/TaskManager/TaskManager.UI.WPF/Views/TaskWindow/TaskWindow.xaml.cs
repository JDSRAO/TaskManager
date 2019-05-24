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
                context = new TaskWindowModel
                {
                    StartDate = DateTime.Now,
                    TargetDate = DateTime.Now.AddDays(1)
                };
                DataContext = context;
            }
            else
            {
                IsEditMode = true;
                context = new TaskWindowModel
                {
                    ID = task.ID,
                    Title = task.Title,
                    Description = task.Description,
                    TargetDate = task.TargetDate,
                    StartDate = task.StartedAt
                };
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
    }
}
