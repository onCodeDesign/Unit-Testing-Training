using System;

namespace Samples.UnitTests.AbstractClassTesting
{
    internal class LogEntry 
    {
        public DateTime Time { get; set; }
        public int Severity { get; set; }
        public string Version { get; set; }
        public string Body { get; set; }
    }
}