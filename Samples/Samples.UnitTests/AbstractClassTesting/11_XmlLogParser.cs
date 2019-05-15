using System;

namespace Samples.UnitTests.AbstractClassTesting
{
	class XmlLogParser : LogParser
	{
        public XmlLogParser(ILogReader logReader) : base(logReader)
        {
        }

        protected override string GetVersion(string logTrace)
        {
            return "1";
        }

        protected override DateTime GetTime(string logTrace)
		{
			throw new NotImplementedException();
		}

        protected override int GetSeverity(string logTrace)
		{
			throw new NotImplementedException();
		}
    }

	
}