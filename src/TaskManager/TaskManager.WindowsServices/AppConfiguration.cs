using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.WindowsServices
{
    internal class AppConfiguration
    {
        public static string NotificationHub_Url { get; } = GetValueFromConfig("notificationHub:Url");
        public static string NotificationHub_Name { get; } = GetValueFromConfig("notificationHub:Name");
        public static string NotificationHub_Actions_PushNotifications { get; } = GetValueFromConfig("notificationHub:Actions:PushNotifications");
        public static string ApplicationLogFileName { get; } = GetValueFromConfig("logging:fileName");

        private static string GetValueFromConfig(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
