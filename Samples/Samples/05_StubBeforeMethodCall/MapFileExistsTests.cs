using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Samples._05_StubBeforeMethodCall
{
    [TestClass]
    public class MapFileExistsTests
    {
        [TestMethod]
        public void ShowMapExistence_MapExists_ExistsMessageReturned()
        {
            FileSystemGatewayFactory.SetInstance(new FileSystemStub {Exist = true});
            MapFileExists target = new MapFileExists();

            string actual = target.ShowMapExistence("SomeMapCode");

            Assert.AreEqual("Kml file for Map SomeMapCode exists", actual);
        }

        class FileSystemStub : IFileSystemGateway
        {
            public bool FileExists(string mapFile)
            {
                return Exist;
            }

            public bool Exist { get; set; }
        }
    }
}