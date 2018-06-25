using System.IO;

namespace Samples._02_ExtractInterface
{
    class MapFileExists
    {
        public string ShowMapExistence(string mapCode)
        {
            string mapFile = mapCode + ".kml";

            IFileSystemGateway fileSystemGateway = new FileSystemGateway();
            if (fileSystemGateway.FileExists(mapFile))
                return $"Kml file for Map {mapCode} exists";
            else
                return $"NOT found for Map {mapCode}";
        }
    }

    internal interface IFileSystemGateway
    {
        bool FileExists(string mapFile);
    }

    internal class FileSystemGateway : IFileSystemGateway
    {
        public bool FileExists(string mapFile)
        {
            return File.Exists(mapFile);
        }
    }
}