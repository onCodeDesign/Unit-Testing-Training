using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Samples.UnitTests.AbstractClassTesting
{
	internal class CsvLogParser : LogParser
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

	[TestClass]
	public class CsvLogParserTests
	{
		[TestMethod]
		public void GetVersion_MinorVersionInCorrectFormat_MinorVersionParsed()
		{
			Assert.Fail("Not yet implemented");
		}

		class TestableCsvLogParser : CsvLogParser
		{
			public string TestGetVersion(string logTrace)
			{
				return base.GetVersion(logTrace);
			}
		}
	}
}