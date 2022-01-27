using Xunit;
using Algorithms.Part1.Multiplication.Karatsuba;

namespace Algorithms.Part1.Tests.Multiplication.Karatsuba
{
    public class HelperMethodsTests
    {
        [Fact]
        public void GetNumOfDigits_FiveDigitNumber()
        {
            // Arrange
            HelperMethods helperMethods = new();

            long num = 12345;
            long expectedResult = 5;

            // Act
            long actualResult = helperMethods.GetNumOfDigits(num);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetNumOfDigits_FiveDigitNegativeNumber()
        {
            // Arrange
            HelperMethods helperMethods = new();

            long num = -12345;
            long expectedResult = 5;

            // Act
            long actualResult = helperMethods.GetNumOfDigits(num);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetNumOfDigits_OneDigitNumber()
        {
            // Arrange
            HelperMethods helperMethods = new();

            long num = 9;
            long expectedResult = 1;

            // Act
            long actualResult = helperMethods.GetNumOfDigits(num);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetNumOfDigits_NumberZero()
        {
            // Arrange
            HelperMethods helperMethods = new();

            long num = 0;
            long expectedResult = 1;

            // Act
            long actualResult = helperMethods.GetNumOfDigits(num);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void FirstPartOfNumber_NumberWith2DigitsLastPartLength1()
        {
            // Arrange
            HelperMethods helperMethods = new();

            long number = 12;
            long expectedResult = 1;
            int lastPartLength = 1;

            // Act
            long actualResult = helperMethods.FirstPartOfNum(number, lastPartLength);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void FirstPartOfNumber_NumberWith2DigitsLastPartLength2()
        {
            // Arrange
            HelperMethods helperMethods = new();

            long number = 12;
            long expectedResult = 0;
            int lastPartLength = 2;

            // Act
            long actualResult = helperMethods.FirstPartOfNum(number, lastPartLength);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void FirstPartOfNumber_NumberWith3DigitsLastPartLength1()
        {
            // Arrange
            HelperMethods helperMethods = new();

            long number = 123;
            long expectedResult = 12;
            int lastPartLength = 1;

            // Act
            long actualResult = helperMethods.FirstPartOfNum(number, lastPartLength);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void FirstPartOfNumber_NumberWith3DigitsLastPartLength2()
        {
            // Arrange
            HelperMethods helperMethods = new();

            long number = 123;
            long expectedResult = 1;
            int lastPartLength = 2;

            // Act
            long actualResult = helperMethods.FirstPartOfNum(number, lastPartLength);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void FirstPartOfNum_NumberWith1DigitLastPartLength1()
        {
            // Arrange
            HelperMethods helperMethods = new();

            long number = 1;
            long expectedResult = 0;
            int lastPartLength = 1;

            // Act
            long actualResult = helperMethods.FirstPartOfNum(number, lastPartLength);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void LastPartOfNum_NumberWith1DigitLastPartLength1()
        {
            // Arrange
            HelperMethods helperMethods = new();

            long number = 1;
            long expectedResult = 1;
            int lastPartLength = 1;

            // Act
            long actualResult = helperMethods.LastPartOfNum(number, lastPartLength);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void LastPartOfNum_NumberWith2DigitsLastPartLength1()
        {
            // Arrange
            HelperMethods helperMethods = new();

            long number = 12;
            long expectedResult = 2;
            int lastPartLength = 1;

            // Act
            long actualResult = helperMethods.LastPartOfNum(number, lastPartLength);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void LastPartOfNum_NumberWith3DigitsLastParthLength2()
        {
            // Arrange
            HelperMethods helperMethods = new();

            long number = 123;
            long expectedResult = 23;
            int lastPartLength = 2;

            // Act
            long actualResult = helperMethods.LastPartOfNum(number, lastPartLength);
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void LastPartOfNum_NumberWith3DigitsLastParthLength1()
        {
            // Arrange
            HelperMethods helperMethods = new();

            long number = 123;
            long expectedResult = 3;
            int lastPartLength = 1;

            // Act
            long actualResult = helperMethods.LastPartOfNum(number, lastPartLength);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void AddZeros_AddTwoZeros()
        {
            // Arrange
            HelperMethods helperMethods = new();

            long number = 1;
            int numberOfZerosToAdd = 2;
            long expectedResult = 100;

            // Act
            long actualResult = helperMethods.AddZeros(numberOfZerosToAdd, number);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void AddZeros_AddZeroZeros()
        {
            // Arrange
            HelperMethods helperMethods = new();

            long number = 1;
            int numberOfZerosToAdd = 0;
            long expectedResult = 1;

            // Act
            long actualResult = helperMethods.AddZeros(numberOfZerosToAdd, number);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void AddZeros_AddZerosToZero()
        {
            // Arrange
            HelperMethods helperMethods = new();

            long number = 0;
            int numberOfZerosToAdd = 2;
            long expectedResult = 0;

            // Act
            long actualResult = helperMethods.AddZeros(numberOfZerosToAdd, number);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
