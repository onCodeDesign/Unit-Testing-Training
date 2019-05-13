using System.Collections.Generic;

namespace Samples.UnitTests.AbstractClassTesting
{
    interface ILogReader
    {
        IEnumerable<string> GetTraces();
    }
}