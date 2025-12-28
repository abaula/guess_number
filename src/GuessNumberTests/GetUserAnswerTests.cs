using Moq;
using Xunit;
using GuessNumber;
using GuessNumber.Abstractions;

namespace GuessNumberTests
{
    public class GetUserAnswerTests
    {
        [Fact]
        public void Execute_NoUserInput()
        {
            // Arrange
            var mockGetUserAnswerInput = new Mock<IGetUserAnswerInput>();
            var mockConvertInputToNumber = new Mock<IConvertInputToNumber>();
            var mockPrintNumberNeeded = new Mock<IPrintNumberNeeded>();

            mockGetUserAnswerInput.Setup(x => x.Execute()).Returns((string?)null);

            var sut = new GetUserAnswer(LazyHelper.ToLazy(mockGetUserAnswerInput.Object),
                LazyHelper.ToLazy(mockConvertInputToNumber.Object),
                LazyHelper.ToLazy(mockPrintNumberNeeded.Object));

            // Act
            var actual = sut.Execute();

            // Assert
            Assert.Null(actual);
            mockGetUserAnswerInput.Verify(x => x.Execute(), Times.Once());
            mockConvertInputToNumber.Verify(x => x.Execute(It.IsAny<string>()), Times.Never());
            mockPrintNumberNeeded.Verify(x => x.Execute(), Times.Never());
        }

        [Fact]
        public void Execute_UserInput_AnyNumber()
        {
            // Arrange
            var mockGetUserAnswerInput = new Mock<IGetUserAnswerInput>();
            var mockConvertInputToNumber = new Mock<IConvertInputToNumber>();
            var mockPrintNumberNeeded = new Mock<IPrintNumberNeeded>();

            mockGetUserAnswerInput.Setup(x => x.Execute()).Returns("Anything");
            mockConvertInputToNumber.Setup(x => x.Execute("Anything")).Returns(5);

            var sut = new GetUserAnswer(LazyHelper.ToLazy(mockGetUserAnswerInput.Object),
                LazyHelper.ToLazy(mockConvertInputToNumber.Object),
                LazyHelper.ToLazy(mockPrintNumberNeeded.Object));

            // Act
            var actual = sut.Execute();

            // Assert
            Assert.Equal(5, actual);
            mockGetUserAnswerInput.Verify(x => x.Execute(), Times.Once());
            mockConvertInputToNumber.Verify(x => x.Execute("Anything"), Times.Once());
            mockPrintNumberNeeded.Verify(x => x.Execute(), Times.Never());
        }

        [Fact]
        public void Execute_UserInput_NumberBySecondAttempt()
        {
            // Arrange
            var mockGetUserAnswerInput = new Mock<IGetUserAnswerInput>();
            var mockConvertInputToNumber = new Mock<IConvertInputToNumber>();
            var mockPrintNumberNeeded = new Mock<IPrintNumberNeeded>();

            mockGetUserAnswerInput.SetupSequence(x => x.Execute())
                .Returns("Anything")
                .Returns("Anything");
            mockConvertInputToNumber.SetupSequence(x => x.Execute("Anything"))
                .Returns((int?)null)
                .Returns(5);

            var sut = new GetUserAnswer(LazyHelper.ToLazy(mockGetUserAnswerInput.Object),
                LazyHelper.ToLazy(mockConvertInputToNumber.Object),
                LazyHelper.ToLazy(mockPrintNumberNeeded.Object));

            // Act
            var actual = sut.Execute();

            // Assert
            Assert.Equal(5, actual);
            mockGetUserAnswerInput.Verify(x => x.Execute(), Times.Exactly(2));
            mockConvertInputToNumber.Verify(x => x.Execute("Anything"), Times.Exactly(2));
            mockPrintNumberNeeded.Verify(x => x.Execute(), Times.Once());
        }
    }
}