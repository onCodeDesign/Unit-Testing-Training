using System.IO;

namespace Samples._04_PropertyInjection
{
    internal class MapFileEixsts
    {
        private IFileSystemGateway fileSystem = null;//= new FileSystemGateway();

        public IFileSystemGateway FileSystem
        {
            get { return fileSystem; }
            set { fileSystem = value; }
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

    public interface IFileSystemGateway
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