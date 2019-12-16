using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;


namespace Dll.log4c
{
    public static class Log4C
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(Log4C));

        static Log4C() {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4C/log4net.config"));
        }



//        LogHelper.Debug(string.Format("已删除日志。{0}", info.Name));
//            Log4C.log.Debug("Starting up");
//            Log4C.log.Debug("Shutting down");
    }
}