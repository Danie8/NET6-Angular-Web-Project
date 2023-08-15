using log4net;
using log4net.Repository;
using log4net.Config;

namespace NET6_Angular_Web_Project
{


    public static class Log4netConfiguration
    {
        private static readonly ILog log = LogManager.GetLogger("Debug");
        private static readonly ILoggerRepository logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());

        public static void Configure()
        {
            var log4NetConfigFile = new FileInfo("log4net.config");
            XmlConfigurator.Configure(logRepository, log4NetConfigFile);
            log.Info("log4net configured successfully.");
        }
    }
}
