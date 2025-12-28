using Moq;
using Xunit;
using GuessNumber;
using GuessNumber.Abstractions;

namespace GuessNumberTests
{
    public class CreateGameTaskTests
    {
        [Fact]
        public void Execute_Return_Success()
        {
            // Arrange
            var mockConverter = new Mock<IConvertNumberToStringOrQuestionSign>();
            mockConverter.Setup(m => m.Execute(It.IsAny<int?>())).Returns("_");

            var sut = new CreateGameTask(LazyHelper.ToLazy(mockConverter.Object));

            // Act
            var result = sut.Execute(null, null, null, 0, "*");

            // Assert
            Assert.NotNull(result.Task);
            Assert.NotEmpty(result.Task);
            Assert.Equal(0, result.Answer);
            mockConverter.Verify(m => m.Execute(null), Times.Exactly(3));
        }
    }
}