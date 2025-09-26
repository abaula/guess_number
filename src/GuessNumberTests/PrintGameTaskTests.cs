using Moq;
using Xunit;
using GuessNumber;
using GuessNumber.Abstractions;

namespace GuessNumberTests
{
    public class PrintGameTaskTests
    {
        [Fact]
        public void Execute_NoTemplate_NoPrint()
        {
            // Arrange
            var gameTask = new GameTask();
            var resourceName = AppConst.Resources.GameTaskTemplate;
            var mockGetResourceText = new Mock<IGetResourceText>();
            var mockWriteToConsole = new Mock<IWriteToConsole>();

            mockGetResourceText.Setup(x => x.Execute(resourceName))
                .Returns((string?)null); // no template

            var sut = new PrintGameTask(mockGetResourceText.Object,
                mockWriteToConsole.Object);

            // Act
            sut.Execute(gameTask);

            // Assert
            mockGetResourceText.Verify(x => x.Execute(resourceName), Times.Once());
            mockWriteToConsole.Verify(x => x.Execute(It.IsAny<string>()), Times.Never());
        }

        [Fact]
        public void Execute_TemplateFound_Print()
        {
            // Arrange
            var gameTask = new GameTask();
            var resourceName = AppConst.Resources.GameTaskTemplate;
            var mockGetResourceText = new Mock<IGetResourceText>();
            var mockWriteToConsole = new Mock<IWriteToConsole>();

            mockGetResourceText.Setup(x => x.Execute(resourceName))
                .Returns("SomeTemplate");

            var sut = new PrintGameTask(mockGetResourceText.Object,
                mockWriteToConsole.Object);

            // Act
            sut.Execute(gameTask);

            // Assert
            mockGetResourceText.Verify(x => x.Execute(resourceName), Times.Once());
            mockWriteToConsole.Verify(x => x.Execute(It.IsAny<string>()), Times.Once());
        }
    }
}