using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Samples.UnitTests.AbstractClassTesting
{
    [TestClass]
    public class XmlParserTests
    {
        [TestMethod]
        public void GetVersion_SingleDigit_Found()
        {
            string logTrace = "<header version=1 />";
            TestableXmlParser parser = new TestableXmlParser();

            string version = parser.TestGetVersion(logTrace);

            Assert.AreEqual("1", version);
        }

        class TestableXmlParser : XmlLogParser
        {
            public TestableXmlParser() : base(new Mock<ILogReader>().Object)
            {
            }

            public string TestGetVersion(string logTrace)
            {
                return GetVersion(logTrace);
            }
        }
    }
}