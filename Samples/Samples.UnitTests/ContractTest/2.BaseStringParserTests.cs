using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Samples.UnitTests.ContractTest
{
    [TestClass]
    public abstract class BaseStringParserTests
    {
        protected abstract IStringParser GetParser();

        protected abstract string GetInputWithCorrectHeaderAndVersion(string versionNumber);

        [TestMethod]
        public void GetStringVersionFromHeader_SingleDigit_Found()
        {
            const string version = "1";
            string input = GetInputWithCorrectHeaderAndVersion(version);
            IStringParser parser = GetParser();

            string versionFromHeader = parser.GetVersionFromHeader(input);

            Assert.AreEqual("1", versionFromHeader);
        }

        [TestMethod]
        public void GetStringVersionFromHeader_WithMinorVersion_Found()
        {
            const string version = "1.1";
            string input = GetInputWithCorrectHeaderAndVersion(version);
            IStringParser parser = GetParser();
            //...

        }

        [TestMethod]
        public void GetStringVersionFromHeader_WithRevision_Found()
        {
            const string version = "1.1";
            string input = GetInputWithCorrectHeaderAndVersion(version);
            IStringParser parser = GetParser();
            //...
        }

        [TestMethod]
        public void HasCorrectHeader_HeaderIsCorrect_ReturnsTrue()
        {
            const string version = "1.1.1";
            string input = GetInputWithCorrectHeaderAndVersion(version);
            IStringParser parser = GetParser();
            bool result = parser.HasCorrectHeader(input);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public abstract void HasCorrectHeader_MissingVersionNode_ReturnsFalse();
    }
}