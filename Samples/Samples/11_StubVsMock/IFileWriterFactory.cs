namespace Samples._11_StubVsMock
{
    internal interface IFileWriterFactory
    {
        IFileWriter GetNewWriter(string fileName);
    }
}