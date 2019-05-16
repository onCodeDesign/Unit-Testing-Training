using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Samples._12_StubVsMock
{
    [TestClass]
    public class PersonLoggerTests
    {
        [TestMethod]
        public void Log_IOException_SendEmail()
        {
            Mock<IFileWriter> fileWriterStub = new Mock<IFileWriter>();
            fileWriterStub.Setup(f => f.WriteLine(It.IsAny<string>()))
                .Throws(new IOException());

            Mock<IEmailService> emailServiceMock = new Mock<IEmailService>();

            PersonLogger target = new PersonLogger(fileWriterStub.Object, emailServiceMock.Object);

            target.Log(new Person(), "Some message");

            emailServiceMock.Verify(e => e.SendMessage(It.IsAny<string>()));
        }

        [TestMethod]
        public void Log_IOException_EmailFormatted()
        {
            Mock<IFileWriter> fileWriterStub = new Mock<IFileWriter>();
            fileWriterStub.Setup(f => f.WriteLine(It.IsAny<string>()))
                .Throws(new IOException());

            Mock<IEmailService> emailServiceMock = new Mock<IEmailService>();

            PersonLogger target = new PersonLogger(fileWriterStub.Object, emailServiceMock.Object);

            target.Log(new Person(), "Some message");

            const string expected = "Person: Florin Coroş | Message: CREATED";
            emailServiceMock.Verify(e => e.SendMessage(expected));
        }

        [TestMethod]
        public void Log_IOException_CorrectLogTrace()
        {
            Assert.Fail("Not yet implemented");
        }

        [TestMethod]
        public void Log_CanLogToFile_MessageLoggedInFile()
        {
            Mock<IFileWriter> fileWriterMock = new Mock<IFileWriter>();

            Mock<IEmailService> emailServiceStub = new Mock<IEmailService>();

            PersonLogger target = new PersonLogger(fileWriterMock.Object, emailServiceStub.Object);

            target.Log(new Person { Name = "Florin Coros" }, "CREATED");

            const string expected = "Person: Florin Coros | Message: CREATED";
            fileWriterMock.Verify(e => e.WriteLine(expected));
        }
    }
}