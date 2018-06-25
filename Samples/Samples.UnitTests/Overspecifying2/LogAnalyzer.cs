using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Samples.UnitTests.Overspecifying2
{
    public interface ILogProvider
    {
        int GetLineCount();
        string GetText(string fileName, int lineIndex1, int lineIndex2);
    }

    class LogAnalyzer
    {
        private readonly ILogProvider logProvider;

        public LogAnalyzer(ILogProvider logProvider)
        {
            this.logProvider = logProvider;
        }

        public AnalyzeResults AnalyzeFile(string filename)
        {
            int lineCount = logProvider.GetLineCount();
            string text = "";
            for (int i = 0; i < lineCount; i++)
            {
                string logLine = logProvider.GetText(filename, i + 1, i + 1);
                text = text + logLine;
                AnalyzeLine(logLine);
            }

            #region Open When Maintainability-Overspecifying, after first view

            //for (int i = 2; i < lineCount; i += 2) // read two lines at once
            //{
            //    string logLine = logProvider.GetText(filename, i - 1, i);
            //    text = text + logLine;
            //    AnalyzeLine(logLine);
            //}
            //if (lineCount % 2 == 1)
            //{
            //    string logLine = logProvider.GetText(filename, lineCount, lineCount);
            //    text = text + logLine;
            //    AnalyzeLine(logLine);
            //}

            #endregion

            return new AnalyzeResults(text);
        }

        private void AnalyzeLine(string logLine)
        {
        }
    }

    [TestClass]
    public class LogAnalyzerTests
    {
        [TestMethod]
        public void AnalyzeFile_FileWith3Line_CallLogProvider3Times()
        {
            Mock<ILogProvider> logProviderMock = new Mock<ILogProvider>();
            logProviderMock.Setup(l => l.GetLineCount()).Returns(3);
            logProviderMock.Setup(l => l.GetText("any file name", 1, 1)).Returns("A");
            logProviderMock.Setup(l => l.GetText("any file name", 2, 2)).Returns("B");
            logProviderMock.Setup(l => l.GetText("any file name", 3, 3)).Returns("C");

            LogAnalyzer target = new LogAnalyzer(logProviderMock.Object);

            target.AnalyzeFile("any file name");

            logProviderMock.Verify(l => l.GetText("any file name", 1, 1), Times.Once());
            logProviderMock.Verify(l => l.GetText("any file name", 2, 2), Times.Once());
            logProviderMock.Verify(l => l.GetText("any file name", 3, 3), Times.Once());
        }

        [TestMethod]
        public void AnalyzeFile_FileWith3Line_CallLogProvider3TimesLessBrittle()
        {
            Mock<ILogProvider> logProviderMock = new Mock<ILogProvider>();
            logProviderMock.Setup(l => l.GetLineCount()).Returns(3);
            logProviderMock.Setup(l => l.GetText(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                           .Returns("A");

            LogAnalyzer target = new LogAnalyzer(logProviderMock.Object);

            target.AnalyzeFile("any file name");

            logProviderMock.Verify(l => l.GetText("any file name", 1, 1), Times.Once());
            logProviderMock.Verify(l => l.GetText("any file name", 2, 2), Times.Once());
            logProviderMock.Verify(l => l.GetText("any file name", 3, 3), Times.Once());
        }

        [TestMethod]
        public void AnalyzeFile_FileWith3Line_CallLogProvider3TimesEvenLessBrittle()
        {
            Mock<ILogProvider> logProviderStub = new Mock<ILogProvider>();
            logProviderStub.Setup(l => l.GetLineCount()).Returns(3);
            logProviderStub.Setup(l => l.GetText(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                           .Returns<string, int, int>((s, i1, i2) => new string('A', i2 - i1 + 1));

            LogAnalyzer target = new LogAnalyzer(logProviderStub.Object);

            var result = target.AnalyzeFile("any file name");

            Assert.AreEqual("AAA", result.AllLines);
        }
    }
}