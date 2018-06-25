using System;
using System.Collections.Generic;
using System.Linq;
using Samples.UnitTests.AbstractClassTesting;

namespace Samples.UnitTests.AbstractClassTesting3
{
    internal class LogParser
    {
        private IEnumerable<string> logTraces; // this is somehow given 
        private readonly ILogFormatReader formatReader;

        public LogParser(ILogFormatReader formatReader)
        {
            this.formatReader = formatReader;
        }

        public IEnumerable<LogEntry> GetAllLogEntries()
        {
            foreach (var logTrace in logTraces)
            {
                yield return new LogEntry
                {
                    Time = formatReader.GetTime(logTrace),
                    Severity = formatReader.GetSeverity(logTrace),
                    Version = formatReader.GetVersion(logTrace),
                    Body = logTrace
                };
            }
        }

        public IEnumerable<LogEntry> GetCriticalLogEntries()
        {
            return GetAllLogEntries().Where(l => l.Severity > 10);
        }
    }

    internal interface ILogFormatReader
    {
        string GetVersion(string logTrace);
        DateTime GetTime(string logTrace);
        int GetSeverity(string logTrace);
    }


    internal class XmlReader : ILogFormatReader
    {
        public string GetVersion(string logTrace)
        {
            throw new NotImplementedException();
        }

        public DateTime GetTime(string logTrace)
        {
            throw new NotImplementedException();
        }

        public int GetSeverity(string logTrace)
        {
            throw new NotImplementedException();
        }
    }

    internal class CsvReader : ILogFormatReader
    {
	    public string GetVersion(string logTrace)
	    {
		    throw new NotImplementedException();
	    }

	    public DateTime GetTime(string logTrace)
	    {
		    throw new NotImplementedException();
	    }

	    public int GetSeverity(string logTrace)
	    {
		    throw new NotImplementedException();
	    }
    }
}