namespace Samples.UnitTests.ContractTest
{
    public interface IStringParser
    {
        /// <summary>
        /// Get the version from the header
        /// </summary>
        string GetVersionFromHeader(string input);
        
        /// <summary>
        /// Returns true if the header has a correct format
        /// </summary>
        bool HasCorrectHeader(string input);

        //... other functions
    }
}