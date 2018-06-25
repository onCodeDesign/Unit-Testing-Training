using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Samples.UnitTests.ContractTest
{
    [TestClass]
    public class XmlStringParserTests1
    {
        private XmlStringParser GetParser()
        {
            return new XmlStringParser();
        }

        [TestMethod]
        public void GetStringVersionFromHeader_SingleDigit_Found()
        {
            string input = @"<header version=""1"" />";
            XmlStringParser parser = GetParser();

            string versionFromHeader = parser.GetVersionFromHeader(input);

            Assert.AreEqual("1", versionFromHeader);
        }

        [TestMethod]
        public void GetStringVersionFromHeader_WithMinorVersion_Found()
        {
            string input = @"<header version=""1.1"" />";
            XmlStringParser parser = GetParser();

            //rest of the test
        }

        [TestMethod]
        public void GetStringVersionFromHeader_WithRevision_Found()
        {
            string input = @"<header version=""1.1.1"" />";
            XmlStringParser parser = GetParser();
            //rest of the test
        }

        [TestMethod]
        public void HasCorrectHeader_HeaderIsCorrect_ReturnsTrue()
        {
            string input = @"<header version=""1"" />";
            IStringParser parser = GetParser();
            bool result = parser.HasCorrectHeader(input);
            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void HasCorrectHeader_MissingVersionToken_ReturnsFalse()
        {
            string input = @"<header />";
            XmlStringParser parser = GetParser();
            //rest of the test
        }
    }
}