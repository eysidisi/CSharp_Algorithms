using Xunit;
using Algorithms.Part1.Multiplication.Karatsuba;
using System.Numerics;

namespace Algorithms.Part1.Tests.Multiplication.Karatsuba
{
    public class KaratsubaMultiplicationTests
    {
        [Fact]
        public void Multiply_OneDigitNumbers()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new();

            BigInteger num1 = 3;
            BigInteger num2 = 2;
            BigInteger expectedResult = 6;

            // Act
            BigInteger actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Multiply_WithOne()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new();

            BigInteger num1 = 3345;
            BigInteger num2 = 1;
            BigInteger expectedResult = 3345;

            // Act
            BigInteger actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Multiply_WithZero()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new();

            BigInteger num1 = 3345;
            BigInteger num2 = 0;
            BigInteger expectedResult = 0;

            // Act
            BigInteger actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Multiply_OneDigitWithTwoDigitNumbers()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new();

            BigInteger num1 = 3;
            BigInteger num2 = 11;
            BigInteger expectedResult = 33;

            // Act
            BigInteger actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Multiply_TwoDigitNumbers()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new();

            BigInteger num1 = 23;
            BigInteger num2 = 56;
            BigInteger expectedResult = 1288;

            // Act
            BigInteger actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Multiply_TwoDigitNumberWithThreeDigitNumber()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new();

            BigInteger num1 = 12;
            BigInteger num2 = 345;
            BigInteger expectedResult = 4140;

            // Act
            BigInteger actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Multiply_TwoDigitNumberWithFiveDigitNumber()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new();

            BigInteger num1 = 12;
            BigInteger num2 = 34567;
            BigInteger expectedResult = 414804;

            // Act
            BigInteger actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Multiply_ThreeDigitNumbers()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new();

            BigInteger num1 = 123;
            BigInteger num2 = 456;
            BigInteger expectedResult = 56088;

            // Act
            BigInteger actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Multiply_FourDigitNumbers()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new();

            BigInteger num1 = 1234;
            BigInteger num2 = 5678;
            BigInteger expectedResult = 7006652;

            // Act
            BigInteger actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Multiply_NegativeNumberWithPositiveNumber()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new();

            BigInteger num1 = -1234;
            BigInteger num2 = 5678;
            BigInteger expectedResult = -7006652;

            // Act
            BigInteger actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Multiply_TwoNegativeNumbers()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new();

            BigInteger num1 = -1234;
            BigInteger num2 = -5678;
            BigInteger expectedResult = 7006652;

            // Act
            BigInteger actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Assignment()
        {
            // Arrange
            KaratsubaMultiplication karatsubaMultiplication = new();

            BigInteger num1 = BigInteger.Parse("3141592653589793238462643383279502884197169399375105820974944592");
            BigInteger num2 = BigInteger.Parse("2718281828459045235360287471352662497757247093699959574966967627");
            BigInteger expectedResult = BigInteger.Parse("8539734222673567065463550869546574495034888535765114961879601127067743044893204848617875072216249073013374895871952806582723184");

            // Act
            BigInteger actualResult = karatsubaMultiplication.Multiply(num1, num2);
            Assert.Equal(expectedResult, actualResult);
        }

    }
}