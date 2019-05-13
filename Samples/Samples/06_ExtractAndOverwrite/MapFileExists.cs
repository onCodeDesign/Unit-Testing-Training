using System.IO;

namespace Samples._06_ExtractAndOverwrite
{
    class MapFileExists
    {
        protected virtual bool FileExists(string mapFile)
        {
            return File.Exists(mapFile);
        }

        public string ShowMapExistence(string mapCode)
        {
            string mapFile = mapCode + ".kml";
            if (FileExists(mapFile))
                return $"Kml file for Map {mapCode} exists";
            else
                return $"NOT found for Map {mapCode}";
        }
    }
}