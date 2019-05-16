using System.IO;

namespace Samples._12_StubVsMock
{
    public class PersonLogger
	{
		private readonly IFileWriter fileWriter;
		private readonly IEmailService emailService;

		public PersonLogger(IFileWriter fileWriter, IEmailService service)
		{
			this.fileWriter = fileWriter;
			emailService = service;
		}

		public void Log(Person person, string message)
		{
			string logLine = $"Person: {person.Name} | Message: {message}";
			try
			{
				fileWriter.WriteLine(logLine);
			}
			catch (IOException)
			{
				emailService.SendMessage(logLine);
			}
		}
	}

	public interface IEmailService
	{
		void SendMessage(string message);
	}

	public interface IFileWriter
	{
		void WriteLine(string line);
	}

	class FileWriter : IFileWriter
	{
		public void WriteLine(string line)
		{
			using (StreamWriter sw = File.AppendText("LogFile"))
			{
				sw.WriteLine(line);
			}
		}
	}
}