using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Samples.UnitTests.ContractTest
{
    [TestClass]
    public class StandardStringParserTests2 : BaseStringParserTests
    {
        protected override IStringParser GetParser()
        {
            return new StandardStringParser();
        }

        protected override string GetInputWithCorrectHeaderAndVersion(string versionNumber)
        {
            return $@"header;version={versionNumber};\n";
        }

        [TestMethod]
        public override void HasCorrectHeader_MissingVersionNode_ReturnsFalse()
        {
            string input = @"header; \n";
            IStringParser parser = GetParser();
            //rest of the test
        }

        //this test is specific to the StandardStringParser type
        [TestMethod]
        public void HasCorrectHeader_WithSpacesAroundSeparators_ReturnsTrue()
        {
            string input = @"header ; version=1.1.1 ; \n";
            IStringParser parser = GetParser();
            //rest of the test
        }
    }
}