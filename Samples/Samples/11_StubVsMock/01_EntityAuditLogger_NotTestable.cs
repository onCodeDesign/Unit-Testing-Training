using System.IO;

namespace Samples._11_StubVsMock2
{
    class EntityAuditLogger
    {
        public void Log<T>(T entity, string message) where T : IEntity
        {
            using (StreamWriter sw = File.AppendText($"{typeof(T).Name}AuditLog.txt"))
            {
                sw.WriteLine($"Name: {entity.Name} | Message: {message}");
            }
        }
    }
}