using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Samples.UnitTests.ContractTest
{
    [TestClass]
    public class XmlStringParserTests2 : BaseStringParserTests
    {
        protected override IStringParser GetParser()
        {
            return new XmlStringParser();
        }

        protected override string GetInputWithCorrectHeaderAndVersion(string versionNumber)
        {
            return $"<header version={versionNumber} />";
        }

        [TestMethod]
        public override void HasCorrectHeader_MissingVersionNode_ReturnsFalse()
        {
            string input = "<header />";
            IStringParser parser = GetParser();
            //rest of the test
        }
    }
}