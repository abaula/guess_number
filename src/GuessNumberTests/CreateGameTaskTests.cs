using Moq;
using Xunit;
using GuessNumber;
using GuessNumber.Abstractions;

namespace GuessNumberTests
{
    public class CreateGameTaskTests
    {
        [Fact]
        public void Execute_ShouldCreateTaskWithConvertedNumbers()
        {
            // Arrange
            var mockConverter = new Mock<IConvertNumberToStringOrQuestionSign>();
            mockConverter.SetupSequence(m => m.Execute(It.IsAny<int?>()))
                .Returns("X") // a
                .Returns("Y") // b
                .Returns("Z"); // c

            var sut = new CreateGameTask(mockConverter.Object);

            // Act
            var result = sut.Execute(1, 2, 3, 42, "+");

            // Assert
            Assert.Equal("X + Y = Z", result.Task);
            Assert.Equal(42, result.Answer);
            mockConverter.Verify(m => m.Execute(1), Times.Once);
            mockConverter.Verify(m => m.Execute(2), Times.Once);
            mockConverter.Verify(m => m.Execute(3), Times.Once);
        }

        [Fact]
        public void Execute_NullValues_ShouldUseQuestionMarks()
        {
            // Arrange
            var mockConverter = new Mock<IConvertNumberToStringOrQuestionSign>();
            mockConverter.Setup(m => m.Execute(null as int?)).Returns("?");

            var sut = new CreateGameTask(mockConverter.Object);

            // Act
            var result = sut.Execute(null, 5, null, 7, "-");

            // Assert
            Assert.Equal("? -  = ?", result.Task);
            Assert.Equal(7, result.Answer);
            mockConverter.Verify(m => m.Execute(null), Times.Exactly(2));
            mockConverter.Verify(m => m.Execute(5), Times.Once);
        }

        [Fact]
        public void Execute_AllNullParameters_ShouldUseAllQuestionMarks()
        {
            // Arrange
            var mockConverter = new Mock<IConvertNumberToStringOrQuestionSign>();
            mockConverter.Setup(m => m.Execute(null as int?)).Returns("?");

            var sut = new CreateGameTask(mockConverter.Object);

            // Act
            var result = sut.Execute(null, null, null, 0, "*");

            // Assert
            Assert.Equal("? * ? = ?", result.Task);
            Assert.Equal(0, result.Answer);
            mockConverter.Verify(m => m.Execute(null), Times.Exactly(3));
        }

        [Fact]
        public void Execute_CustomConversion_ShouldRespectConverterImplementation()
        {
            // Arrange
            var mockConverter = new Mock<IConvertNumberToStringOrQuestionSign>();
            mockConverter.Setup(m => m.Execute(42)).Returns("XLII");
            mockConverter.Setup(m => m.Execute(666)).Returns("DIABLO");

            var sut = new CreateGameTask(mockConverter.Object);

            // Act
            var result = sut.Execute(42, 666, 999, 1234, "/");

            // Assert
            Assert.Equal("XLII / DIABLO = ", result.Task);
            Assert.Equal(1234, result.Answer);
            mockConverter.Verify(m => m.Execute(42), Times.Once);
            mockConverter.Verify(m => m.Execute(666), Times.Once);
            mockConverter.Verify(m => m.Execute(999), Times.Once);
        }
    }
}