using Xunit;
using GuessNumber;

namespace GuessNumberTests
{
    public class CheckUserAnswerTests
    {
        [Theory]
        [InlineData(42, 42, true)]
        [InlineData(42, 43, false)]
        [InlineData(0, 0, true)]
        [InlineData(-100, -100, true)]
        [InlineData(int.MaxValue, int.MaxValue, true)]
        [InlineData(int.MinValue, int.MinValue, true)]
        public void Execute_Check(int taskAnswerValue, int correctAnswer, bool expected)
        {
            // Arrange
            var gameTask = new GameTask
            {
                Answer = taskAnswerValue
            };

            var checker = new CheckUserAnswer();

            // Act
            bool actual = checker.Execute(gameTask, correctAnswer);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
