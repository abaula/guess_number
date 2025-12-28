using Moq;
using Xunit;
using GuessNumber;
using GuessNumber.Abstractions;

namespace GuessNumberTests
{
    public class GenerateAdditionProblemTests
    {
        private const string Operation = "+";

        [Fact]
        public void Execute_CaseA_CallsCreateGameTaskWithCorrectParameters()
        {
            // Arrange
            var mockGetRandomInt = new Mock<IGetRandomInt>();
            var mockCreateGameTask = new Mock<ICreateGameTask>();

            mockGetRandomInt.SetupSequence(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(5) // c
                .Returns(3) // b
                .Returns(1); // case

            var sut = new GenerateAdditionProblem(LazyHelper.ToLazy(mockGetRandomInt.Object), LazyHelper.ToLazy(mockCreateGameTask.Object));

            // Act
            sut.Execute();

            // Assert
            mockGetRandomInt.Verify(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(3));
            mockCreateGameTask.Verify(x => x.Execute(default, 3, 5, 2, Operation), Times.Once());
        }

        [Fact]
        public void Execute_CaseB_CallsCreateGameTaskWithCorrectParameters()
        {
            // Arrange
            var mockGetRandomInt = new Mock<IGetRandomInt>();
            var mockCreateGameTask = new Mock<ICreateGameTask>();

            mockGetRandomInt.SetupSequence(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(5) // c
                .Returns(3) // b
                .Returns(2); // case

            var sut = new GenerateAdditionProblem(LazyHelper.ToLazy(mockGetRandomInt.Object), LazyHelper.ToLazy(mockCreateGameTask.Object));

            // Act
            sut.Execute();

            // Assert
            mockGetRandomInt.Verify(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(3));
            mockCreateGameTask.Verify(x => x.Execute(2, default, 5, 3, Operation), Times.Once());
        }

        [Fact]
        public void Execute_CaseC_CallsCreateGameTaskWithCorrectParameters()
        {
            // Arrange
            var mockGetRandomInt = new Mock<IGetRandomInt>();
            var mockCreateGameTask = new Mock<ICreateGameTask>();

            mockGetRandomInt.SetupSequence(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(5) // c
                .Returns(3) // b
                .Returns(3); // case

            var sut = new GenerateAdditionProblem(LazyHelper.ToLazy(mockGetRandomInt.Object), LazyHelper.ToLazy(mockCreateGameTask.Object));

            // Act
            sut.Execute();

            // Assert
            mockGetRandomInt.Verify(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(3));
            mockCreateGameTask.Verify(x => x.Execute(2, 3, default, 5, Operation), Times.Once());
        }

        [Fact]
        public void Execute_InvalidCase_ThrowsInvalidOperationException()
        {
            // Arrange
            var mockGetRandomInt = new Mock<IGetRandomInt>();
            var mockCreateGameTask = new Mock<ICreateGameTask>();

            mockGetRandomInt.SetupSequence(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(5) // c
                .Returns(3) // b
                .Returns(4); // invalid case

            var sut = new GenerateAdditionProblem(LazyHelper.ToLazy(mockGetRandomInt.Object), LazyHelper.ToLazy(mockCreateGameTask.Object));

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => sut.Execute());
        }
    }
}