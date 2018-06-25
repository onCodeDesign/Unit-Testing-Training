namespace Samples.UnitTests.ContractTest
{
    /// <summary>
    /// A parser for a custom string format, based on keywords and semicolon separator
    /// </summary>
    public sealed class StandardStringParser : IStringParser
    {
        public string GetVersionFromHeader(string input)
        {
            //TODO: implement this
            return input;
        }

        public bool HasCorrectHeader(string input)
        {
            //TODO: implement this
            return true;
        }
    }
}