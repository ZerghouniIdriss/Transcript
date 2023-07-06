using Serilog;
using Serilog.Formatting.Compact;

namespace TransGr8_DD_Test.Common.Utilities
{
    public class Logger
    {
        private static Logger _instance;

        private Logger()
        {
            Log.Logger = new LoggerConfiguration()
             .WriteTo.Console()
             .CreateLogger();
        }

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }

        public void Information(string messageTemplate, params object[] propertyValues)
        {
            Log.Information(messageTemplate, propertyValues);
        }

        ~Logger()
        {
            Log.CloseAndFlush();
        }
    }
}
