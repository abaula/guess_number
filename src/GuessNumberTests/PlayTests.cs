using Moq;
using Xunit;
using GuessNumber;
using GuessNumber.Abstractions;

namespace GuessNumberTests
{
    public class PlayTests
    {
        [Fact]
        public void Execute_NoAnswer_ExitGame()
        {
            // Arrange
            var mockGenerateTask = new Mock<IGenerateTask>();
            var mockPrintGameTask = new Mock<IPrintGameTask>();
            var mockGetUserAnswer = new Mock<IGetUserAnswer>();
            var mockCheckUserAnswer = new Mock<ICheckUserAnswer>();
            var mockPrintAnswerIsCorrect = new Mock<IPrintAnswerIsCorrect>();
            var mockPrintAnswerIsIncorrect = new Mock<IPrintAnswerIsIncorrect>();

            var gameTask = new GameTask();
            mockGenerateTask.Setup(x => x.Execute()).Returns(gameTask);
            mockGetUserAnswer.Setup(x => x.Execute()).Returns((int?)null); // no answer

            var sut = new Play(LazyHelper.ToLazy(mockGenerateTask.Object),
                LazyHelper.ToLazy(mockPrintGameTask.Object),
                LazyHelper.ToLazy(mockGetUserAnswer.Object),
                LazyHelper.ToLazy(mockCheckUserAnswer.Object),
                LazyHelper.ToLazy(mockPrintAnswerIsCorrect.Object),
                LazyHelper.ToLazy(mockPrintAnswerIsIncorrect.Object));

            // Act
            sut.Execute();

            // Assert
            mockGenerateTask.Verify(x => x.Execute(), Times.Once());
            mockPrintGameTask.Verify(x => x.Execute(gameTask), Times.Once());
            mockGetUserAnswer.Verify(x => x.Execute(), Times.Once());
            mockCheckUserAnswer.Verify(x => x.Execute(It.IsAny<GameTask>(), It.IsAny<int>()), Times.Never());
            mockPrintAnswerIsCorrect.Verify(x => x.Execute(It.IsAny<int>()), Times.Never());
            mockPrintAnswerIsIncorrect.Verify(x => x.Execute(It.IsAny<int>()), Times.Never());
        }

        [Fact]
        public void Execute_CorrectAnswer_ExitGame()
        {
            // Arrange
            var mockGenerateTask = new Mock<IGenerateTask>();
            var mockPrintGameTask = new Mock<IPrintGameTask>();
            var mockGetUserAnswer = new Mock<IGetUserAnswer>();
            var mockCheckUserAnswer = new Mock<ICheckUserAnswer>();
            var mockPrintAnswerIsCorrect = new Mock<IPrintAnswerIsCorrect>();
            var mockPrintAnswerIsIncorrect = new Mock<IPrintAnswerIsIncorrect>();

            var gameTask = new GameTask();
            var answer = 5;
            mockGenerateTask.Setup(x => x.Execute()).Returns(gameTask);
            mockGetUserAnswer.Setup(x => x.Execute()).Returns(answer);
            mockCheckUserAnswer.Setup(x => x.Execute(gameTask, answer)).Returns(true);

            var sut = new Play(LazyHelper.ToLazy(mockGenerateTask.Object),
                LazyHelper.ToLazy(mockPrintGameTask.Object),
                LazyHelper.ToLazy(mockGetUserAnswer.Object),
                LazyHelper.ToLazy(mockCheckUserAnswer.Object),
                LazyHelper.ToLazy(mockPrintAnswerIsCorrect.Object),
                LazyHelper.ToLazy(mockPrintAnswerIsIncorrect.Object));

            // Act
            sut.Execute();

            // Assert
            mockGenerateTask.Verify(x => x.Execute(), Times.Once());
            mockPrintGameTask.Verify(x => x.Execute(gameTask), Times.Once());
            mockGetUserAnswer.Verify(x => x.Execute(), Times.Once());
            mockCheckUserAnswer.Verify(x => x.Execute(gameTask, answer), Times.Once());
            mockPrintAnswerIsCorrect.Verify(x => x.Execute(answer), Times.Once());
            mockPrintAnswerIsIncorrect.Verify(x => x.Execute(It.IsAny<int>()), Times.Never());
        }

        [Fact]
        public void Execute_IncorrectAnswer_Continue_Then_ExitGame()
        {
            // Arrange
            var mockGenerateTask = new Mock<IGenerateTask>();
            var mockPrintGameTask = new Mock<IPrintGameTask>();
            var mockGetUserAnswer = new Mock<IGetUserAnswer>();
            var mockCheckUserAnswer = new Mock<ICheckUserAnswer>();
            var mockPrintAnswerIsCorrect = new Mock<IPrintAnswerIsCorrect>();
            var mockPrintAnswerIsIncorrect = new Mock<IPrintAnswerIsIncorrect>();

            var gameTask = new GameTask();
            var answer = 5;
            mockGenerateTask.Setup(x => x.Execute()).Returns(gameTask);
            mockGetUserAnswer.SetupSequence(x => x.Execute())
                .Returns(answer)
                .Returns((int?)null);
            mockCheckUserAnswer.Setup(x => x.Execute(gameTask, answer)).Returns(false);

            var sut = new Play(LazyHelper.ToLazy(mockGenerateTask.Object),
                LazyHelper.ToLazy(mockPrintGameTask.Object),
                LazyHelper.ToLazy(mockGetUserAnswer.Object),
                LazyHelper.ToLazy(mockCheckUserAnswer.Object),
                LazyHelper.ToLazy(mockPrintAnswerIsCorrect.Object),
                LazyHelper.ToLazy(mockPrintAnswerIsIncorrect.Object));

            // Act
            sut.Execute();

            // Assert
            mockGenerateTask.Verify(x => x.Execute(), Times.Once());
            mockPrintGameTask.Verify(x => x.Execute(gameTask), Times.Once());
            mockGetUserAnswer.Verify(x => x.Execute(), Times.Exactly(2));
            mockCheckUserAnswer.Verify(x => x.Execute(gameTask, answer), Times.Once());
            mockPrintAnswerIsCorrect.Verify(x => x.Execute(It.IsAny<int>()), Times.Never());
            mockPrintAnswerIsIncorrect.Verify(x => x.Execute(answer), Times.Once());
        }
    }
}