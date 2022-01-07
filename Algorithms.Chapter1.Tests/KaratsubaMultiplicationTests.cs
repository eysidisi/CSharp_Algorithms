using Xunit;
using Algorithms.Chapter1;

namespace Algorithms.Chapter1.Tests
{
    public class KaratsubaMultiplicationTests
    {
        [Fact]
        public void Multiply_OneDigitNumbers_ReturnsResult()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new KaratsubaMultiplication();

            long num1 = 3;
            long num2 = 2;
            long expectedResult = 6;

            // Act
            long actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Multiply_WithOne_ReturnsResult()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new KaratsubaMultiplication();

            long num1 = 3345;
            long num2 = 1;
            long expectedResult = 3345;

            // Act
            long actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Multiply_WithZero_ReturnsResult()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new KaratsubaMultiplication();

            long num1 = 3345;
            long num2 = 0;
            long expectedResult = 0;

            // Act
            long actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Multiply_OneDigitWithTwoDigitNumbers_ReturnsResult()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new KaratsubaMultiplication();

            long num1 = 3;
            long num2 = 11;
            long expectedResult =33;

            // Act
            long actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Multiply_TwoDigitNumbers_ReturnsResult()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new KaratsubaMultiplication();

            long num1 = 23;
            long num2 = 56;
            long expectedResult = 1288;

            // Act
            long actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Multiply_TwoDigitNumberWithThreeDigitNumber_ReturnsResult()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new KaratsubaMultiplication();

            long num1 = 12;
            long num2 = 345;
            long expectedResult = 4140;

            // Act
            long actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Multiply_TwoDigitNumberWithFiveDigitNumber_ReturnsResult()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new KaratsubaMultiplication();

            long num1 = 12;
            long num2 = 34567;
            long expectedResult = 414804;

            // Act
            long actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Multiply_ThreeDigitNumbers_ReturnsResult()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new KaratsubaMultiplication();

            long num1 = 123;
            long num2 = 456;
            long expectedResult = 56088;

            // Act
            long actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Multiply_FourDigitNumbers_ReturnsResult()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new KaratsubaMultiplication();

            long num1 = 1234;
            long num2 = 5678;
            long expectedResult = 7006652;

            // Act
            long actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Multiply_NegativeNumberWithPositiveNumber_ReturnsResult()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new KaratsubaMultiplication();

            long num1 = -1234;
            long num2 = 5678;
            long expectedResult = -7006652;

            // Act
            long actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Multiply_TwoNegativeNumbers_ReturnsResult()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new KaratsubaMultiplication();

            long num1 = -1234;
            long num2 = -5678;
            long expectedResult = 7006652;

            // Act
            long actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }

    }
}