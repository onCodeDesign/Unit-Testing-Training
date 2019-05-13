using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Samples.UnitTests.ContractTest
{
    [TestClass]
    public class StandardStringParserTests1
    {
        private StandardStringParser GetParser()
        {
            return new StandardStringParser();
        }

        [TestMethod]
        public void GetStringVersionFromHeader_SingleDigit_Found()
        {
            string input = @"header;version=1;\n";
            StandardStringParser parser = GetParser();

            string versionFromHeader = parser.GetVersionFromHeader(input);

            Assert.AreEqual("1", versionFromHeader);
        }

        [TestMethod]
        public void GetStringVersionFromHeader_WithMinorVersion_Found()
        {
            string input = @"header;version=1.1;\n";
            StandardStringParser parser = GetParser();

            //rest of the test
        }

        [TestMethod]
        public void GetStringVersionFromHeader_WithRevision_Found()
        {
            string input = @"header;version=1.1.1;\n";
            StandardStringParser parser = GetParser();
            //rest of the test
        }


        [TestMethod]
        public void HasCorrectHeader_HeaderIsCorrect_ReturnsTrue()
        {
            string input = @"header;version=1.1.1;\n";
            StandardStringParser parser = GetParser();
            bool result = parser.HasCorrectHeader(input);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HasCorrectHeader_MissingVersionNode_ReturnsFalse()
        {
            string input = @"header; \n";
            StandardStringParser parser = GetParser();
            //rest of the test
        }

        [TestMethod]
        public void HasCorrectHeader_WithSpacesAroundSeparators_ReturnsTrue()
        {
            string input = "header ; version=1.1.1 ; \n";
            StandardStringParser parser = GetParser();
            //rest of the test
        }
    }
}

