using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Samples._06_ExtractAndOverwrite
{
    [TestClass]
    public class MapFileEixstsTests
    {
        [TestMethod]
        public void ShowMapExistence_MapExists_ExistsMessageReturned()
        {
            MapFileEixsts target = new TestableMapFileExists {Exists = true};

            string actual = target.ShowMapExistence("SomeMapCode");

            Assert.AreEqual("Kml file for Map SomeMapCode exists", actual);
        }

        private class TestableMapFileExists : MapFileEixsts
        {
            protected override bool FileExists(string mapFile)
            {
                return Exists;
            }

            public bool Exists { get; set; }
        }
    }
}