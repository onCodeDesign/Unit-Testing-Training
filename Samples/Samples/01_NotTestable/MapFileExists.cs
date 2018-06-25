using System.IO;

namespace Samples._01_NotTestable
{
    class MapFileExists
    {
        public string ShowMapExistence(string  mapCode)
        {
            string mapFile = mapCode + ".kml";
            if (File.Exists(mapFile))
                return $"Kml file for Map {mapCode} exists";
            else
                return $"NOT found for Map {mapCode}";
        }
        
    }
}