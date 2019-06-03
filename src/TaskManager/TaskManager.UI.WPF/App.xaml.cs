using log4net;
using Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TaskManager.UI.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ILog Logger = AppLogger.GetLogger<App>();

        public App()
        {
            AppLogger.ConfigureFileAppender("AppLogs", true);

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Logger.Info("App started");
            base.OnStartup(e);
            SetupExceptionHandling();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Logger.Info("App exited");
            base.OnExit(e);
        }

        private void SetupExceptionHandling()
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                LogUnhandledException((Exception)e.ExceptionObject, "AppDomain.CurrentDomain.UnhandledException");

            DispatcherUnhandledException += (s, e) =>
                LogUnhandledException(e.Exception, "Application.Current.DispatcherUnhandledException");

            TaskScheduler.UnobservedTaskException += (s, e) =>
                LogUnhandledException(e.Exception, "TaskScheduler.UnobservedTaskException");
        }

        private void LogUnhandledException(Exception exception, string source)
        {
            string message = $"Unhandled exception ({source})";
            try
            {
                System.Reflection.AssemblyName assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName();
                message = string.Format("Unhandled exception in {0} v{1}", assemblyName.Name, assemblyName.Version);
            }
            catch (Exception ex)
            {
                Logger.Error("Exception in LogUnhandledException", ex);
            }
            finally
            {
                Logger.Error(message, exception);
            }
        }
    }
}
