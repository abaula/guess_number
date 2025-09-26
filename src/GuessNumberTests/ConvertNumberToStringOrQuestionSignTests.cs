using GuessNumber;
using Xunit;

namespace GuessNumberTests
{
    public class ConvertNumberToStringOrQuestionSignTests
    {
        [Fact]
        public void Execute_NullInput_ReturnsQuestionMark()
        {
            // Arrange
            var converter = new ConvertNumberToStringOrQuestionSign();
            int? input = null;

            // Act
            var result = converter.Execute(input);

            // Assert
            Assert.Equal("?", result);
        }

        [Theory]
        [InlineData(5, "5")]
        [InlineData(0, "0")]
        [InlineData(-3, "-3")]
        public void Execute_NonNullInput_ReturnsStringValue(int? input, string expected)
        {
            // Arrange
            var converter = new ConvertNumberToStringOrQuestionSign();

            // Act
            var result = converter.Execute(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}