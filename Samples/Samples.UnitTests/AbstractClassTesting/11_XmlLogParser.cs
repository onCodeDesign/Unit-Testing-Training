using System;

namespace Samples.UnitTests.AbstractClassTesting
{
	class XmlLogParser : LogParser
	{
		protected override string GetVersion(string logTrace)
		{
			throw new NotImplementedException();
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