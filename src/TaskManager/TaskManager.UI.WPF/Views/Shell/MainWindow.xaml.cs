using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using TaskManager.UI.WPF.Views.Shell;
using TaskManager.UI.WPF.Views.TaskWindow;

namespace TaskManager.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetDataContext();
        }

        private void BtnAddTask_Click(object sender, RoutedEventArgs e)
        {
            var taskWindow = new TaskWindow();
            taskWindow.Closing += TaskWindow_Closing;
            taskWindow.ShowDialog();
        }

        private void TaskWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tasks.SetDataContext(); 
        }

        public void SetDataContext()
        {
            var context = new MainWindowModel();
            context.PublishNotifications += Context_PublishNotifications;
            DataContext = context;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            var context = (MainWindowModel) DataContext;
            context.Dispose();
            base.OnClosing(e);
        }

        private void Context_PublishNotifications(object sender, List<Models.DTO.UserTaskDto> e)
        {
            this.Dispatcher.Invoke(() => 
            {
                SetDataContext();
            });
        }
    }
}
