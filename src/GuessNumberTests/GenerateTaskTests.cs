using Moq;
using Xunit;
using GuessNumber;
using GuessNumber.Abstractions;

namespace GuessNumberTests
{
    public class GenerateTaskTests
    {
        [Fact]
        public void Execute_Case1_CallsCorrectGenerator()
        {
            // Arrange
            var mockGetRandomInt = new Mock<IGetRandomInt>();
            var mockGenerateAdditionProblem = new Mock<IGenerateAdditionProblem>();
            var mockGenerateSubstractionProblem = new Mock<IGenerateSubstractionProblem>();
            var mockGenerateMultiplicationProblem = new Mock<IGenerateMultiplicationProblem>();
            var mockGenerateDivisionProblem = new Mock<IGenerateDivisionProblem>();

            mockGetRandomInt.Setup(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(1); // case

            var sut = new GenerateTask(mockGetRandomInt.Object,
                mockGenerateAdditionProblem.Object,
                mockGenerateSubstractionProblem.Object,
                mockGenerateMultiplicationProblem.Object,
                mockGenerateDivisionProblem.Object);

            // Act
            sut.Execute();

            // Assert
            mockGetRandomInt.Verify(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()), Times.Once());
            mockGenerateAdditionProblem.Verify(x => x.Execute(), Times.Once());
            mockGenerateSubstractionProblem.Verify(x => x.Execute(), Times.Never());
            mockGenerateMultiplicationProblem.Verify(x => x.Execute(), Times.Never());
            mockGenerateDivisionProblem.Verify(x => x.Execute(), Times.Never());
        }

        [Fact]
        public void Execute_Case2_CallsCorrectGenerator()
        {
            // Arrange
            var mockGetRandomInt = new Mock<IGetRandomInt>();
            var mockGenerateAdditionProblem = new Mock<IGenerateAdditionProblem>();
            var mockGenerateSubstractionProblem = new Mock<IGenerateSubstractionProblem>();
            var mockGenerateMultiplicationProblem = new Mock<IGenerateMultiplicationProblem>();
            var mockGenerateDivisionProblem = new Mock<IGenerateDivisionProblem>();

            mockGetRandomInt.Setup(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(2); // case

            var sut = new GenerateTask(mockGetRandomInt.Object,
                mockGenerateAdditionProblem.Object,
                mockGenerateSubstractionProblem.Object,
                mockGenerateMultiplicationProblem.Object,
                mockGenerateDivisionProblem.Object);

            // Act
            sut.Execute();

            // Assert
            mockGetRandomInt.Verify(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()), Times.Once());
            mockGenerateAdditionProblem.Verify(x => x.Execute(), Times.Never());
            mockGenerateSubstractionProblem.Verify(x => x.Execute(), Times.Once());
            mockGenerateMultiplicationProblem.Verify(x => x.Execute(), Times.Never());
            mockGenerateDivisionProblem.Verify(x => x.Execute(), Times.Never());
        }

        [Fact]
        public void Execute_Case3_CallsCorrectGenerator()
        {
            // Arrange
            var mockGetRandomInt = new Mock<IGetRandomInt>();
            var mockGenerateAdditionProblem = new Mock<IGenerateAdditionProblem>();
            var mockGenerateSubstractionProblem = new Mock<IGenerateSubstractionProblem>();
            var mockGenerateMultiplicationProblem = new Mock<IGenerateMultiplicationProblem>();
            var mockGenerateDivisionProblem = new Mock<IGenerateDivisionProblem>();

            mockGetRandomInt.Setup(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(3); // case

            var sut = new GenerateTask(mockGetRandomInt.Object,
                mockGenerateAdditionProblem.Object,
                mockGenerateSubstractionProblem.Object,
                mockGenerateMultiplicationProblem.Object,
                mockGenerateDivisionProblem.Object);

            // Act
            sut.Execute();

            // Assert
            mockGetRandomInt.Verify(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()), Times.Once());
            mockGenerateAdditionProblem.Verify(x => x.Execute(), Times.Never());
            mockGenerateSubstractionProblem.Verify(x => x.Execute(), Times.Never());
            mockGenerateMultiplicationProblem.Verify(x => x.Execute(), Times.Once());
            mockGenerateDivisionProblem.Verify(x => x.Execute(), Times.Never());
        }

        [Fact]
        public void Execute_Case4_CallsCorrectGenerator()
        {
            // Arrange
            var mockGetRandomInt = new Mock<IGetRandomInt>();
            var mockGenerateAdditionProblem = new Mock<IGenerateAdditionProblem>();
            var mockGenerateSubstractionProblem = new Mock<IGenerateSubstractionProblem>();
            var mockGenerateMultiplicationProblem = new Mock<IGenerateMultiplicationProblem>();
            var mockGenerateDivisionProblem = new Mock<IGenerateDivisionProblem>();

            mockGetRandomInt.Setup(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(4); // case

            var sut = new GenerateTask(mockGetRandomInt.Object,
                mockGenerateAdditionProblem.Object,
                mockGenerateSubstractionProblem.Object,
                mockGenerateMultiplicationProblem.Object,
                mockGenerateDivisionProblem.Object);

            // Act
            sut.Execute();

            // Assert
            mockGetRandomInt.Verify(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()), Times.Once());
            mockGenerateAdditionProblem.Verify(x => x.Execute(), Times.Never());
            mockGenerateSubstractionProblem.Verify(x => x.Execute(), Times.Never());
            mockGenerateMultiplicationProblem.Verify(x => x.Execute(), Times.Never());
            mockGenerateDivisionProblem.Verify(x => x.Execute(), Times.Once());
        }

        [Fact]
        public void Execute_InvalidCase_ThrowsInvalidOperationException()
        {
            // Arrange
            var mockGetRandomInt = new Mock<IGetRandomInt>();
            var mockGenerateAdditionProblem = new Mock<IGenerateAdditionProblem>();
            var mockGenerateSubstractionProblem = new Mock<IGenerateSubstractionProblem>();
            var mockGenerateMultiplicationProblem = new Mock<IGenerateMultiplicationProblem>();
            var mockGenerateDivisionProblem = new Mock<IGenerateDivisionProblem>();

            mockGetRandomInt.Setup(x => x.Execute(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(5); // invalid case

            var sut = new GenerateTask(mockGetRandomInt.Object,
                mockGenerateAdditionProblem.Object,
                mockGenerateSubstractionProblem.Object,
                mockGenerateMultiplicationProblem.Object,
                mockGenerateDivisionProblem.Object);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => sut.Execute());
        }
    }
}