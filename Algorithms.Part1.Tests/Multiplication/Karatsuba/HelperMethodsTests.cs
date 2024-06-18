using Xunit;
using Algorithms.Part1.Multiplication.Karatsuba;
using System.Numerics;

namespace Algorithms.Part1.Tests.Multiplication.Karatsuba
{
    public class HelperMethodsTests
    {
        [Fact]
        public void GetNumOfDigits_FiveDigitNumber()
        {
            // Arrange
            BigInteger num = 12345;
            BigInteger expectedResult = 5;

            // Act
            var actualResult = HelperMethods.GetNumOfDigits(num);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetNumOfDigits_FiveDigitNegativeNumber()
        {
            // Arrange
            BigInteger num = -12345;
            BigInteger expectedResult = 5;

            // Act
            var actualResult = HelperMethods.GetNumOfDigits(num);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetNumOfDigits_OneDigitNumber()
        {
            // Arrange
            BigInteger num = 9;
            BigInteger expectedResult = 1;

            // Act
            var actualResult = HelperMethods.GetNumOfDigits(num);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetNumOfDigits_NumberZero()
        {
            // Arrange
            BigInteger num = 0;
            BigInteger expectedResult = 1;

            // Act
            var actualResult = HelperMethods.GetNumOfDigits(num);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void FirstPartOfNumber_NumberWith2DigitsLastPartLength1()
        {
            // Arrange
            BigInteger number = 12;
            BigInteger expectedResult = 1;
            int lastPartLength = 1;

            // Act
            var actualResult = HelperMethods.FirstPartOfNum(number, lastPartLength);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void FirstPartOfNumber_NumberWith2DigitsLastPartLength2()
        {
            // Arrange
            BigInteger number = 12;
            BigInteger expectedResult = 0;
            int lastPartLength = 2;

            // Act
            var actualResult = HelperMethods.FirstPartOfNum(number, lastPartLength);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void FirstPartOfNumber_NumberWith3DigitsLastPartLength1()
        {
            // Arrange
            BigInteger number = 123;
            BigInteger expectedResult = 12;
            int lastPartLength = 1;

            // Act
            var actualResult = HelperMethods.FirstPartOfNum(number, lastPartLength);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void FirstPartOfNumber_NumberWith3DigitsLastPartLength2()
        {
            // Arrange
            BigInteger number = 123;
            BigInteger expectedResult = 1;
            int lastPartLength = 2;

            // Act
            var actualResult = HelperMethods.FirstPartOfNum(number, lastPartLength);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void FirstPartOfNum_NumberWith1DigitLastPartLength1()
        {
            // Arrange
            BigInteger number = 1;
            BigInteger expectedResult = 0;
            int lastPartLength = 1;

            // Act
            var actualResult = HelperMethods.FirstPartOfNum(number, lastPartLength);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void LastPartOfNum_NumberWith1DigitLastPartLength1()
        {
            // Arrange
            BigInteger number = 1;
            BigInteger expectedResult = 1;
            int lastPartLength = 1;

            // Act
            var actualResult = HelperMethods.LastPartOfNum(number, lastPartLength);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void LastPartOfNum_NumberWith2DigitsLastPartLength1()
        {
            // Arrange
            BigInteger number = 12;
            BigInteger expectedResult = 2;
            int lastPartLength = 1;

            // Act
            var actualResult = HelperMethods.LastPartOfNum(number, lastPartLength);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void LastPartOfNum_NumberWith3DigitsLastParthLength2()
        {
            // Arrange
            BigInteger number = 123;
            BigInteger expectedResult = 23;
            int lastPartLength = 2;

            // Act
            var actualResult = HelperMethods.LastPartOfNum(number, lastPartLength);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void LastPartOfNum_NumberWith3DigitsLastParthLength1()
        {
            // Arrange
            BigInteger number = 123;
            BigInteger expectedResult = 3;
            int lastPartLength = 1;

            // Act
            var actualResult = HelperMethods.LastPartOfNum(number, lastPartLength);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void AddZeros_AddTwoZeros()
        {
            // Arrange
            BigInteger number = 1;
            int numberOfZerosToAdd = 2;
            BigInteger expectedResult = 100;

            // Act
            var actualResult = HelperMethods.AddZeros(numberOfZerosToAdd, number);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void AddZeros_AddZeroZeros()
        {
            // Arrange
            BigInteger number = 1;
            int numberOfZerosToAdd = 0;
            BigInteger expectedResult = 1;

            // Act
            var actualResult = HelperMethods.AddZeros(numberOfZerosToAdd, number);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void AddZeros_AddZerosToZero()
        {
            // Arrange
            BigInteger number = 0;
            int numberOfZerosToAdd = 2;
            BigInteger expectedResult = 0;

            // Act
            var actualResult = HelperMethods.AddZeros(numberOfZerosToAdd, number);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
