using Moq;
using Xunit;
using GuessNumber;
using GuessNumber.Abstractions;

namespace GuessNumberTests
{
    public class GenerateAdditionProblemTests
    {
        [Fact]
        public void Execute_Case1_CallsCreateGameTaskWithCorrectParameters()
        {
            // Arrange
            var mockGetRandomInt = new Mock<IGetRandomInt>();
            var mockCreateGameTask = new Mock<ICreateGameTask>();

            mockGetRandomInt.SetupSequence(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(5) // c
                .Returns(3) // b
                .Returns(1); // case

            var sut = new GenerateAdditionProblem(mockGetRandomInt.Object, mockCreateGameTask.Object);

            // Act
            sut.Execute();

            // Assert
            mockCreateGameTask.Verify(x => x.Execute(default, 3, 5, 2, "+"), Times.Once());
        }

        [Fact]
        public void Execute_Case2_CallsCreateGameTaskWithCorrectParameters()
        {
            // Arrange
            var mockGetRandomInt = new Mock<IGetRandomInt>();
            var mockCreateGameTask = new Mock<ICreateGameTask>();

            mockGetRandomInt.SetupSequence(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(5) // c
                .Returns(3) // b
                .Returns(2); // case

            var sut = new GenerateAdditionProblem(mockGetRandomInt.Object, mockCreateGameTask.Object);

            // Act
            sut.Execute();

            // Assert
            mockCreateGameTask.Verify(x => x.Execute(2, default, 5, 3, "+"), Times.Once());
        }

        [Fact]
        public void Execute_Case3_CallsCreateGameTaskWithCorrectParameters()
        {
            // Arrange
            var mockGetRandomInt = new Mock<IGetRandomInt>();
            var mockCreateGameTask = new Mock<ICreateGameTask>();

            mockGetRandomInt.SetupSequence(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(5) // c
                .Returns(3) // b
                .Returns(3); // case

            var sut = new GenerateAdditionProblem(mockGetRandomInt.Object, mockCreateGameTask.Object);

            // Act
            sut.Execute();

            // Assert
            mockCreateGameTask.Verify(x => x.Execute(2, 3, default, 5, "+"), Times.Once());
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

            var sut = new GenerateAdditionProblem(mockGetRandomInt.Object, mockCreateGameTask.Object);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => sut.Execute());
        }

        [Fact]
        public void Execute_CaseWhenCIsZero_CallsCreateGameTaskWithCorrectParameters()
        {
            // Arrange
            var mockGetRandomInt = new Mock<IGetRandomInt>();
            var mockCreateGameTask = new Mock<ICreateGameTask>();

            mockGetRandomInt.SetupSequence(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(0) // c
                .Returns(0) // b
                .Returns(1); // case

            var sut = new GenerateAdditionProblem(mockGetRandomInt.Object, mockCreateGameTask.Object);

            // Act
            sut.Execute();

            // Assert
            mockCreateGameTask.Verify(x => x.Execute(default, 0, 0, 0, "+"), Times.Once());
        }
    }
}