using System.IO;

namespace Samples._11_StubVsMock
{
    interface IFileWriter
    {
        void WriteLine(string line);
    }

    class FileWriter : IFileWriter
	{
		private readonly string fileName;

		public FileWriter(string fileName)
		{
			this.fileName = fileName;
		}

		public void WriteLine(string line)
		{
			using (StreamWriter sw = File.AppendText(fileName))
			{
				sw.WriteLine(line);
			}
		}
	}
}