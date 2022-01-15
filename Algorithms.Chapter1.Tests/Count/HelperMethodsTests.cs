using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Part1.Count;

namespace Algorithms.Part1.Tests.Count
{
    public class HelperMethodsTests
    {
        [Fact]
        public void ArrayWithOneElement_FirstPartHasZeroElements()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();

            int[] arr = new int[] { 1 };
            int[] firstPart = new int[] { };
            int[] secondPart = new int[] { 1 };
            int expectedOutput = 0;
            int[] expectedArr = new int[] { 1 };

            // Act
            int actualOutput = helperMethods.MergeAndCountNumberOfInversions(firstPart, secondPart, ref arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
            Assert.Equal(expectedArr, arr);
        }
        [Fact]
        public void ArrayWithOneElement_SecondPartHasZeroElements()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();

            int[] arr = new int[] { 1 };
            int[] firstPart = new int[] { 1 };
            int[] secondPart = new int[] { };
            int expectedOutput = 0;
            int[] expectedArr = new int[] { 1 };

            // Act
            int actualOutput = helperMethods.MergeAndCountNumberOfInversions(firstPart, secondPart, ref arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
            Assert.Equal(expectedArr, arr);
        }
        [Fact]
        public void ArrayWithTwoElement_InOrderArray()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();

            int[] arr = new int[] { 1, 2 };
            int[] firstPart = new int[] { 1 };
            int[] secondPart = new int[] { 2 };
            int expectedOutput = 0;
            int[] expectedArr = new int[] { 1, 2 };

            // Act
            int actualOutput = helperMethods.MergeAndCountNumberOfInversions(firstPart, secondPart, ref arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
            Assert.Equal(expectedArr, arr);
        }

        [Fact]
        public void ArraysWithTwoElement_OutOfOrderArray()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();

            int[] arr = new int[] { 2, 1 };
            int[] firstPart = new int[] { 2 };
            int[] secondPart = new int[] { 1 };
            int expectedOutput = 1;
            int[] expectedArr = new int[] { 1, 2 };

            // Act
            int actualOutput = helperMethods.MergeAndCountNumberOfInversions(firstPart, secondPart, ref arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
            Assert.Equal(expectedArr, arr);
        }

        [Fact]
        public void ArrayWithNoInversion()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();

            int[] arr = new int[] { 1, 2, 3, 4, 5 };
            int[] firstPart = new int[] { 1, 2, 3 };
            int[] secondPart = new int[] { 4, 5 };
            int expectedOutput = 0;
            int[] expectedArr = new int[] { 1, 2, 3, 4, 5 };

            // Act
            int actualOutput = helperMethods.MergeAndCountNumberOfInversions(firstPart, secondPart, ref arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
            Assert.Equal(expectedArr, arr);
        }

        [Fact]
        public void ArrayWithMaxNumberOfInversions()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();

            int[] arr = new int[] { 6, 5, 4, 3, 2, 1 };
            int[] firstPart = new int[] { 4, 5, 6 };
            int[] secondPart = new int[] { 1, 2, 3 };
            int expectedOutput = 9;
            int[] expectedArr = new int[] { 1, 2, 3, 4, 5, 6 };

            // Act
            int actualOutput = helperMethods.MergeAndCountNumberOfInversions(firstPart, secondPart, ref arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
            Assert.Equal(expectedArr, arr);
        }

        [Fact]
        public void ArrayWithSomeNumberOfInversions()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();

            int[] arr = new int[] { 1, 5, 2, 3, 6, 4 };
            int[] firstPart = new int[] { 1, 2, 5 };
            int[] secondPart = new int[] { 3, 4, 6 };
            int expectedOutput = 2;
            int[] expectedArr = new int[] { 1, 2, 3, 4, 5, 6 };

            // Act
            int actualOutput = helperMethods.MergeAndCountNumberOfInversions(firstPart, secondPart, ref arr);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
            Assert.Equal(expectedArr, arr);
        }

    }
}
