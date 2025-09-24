using Moq;
using Xunit;
using GuessNumber;
using GuessNumber.Abstractions;

namespace GuessNumberTests
{
    public class PrintByeTests
    {
        [Fact]
        public void Execute_NoTemplate_NoPrint()
        {
            // Arrange
            var resourceName = AppConst.Resources.Bye;
            var mockGetResourceText = new Mock<IGetResourceText>();
            var mockWriteToConsole = new Mock<IWriteToConsole>();

            mockGetResourceText.Setup(x => x.Execute(resourceName))
                .Returns((string?)null); // no template

            var sut = new PrintBye(mockGetResourceText.Object,
                mockWriteToConsole.Object);

            // Act
            sut.Execute();

            // Assert
            mockGetResourceText.Verify(x => x.Execute(resourceName), Times.Once());
            mockWriteToConsole.Verify(x => x.Execute(It.IsAny<string>()), Times.Never());
        }

        [Fact]
        public void Execute_TemplateFound_Print()
        {
            // Arrange
            var resourceName = AppConst.Resources.Bye;
            var mockGetResourceText = new Mock<IGetResourceText>();
            var mockWriteToConsole = new Mock<IWriteToConsole>();

            mockGetResourceText.Setup(x => x.Execute(resourceName))
                .Returns("SomeTemplate");

            var sut = new PrintBye(mockGetResourceText.Object,
                mockWriteToConsole.Object);

            // Act
            sut.Execute();

            // Assert
            mockGetResourceText.Verify(x => x.Execute(resourceName), Times.Once());
            mockWriteToConsole.Verify(x => x.Execute(It.IsAny<string>()), Times.Once());
        }
    }
}