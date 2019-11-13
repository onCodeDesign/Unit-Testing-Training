using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Samples._04_PropertyInjection
{
    [TestClass]
    public class MapFileExistsTest
    {
        [TestMethod]
        public void ShowMapExistence_MapExists_ExistsMessageReturned()
        {
            IFileSystemGateway fakeFileSystemStub = new FakeFileSystemStub {Exist = true};
            MapFileEixsts target = new MapFileEixsts() {FileSystem = fakeFileSystemStub};

            string actual = target.ShowMapExistence("SomeMapCode");

            Assert.AreEqual("Kml file for Map SomeMapCode exists", actual);
        }

        class FakeFileSystemStub : IFileSystemGateway
        {
            public bool FileExists(string mapFile)
            {
                return Exist;
            }

            public bool Exist { get; set; }
        }
    }
}