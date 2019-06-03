using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class AppLogger 
    {
        public static void ConfigureFileAppender(string logFile, bool isRollingFile = false)
        {
            IAppender fileAppender = null;
            var fileName = $"{Directory.GetCurrentDirectory()}/logs/{logFile}";
            fileAppender = (isRollingFile ? GetRollingFileAppender(fileName) : GetFileAppender(fileName));
            BasicConfigurator.Configure(fileAppender);
            ((Hierarchy)LogManager.GetRepository()).Root.Level = Level.Debug;
        }

        private static IAppender GetFileAppender(string logFile)
        {
            var layout = new PatternLayout("%date{MMM/dd/yyyy HH:mm:ss,fff} [%thread] %-5level %logger - %message%newline");
            layout.ActivateOptions(); // According to the docs this must be called as soon as any properties have been changed.

            var appender = new FileAppender
            {
                File = logFile,
                Encoding = Encoding.UTF8,
                Threshold = Level.Debug,
                Layout = layout
            };

            appender.ActivateOptions();

            return appender;
        }

        private static IAppender GetRollingFileAppender(string logFile)
        {
            var layout = new PatternLayout("%date{MMM/dd/yyyy HH:mm:ss,fff} [%thread] %-5level %logger - %message%newline");
            layout.ActivateOptions(); // According to the docs this must be called as soon as any properties have been changed.

            RollingFileAppender roller = new RollingFileAppender
            {
                AppendToFile = false,
                File = logFile,
                Layout = layout,
                MaxSizeRollBackups = 5,
                MaximumFileSize = "1GB",
                RollingStyle = RollingFileAppender.RollingMode.Size,
                StaticLogFileName = true
            };
            
            roller.ActivateOptions();

            return roller;
        }

        public void Configure(Assembly sourceAssembly, ILoggerRepository targetRepository)
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%date{MMM/dd/yyyy HH:mm:ss,fff} [%thread] %-5level %logger - %message%newline";
            patternLayout.ActivateOptions();

            RollingFileAppender roller = new RollingFileAppender();
            roller.AppendToFile = false;
            roller.File = $"{Directory.GetCurrentDirectory()}/logs.log";
            roller.Layout = patternLayout;
            roller.MaxSizeRollBackups = 5;
            roller.MaximumFileSize = "1GB";
            roller.RollingStyle = RollingFileAppender.RollingMode.Size;
            roller.StaticLogFileName = true;
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);

            MemoryAppender memory = new MemoryAppender();
            memory.ActivateOptions();
            hierarchy.Root.AddAppender(memory);

            hierarchy.Root.Level = Level.Info;
            hierarchy.Configured = true;
        }

        public static ILog GetLogger<T>()
        {
            return LogManager.GetLogger(typeof(T));
        }
    }
}
