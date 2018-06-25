using System;
using System.Collections.Generic;
using System.Linq;

namespace Samples.UnitTests.AbstractClassTesting
{
    abstract class LogParser
    {
        private IEnumerable<string> logTraces; // this is somehow given 

        protected abstract string GetVersion(string logTrace);
        protected abstract DateTime GetTime(string logTrace);
        protected abstract int GetSeverity(string logTrace);

        public IEnumerable<LogEntry> GetAllLogEntries()
        {
            foreach (var logTrace in logTraces)
            {
                yield return new LogEntry
                    {
                        Time = GetTime(logTrace),
                        Severity = GetSeverity(logTrace),
                        Version = GetVersion(logTrace),
                        Body = logTrace
                    };
            }
        }

        public IEnumerable<LogEntry> GetCriticalLogEntries()
        {
            return GetAllLogEntries().Where(l => l.Severity > 10);
        }
    }


	

   
}
