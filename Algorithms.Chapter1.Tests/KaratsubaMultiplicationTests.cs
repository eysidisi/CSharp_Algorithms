using Xunit;
using Algorithms.Chapter1;

namespace Algorithms.Chapter1.Tests
{
    public class KaratsubaMultiplicationTests
    {
        [Fact]
        public void Multiply_FiveDigitNumbers_ReturnsResult()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new KaratsubaMultiplication();

            long num1 = 12345;
            long num2 = 67890;
            long expectedResult = 838102050;

            // Act
            long actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}