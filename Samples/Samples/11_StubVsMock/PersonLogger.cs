namespace Samples._11_StubVsMock
{
    class PersonLogger
    {
        private readonly IFileWriterFactory fileWriterFactory;

        public PersonLogger()
        {
            fileWriterFactory = new FileWriterFactory();
        }

        public PersonLogger(IFileWriterFactory fileWriterFactory)
        {
            this.fileWriterFactory = fileWriterFactory;
        }

        public void Log(Person p, string message)
        {
            IFileWriter fileWriter = fileWriterFactory.GetNewWriter("LogFile");
            
            fileWriter.WriteLine($"Person: {p.Name} | Message: {message}");
        }
    }
}