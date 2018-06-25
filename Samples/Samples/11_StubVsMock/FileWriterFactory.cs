namespace Samples._11_StubVsMock
{
	class FileWriterFactory : IFileWriterFactory
	{
		public IFileWriter GetNewWriter(string fileName)
		{
			return new FileWriter(fileName);
		}
	}
}