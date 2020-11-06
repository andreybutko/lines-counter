using System.IO.Abstractions;
using Moq;
using Xunit;

namespace LinesCounter.UnitTests
{
    public class LinesServiceTests
    {
        private LinesService Service { get; }
        private Mock<IFile> FileMock { get; }

        public LinesServiceTests()
        {
            var fileSystemMock = new Mock<IFileSystem>();
            FileMock = new Mock<IFile>();
            fileSystemMock.SetupGet(_ => _.File)
                .Returns(FileMock.Object);
            Service = new LinesService(fileSystemMock.Object);
        }

        [Theory(DisplayName = "Test cases for line calculation")]
        [ClassData(typeof(DataProvider))]
        public void GetMaxStringSum_TestCases(TestLineItem testItem)
        {
            FileMock.Setup(_ => _.ReadLines(It.IsAny<string>()))
                .Returns(testItem.Input);

            var (maxLines, invalidLines) = Service.GetMaxLineNumbers("test.txt");

            Assert.Equal(testItem.ExpectedMaxLineNumbers, maxLines);
            Assert.Equal(testItem.ExpectedInvalidLinesNumbers, invalidLines);
        }
    }
}
