using System.IO;

namespace Samples._05_StubBeforeMethodCall
{
    class MapFileExists
    {
        public string ShowMapExistence(string mapCode)
        {
            string mapFile = mapCode + ".kml";

            IFileSystemGateway fileSystem = FileSystemGatewayFactory.Create(); // a new instance is created at each method call
            if (fileSystem.FileExists(mapFile))
                return $"Kml file for Map {mapCode} exists";
            else
                return $"NOT found for Map {mapCode}";
        }
    }

    internal class FileSystemGateway : IFileSystemGateway
    {
        public bool FileExists(string mapFile)
        {
            return File.Exists(mapFile);
        }
    }

    public interface IFileSystemGateway
    {
        bool FileExists(string mapFile);
    }


    static class FileSystemGatewayFactory
    {
        private static IFileSystemGateway fileSystemGateway;

        public static IFileSystemGateway Create()
        {
            if (fileSystemGateway == null)
                return new FileSystemGateway();

            return fileSystemGateway;
        }

        public static void SetInstance(IFileSystemGateway instance)
        {
            fileSystemGateway = instance;
        }
    }
}