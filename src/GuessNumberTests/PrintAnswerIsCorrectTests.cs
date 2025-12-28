using Moq;
using Xunit;
using GuessNumber;
using GuessNumber.Abstractions;

namespace GuessNumberTests
{
    public class PrintAnswerIsCorrectTests
    {
        [Fact]
        public void Execute_NoTemplate_NoPrint()
        {
            // Arrange
            var answer = 100;
            var resourceName = AppConst.Resources.AnswerIsCorrectTemplate;
            var mockGetResourceText = new Mock<IGetResourceText>();
            var mockWriteToConsole = new Mock<IWriteToConsole>();

            mockGetResourceText.Setup(x => x.Execute(resourceName))
                .Returns((string?)null); // no template

            var sut = new PrintAnswerIsCorrect(LazyHelper.ToLazy(mockGetResourceText.Object),
                LazyHelper.ToLazy(mockWriteToConsole.Object));

            // Act
            sut.Execute(answer);

            // Assert
            mockGetResourceText.Verify(x => x.Execute(resourceName), Times.Once());
            mockWriteToConsole.Verify(x => x.Execute(It.IsAny<string>()), Times.Never());
        }

        [Fact]
        public void Execute_TemplateFound_Print()
        {
            // Arrange
            var answer = 100;
            var resourceName = AppConst.Resources.AnswerIsCorrectTemplate;
            var mockGetResourceText = new Mock<IGetResourceText>();
            var mockWriteToConsole = new Mock<IWriteToConsole>();

            mockGetResourceText.Setup(x => x.Execute(resourceName))
                .Returns("SomeTemplate");

            var sut = new PrintAnswerIsCorrect(LazyHelper.ToLazy(mockGetResourceText.Object),
                LazyHelper.ToLazy(mockWriteToConsole.Object));

            // Act
            sut.Execute(answer);

            // Assert
            mockGetResourceText.Verify(x => x.Execute(resourceName), Times.Once());
            mockWriteToConsole.Verify(x => x.Execute(It.IsAny<string>()), Times.Once());
        }
    }
}