using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Samples.UnitTests.Overspecifying1
{
    internal class MyClass
    {
        [TestMethod]
        public void Initialize_WhenCalled_SetsDefaultDelimiterIsTabDelimiter()
        {
            LogAnalyzer log = new LogAnalyzer();
            Assert.AreEqual(null, log.GetInternalDefaultDelimiter());
            
            log.Initialize();
            
            Assert.AreEqual('\t', log.GetInternalDefaultDelimiter());
        }
    }
}
