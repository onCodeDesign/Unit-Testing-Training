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

            #region Open When Maintainability-Overspecifying, after first view

            for (int i = 2; i < lineCount; i += 2) // read two lines at once
            {
                string logLine = logProvider.GetText(filename, i - 1, i);
                text = text + logLine;
                AnalyzeLine(logLine);
            }
            if (lineCount % 2 == 1)
            {
                string logLine = logProvider.GetText(filename, lineCount, lineCount);
                text = text + logLine;
                AnalyzeLine(logLine);
            }

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

            logProviderMock.Verify(l => l.GetText(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(3));
        }

        [TestMethod]
        public void AnalyzeFile_FileWith3Line_CallLogProvider3TimesEvenLessBrittle()
        {
            ILogProvider logProviderStub = new LogProviderDouble('A',3);
            LogAnalyzer target = new LogAnalyzer(logProviderStub);

            AnalyzeResults result = target.AnalyzeFile("any file name");

            Assert.AreEqual("AAA", result.AllLines);
        }


        class LogProviderDouble : ILogProvider
        {
            private readonly char simChar;
            private int count;

            public LogProviderDouble(char simChar, int count)
            {
                this.simChar = simChar;
                this.count = count;
            }

            public int GetLineCount()
            {
                return count;
            }

            public string GetText(string fileName, int lineIndex1, int lineIndex2)
            {
                int stringLength = lineIndex2 - lineIndex1 + 1;
                return new string(simChar, stringLength);
            }
        }
    }
}