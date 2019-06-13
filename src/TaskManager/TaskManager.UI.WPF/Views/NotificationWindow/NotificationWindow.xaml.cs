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
using System.Windows.Threading;
using TaskManager.Models.DTO;

namespace TaskManager.UI.WPF.Views.NotificationWindow
{
    /// <summary>
    /// Interaction logic for NotificationWindow.xaml
    /// </summary>
    public partial class NotificationWindow : Window
    {
        public NotificationWindow(List<UserTaskDto> notifications = null)
        {
            var context = new NotificationWindowModel(notifications);
            InitializeComponent();
            DataContext = context;
            Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() =>
            {
                var workingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                var transform = PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice;
                var corner = transform.Transform(new Point(workingArea.Right, workingArea.Bottom));

                this.Left = corner.X - this.ActualWidth - 100;
                this.Top = corner.Y - this.ActualHeight;
            }));
        }

        public void UpdateNotifications(List<UserTaskDto> notifications)
        {
            var context = (NotificationWindowModel)DataContext;
            context.UpdateNotifications(notifications);
        }

        private void SnoozeButton_Click(object sender, RoutedEventArgs e)
        {
            var currentTask = (UserTaskDto) tasks.SelectedItem;
        }
    }
}
