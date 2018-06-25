namespace Samples.UnitTests.ContractTest
{
    /// <summary>
    /// A parser for IIS Logs which are given as text
    /// </summary>
    sealed class IisLogStringParser : IStringParser
    {
        public string GetVersionFromHeader(string input)
        {
            throw new System.NotImplementedException();
        }

        public bool HasCorrectHeader(string input)
        {
            throw new System.NotImplementedException();
        }
    }
}