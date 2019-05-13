using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Samples.UnitTests.AbstractClassTesting
{
    [TestClass]
    public class LogParserTests
    {
        [TestMethod]
        public void GetAllLogEntries_FileEmpty_NoEntriesAreReturned()
        {
            LogParser target = new TestableLogParser(new string[0]);

            var entries = target.GetAllLogEntries();

            int entriesCount = entries.Count();
            Assert.AreEqual(0, entriesCount);
        }

        [TestMethod]
        public void GetAllLogEntries_LogTraceHasSeverity_SeverityReturned()
        {
            TestableLogParser parser = new TestableLogParser(new []{"log line"});
            parser.Severity = 15;
            // rest of the arrange

            LogEntry returnedEntry = parser.GetAllLogEntries().First();
            
            Assert.AreEqual(15, returnedEntry.Severity);
        }

        class TestableLogParser : LogParser
        {
            public TestableLogParser(IEnumerable<string> traces) 
                : base(new LogReaderStub(traces))
            {
            }

            public string Version { get; set; }
            public DateTime DateTime { get; set; }
            public int Severity { get; set; }

            protected override string GetVersion(string logTrace)
            {
                return Version;
            }

            protected override DateTime GetTime(string logTrace)
            {
                return DateTime;
            }

            protected override int GetSeverity(string logTrace)
            {
                return Severity;
            }

            class LogReaderStub : ILogReader
            {
                private readonly IEnumerable<string> traces;

                public LogReaderStub(IEnumerable<string> traces)
                {
                    this.traces = traces;
                }

                public IEnumerable<string> GetTraces()
                {
                    return traces;
                }
            }
        }
    }
}