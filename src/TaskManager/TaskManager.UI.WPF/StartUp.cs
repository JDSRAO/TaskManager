using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.UI.WPF
{
    internal static class StartUp
    {
        public static void Initialize()
        {
            var cwd = AppDomain.CurrentDomain.BaseDirectory;
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = $"{cwd}/TaskManager.NotificationHub.exe";
            start.WindowStyle = ProcessWindowStyle.Hidden;
            var serviceName = "Task Manager Notification Service";
            ServiceController service = new ServiceController(serviceName);
            if(service.Status != ServiceControllerStatus.Running)
            {
                service.Start();
            }
        }
    }
}
