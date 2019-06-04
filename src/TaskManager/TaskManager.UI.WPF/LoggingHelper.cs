using log4net;
using Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.UI.WPF
{
    internal class LoggingHelper
    {
        public static ILog GetLogger<T>()
        {
           return AppLogger.GetLogger<T>();
        }
    }
}
