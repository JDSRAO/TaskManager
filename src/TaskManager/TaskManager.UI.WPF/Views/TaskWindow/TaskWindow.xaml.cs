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

namespace TaskManager.UI.WPF.Views.TaskWindow
{
    /// <summary>
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {        
        public TaskWindow(bool isEditMode = false)
        {
            IsEditMode = isEditMode;
            SetTitle();
            InitializeComponent();
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
