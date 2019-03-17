using System.Configuration;

namespace EmailQueueApp.Bootstrap
{
    public static class AppConfigurationHelper
    {
        public static string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
