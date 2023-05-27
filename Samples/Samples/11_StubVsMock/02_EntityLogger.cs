using Samples._11_StubVsMock2;

namespace Samples._11_StubVsMock
{
    class EntityLogger
    {
        private readonly IFileWriterFactory fileWriterFactory;

        public EntityLogger()
        {
            fileWriterFactory = new FileWriterFactory();
        }

        public EntityLogger(IFileWriterFactory fileWriterFactory)
        {
            this.fileWriterFactory = fileWriterFactory;
        }

        public void Log<T>(T entity, string message) where T : IEntity
        {
            IFileWriter fileWriter = fileWriterFactory.GetNewWriter($"{typeof(T).Name}AuditLog.txt");
            
            fileWriter.WriteLine($"Name: {entity.Name} | Message: {message}");
        }
    }
}