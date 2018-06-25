using System.IO;

namespace Samples._01_NotTestable2
{
    internal class MapFileExists
    {
        public string ShowMapExistence(string mapCode)
        {
            string mapFile = mapCode + ".kml";
            
            FileSystemGateway fileSystemGateway = new FileSystemGateway();
            if (fileSystemGateway.FileExists(mapFile))
                return $"Kml file for Map {mapCode} exists";
            else
                return $"NOT found for Map {mapCode}";
        }
    }

    internal class FileSystemGateway
    {
        public bool FileExists(string mapFile)
        {
            return File.Exists(mapFile);
        }
    }
}