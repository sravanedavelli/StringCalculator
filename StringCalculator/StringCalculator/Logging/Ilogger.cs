using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Logging
{
    public interface Ilogger
    {
        void Debug(object log);
        void DebugFormat(string log, params object[] args);
        void Info(object log);
        void InfoFormat(string log, params object[] args);
        void Warn(object log);
        void WarnFormat(string log, params object[] args);
        void Error(object log);
        void ErrorFormat(string log, params object[] args);
        void Fatal(object log);
        void FatalFormat(string log, params object[] args);
    }
}
