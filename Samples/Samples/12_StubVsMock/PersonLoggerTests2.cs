using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Samples._12_StubVsMock
{
    [TestClass]
    public class PersonLoggerTests2
    {
        [TestMethod]
        public void Log_CannotWriteOnDisk_EmailSent()
        {
            EmailServiceMock emailMock = new EmailServiceMock();
            FileWriterStub fileWriterStub = new FileWriterStub();

            PersonLogger target = new PersonLogger(fileWriterStub, emailMock);
            target.Log(new Person(), "some message");

            Assert.IsTrue(emailMock.WasCalled);
        }
    }

    public class FileWriterStub : IFileWriter
    {
        public void WriteLine(string line)
        {
            throw new IOException();
        }
    }

    public class EmailServiceMock : IEmailService
    {

        public void SendMessage(string message)
        {
            WasCalled = true;
        }

        public bool WasCalled { get; set; } = false;
    }
}