using System.IO;

namespace Samples._05_StubBeforeMethodCall
{
    class MapFileExists
    {
        private readonly IFileSystemGateway fileSystem;

        public MapFileExists()
        {
            fileSystem = FileSystemGatewayFactory.Create(); // there is a dependency on the FileSystemGatewayFactory
        }

        public string ShowMapExistence(string mapCode)
        {
            string mapFile = mapCode + ".kml";
            
            // a call to the factory method could be done here. The difference is that new instances will created for each call.
            if (fileSystem.FileExists(mapFile))
                return string.Format("Kml file for Map {0} exists", mapCode);
            else
                return string.Format("NOT found for Map {0}", mapCode);
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
        private static IFileSystemGateway m_FileSystemGateway;

        public static IFileSystemGateway Create()
        {
            if (m_FileSystemGateway == null)
                return new FileSystemGateway();

            return m_FileSystemGateway;
        }

        public static void SetInstance(IFileSystemGateway instance)
        {
            m_FileSystemGateway = instance;
        }
    }
}