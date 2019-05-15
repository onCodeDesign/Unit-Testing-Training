using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Samples._03_ConstructorInjection
{
    [TestClass]
    public class MapFileExistsTest
    {
        [TestMethod]
        public void ShowMapExistence_MapExists_ExistsMessageReturned()
        {
            IFileSystemGateway fileSystemStub = new FileSystemGatewayStub {Exist = true};
            MapFileExists target = new MapFileExists(fileSystemStub);

            string mapCode = "SomeMapCode";

            string actual = target.ShowMapExistence(mapCode);

            Assert.AreEqual("Kml file for Map SomeMapCode exists", actual);
        }

        [TestMethod]
        public void ShowMapExistence_MapNotExists_NotFoundMessageReturned()
        {
            FileSystemGatewayStub fileSystemStub = new FileSystemGatewayStub{Exist = false};
            MapFileExists target = new MapFileExists(fileSystemStub);

            string mapCode = "SomeMapCode";

            string actual = target.ShowMapExistence(mapCode);

            Assert.AreEqual("NOT found for Map SomeMapCode", actual);
        }

        class FileSystemGatewayStub : IFileSystemGateway
        {
            public bool FileExists(string mapFile)
            {
                return Exist;
            }

            public bool Exist { get; set; }
        }
    }
}