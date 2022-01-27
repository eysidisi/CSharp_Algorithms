using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Part1.Sort.MergeSortAlgorithm;
using Xunit;

namespace Algorithms.Part1.Tests.Sort.MergeSortAlgorithm
{
    public class HelperMethodsTests
    {
        [Fact]
        public void GetArrFirstPart_ArrWithEvenNumberOfElements()
        {
            // Arrange
            HelperMethods helperMethods = new();

            int[] arr = new int[] { 1, 2, 3, 4 };
            int[] expectedResult = new int[] { 1, 2 };

            // Act
            int[] actualResult = helperMethods.GetArrFirstPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetArrFirstPart_ArrWithOddNumberOfElements()
        {
            // Arrange
            HelperMethods helperMethods = new();

            int[] arr = new int[] { 1, 2, 3 };
            int[] expectedResult = new int[] { 1 };

            // Act
            int[] actualResult = helperMethods.GetArrFirstPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetArrFirstPart_ArrWithOneElement()
        {
            // Arrange
            HelperMethods helperMethods = new();

            int[] arr = new int[] { 1 };
            int[] expectedResult = new int[] { };

            // Act
            int[] actualResult = helperMethods.GetArrFirstPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetArrFirstPart_ArrWithNoElement()
        {
            // Arrange
            HelperMethods helperMethods = new();

            int[] arr = new int[] { };
            int[] expectedResult = new int[] { };

            // Act
            int[] actualResult = helperMethods.GetArrFirstPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetArrSecondPart_ArrWithEvenNumberOfElements()
        {
            // Arrange
            HelperMethods helperMethods = new();

            int[] arr = new int[] { 1, 2, 3, 4 };
            int[] expectedResult = new int[] { 3, 4 };

            // Act
            int[] actualResult = helperMethods.GetSecondPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetArrSecondPart_ArrWithOddNumberOfElements()
        {
            // Arrange
            HelperMethods helperMethods = new();

            int[] arr = new int[] { 1, 2, 3 };
            int[] expectedResult = new int[] { 2, 3 };

            // Act
            int[] actualResult = helperMethods.GetSecondPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetArrSecondPart_ArrWithOneElement()
        {
            // Arrange
            HelperMethods helperMethods = new();

            int[] arr = new int[] { 1 };
            int[] expectedResult = new int[] { 1 };

            // Act
            int[] actualResult = helperMethods.GetSecondPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetArrSecondPart_ArrWithNoElement()
        {
            // Arrange
            HelperMethods helperMethods = new();

            int[] arr = new int[] { };
            int[] expectedResult = new int[] { };

            // Act
            int[] actualResult = helperMethods.GetSecondPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void MergeSortedArrays_ArrsWithNoElement()
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
        public void MergeSortedArrays_ArrWithNoElementArrWithTwoElements()
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
        public void MergeSortedArrays_ArrsWithEvenNumberOfElements()
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
