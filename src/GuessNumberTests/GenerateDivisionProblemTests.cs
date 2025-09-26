using Moq;
using Xunit;
using GuessNumber;
using GuessNumber.Abstractions;

namespace GuessNumberTests
{
    public class GenerateDivisionProblemTests
    {
        private const string Operation = "/";

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

            var sut = new GenerateDivisionProblem(mockGetRandomInt.Object, mockCreateGameTask.Object);

            // Act
            sut.Execute();

            // Assert
            mockGetRandomInt.Verify(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(3));
            mockCreateGameTask.Verify(x => x.Execute(15, default, 5, 3, Operation), Times.Once());
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

            var sut = new GenerateDivisionProblem(mockGetRandomInt.Object, mockCreateGameTask.Object);

            // Act
            sut.Execute();

            // Assert
            mockGetRandomInt.Verify(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(3));
            mockCreateGameTask.Verify(x => x.Execute(15, 3, default, 5, Operation), Times.Once());
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
                .Returns(3); // invalid case

            var sut = new GenerateDivisionProblem(mockGetRandomInt.Object, mockCreateGameTask.Object);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => sut.Execute());
        }
    }
}