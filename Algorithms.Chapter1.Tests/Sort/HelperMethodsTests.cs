using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Part1.Sort;
using Xunit;

namespace Algorithms.Part1.Tests.Sort
{
    public class HelperMethodsTests
    {
        [Fact]
        public void FirstPartOfArr_ArrWithEvenNumberOfElements_ReturnsFirstPart()
        {
            // Arrange
            HelperMethods helperMethods = new();

            int[] arr = new int[] { 1, 2, 3, 4 };
            int[] expectedResult = new int[] { 1, 2 };

            // Act
            int[] actualResult = helperMethods.FirstPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void FirstPartOfArr_ArrWithOddNumberOfElements_ReturnsFirstPart()
        {
            // Arrange
            HelperMethods helperMethods = new();

            int[] arr = new int[] { 1, 2, 3 };
            int[] expectedResult = new int[] { 1 };

            // Act
            int[] actualResult = helperMethods.FirstPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void FirstPartOfArr_ArrWithOneElement_ReturnsFirstPart()
        {
            // Arrange
            HelperMethods helperMethods = new();

            int[] arr = new int[] { 1 };
            int[] expectedResult = new int[] { };

            // Act
            int[] actualResult = helperMethods.FirstPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void FirstPartOfArr_ArrWithNoElement_ReturnsFirstPart()
        {
            // Arrange
            HelperMethods helperMethods = new();

            int[] arr = new int[] { };
            int[] expectedResult = new int[] { };

            // Act
            int[] actualResult = helperMethods.FirstPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void SecondPartOfArr_ArrWithEvenNumberOfElements_ReturnsSecondPart()
        {
            // Arrange
            HelperMethods helperMethods = new();

            int[] arr = new int[] { 1, 2, 3, 4 };
            int[] expectedResult = new int[] { 3, 4 };

            // Act
            int[] actualResult = helperMethods.SecondPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void SecondPartOfArr_ArrWithOddNumberOfElements_ReturnsSecondPart()
        {
            // Arrange
            HelperMethods helperMethods = new();

            int[] arr = new int[] { 1, 2, 3 };
            int[] expectedResult = new int[] { 2, 3 };

            // Act
            int[] actualResult = helperMethods.SecondPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void SecondPartOfArr_ArrWithOneElement_ReturnsSecondPart()
        {
            // Arrange
            HelperMethods helperMethods = new();

            int[] arr = new int[] { 1 };
            int[] expectedResult = new int[] { 1 };

            // Act
            int[] actualResult = helperMethods.SecondPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void SecondPartOfArr_ArrWithNoElement_ReturnsSecondPart()
        {
            // Arrange
            HelperMethods helperMethods = new();

            int[] arr = new int[] { };
            int[] expectedResult = new int[] { };

            // Act
            int[] actualResult = helperMethods.SecondPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Merge_ArrsWithNoElement_ReturnsMergedArr()
        {
            // Arrange
            HelperMethods helperMethods = new();

            int[] arr1 = new int[0];
            int[] arr2 = new int[0];

            int[] expectedResult = new int[] { };

            // Act
            var actualResult = helperMethods.MergeSortedArrays(arr1, arr2);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Merge_ArrWithNoElementArrWithTwoElements_ReturnsMergedArr()
        {
            // Arrange
            HelperMethods helperMethods = new();

            int[] arr1 = new int[0];
            int[] arr2 = new int[2] { 1, 2 };

            int[] expectedResult = new int[] { 1, 2 };

            // Act
            var actualResult = helperMethods.MergeSortedArrays(arr1, arr2);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
        [Fact]
        public void Merge_ArrsWithEvenNumberOfElements_ReturnsMergedArr()
        {
            // Arrange
            HelperMethods helperMethods = new();

            int[] arr1 = new int[2] { 1, 2 };
            int[] arr2 = new int[4] { -50, -1, 0, 1 };

            int[] expectedResult = new int[] { -50, -1, 0, 1, 1, 2 };

            // Act
            var actualResult = helperMethods.MergeSortedArrays(arr1, arr2);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

    }
}
