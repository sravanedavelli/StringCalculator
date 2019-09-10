using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Logging
{
    public class Logging: Ilogger
    {
        private static ILog _BBVAStatementLog = log4net.LogManager.GetLogger("Job.BBVAStatements");

        static Logging()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static ILog BBVAStatementLog
        {
            get { return _BBVAStatementLog; }
        }

        private ILog _Logger;

        public Logging(ILog log)
        {
            this._Logger = log;
        }

        public void Debug(object log)
        {
            this._Logger.Debug(log);
        }

        public void DebugFormat(string log, params object[] args)
        {
            this._Logger.DebugFormat(log, args);
        }

        public void Error(object log)
        {
            this._Logger.Error(log);
        }

        public void ErrorFormat(string log, params object[] args)
        {
            this._Logger.ErrorFormat(log, args);
        }

        public void Fatal(object log)
        {
            this._Logger.Fatal(log);
        }

        public void FatalFormat(string log, params object[] args)
        {
            this._Logger.FatalFormat(log, args);
        }

        public void Info(object log)
        {
            this._Logger.Info(log);
        }

        public void InfoFormat(string log, params object[] args)
        {
            this._Logger.InfoFormat(log, args);
        }

        public void Warn(object log)
        {
            this._Logger.Warn(log);
        }

        public void WarnFormat(string log, params object[] args)
        {
            this._Logger.WarnFormat(log, args);
        }
    }
}
