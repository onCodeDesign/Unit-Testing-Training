using System.IO;

namespace Samples._03_ConstructorInjection
{
    internal class MapFileExists
    {
        private readonly IFileSystemGateway fileSystem;

        public MapFileExists() //existent code will still use this constructor
        {
            fileSystem = new FileSystemGateway();
        }

        public MapFileExists(IFileSystemGateway fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        public string ShowMapExistence(string mapCode)
        {
            string mapFile = mapCode + ".kml";
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
}
