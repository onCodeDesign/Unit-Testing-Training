using System.IO;

namespace Samples._11_StubVsMock2
{
    class PersonLogger
    {
        public void Log(Person p, string message)
        {
            using (StreamWriter sw = File.AppendText("LogFile.txt"))
            {
                sw.WriteLine($"Person: {p.Name} | Message: {message}");
            }
        }
    }
}