namespace Samples.UnitTests.ContractTest
{
    /// <summary>
    /// A parser for XML format
    /// </summary>
    sealed class XmlStringParser : IStringParser
    {
        public string GetVersionFromHeader(string input)
        {
            //TODO: implement this
            return input;
        }

        public bool HasCorrectHeader(string input)
        {
            //TODO implement this
            return true;
        }
    }
}