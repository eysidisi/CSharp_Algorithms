using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Part1.Sort.MergeSortAlgorithm;
using Xunit;

namespace Algorithms.Part1.Tests.Sort.MergeSortAlgorithm
{
    public class MergeSortHelperMethodsTests
    {
        [Fact]
        public void GetArrFirstPart_ArrWithEvenNumberOfElements()
        {
            // Arrange
            

            int[] arr = new int[] { 1, 2, 3, 4 };
            int[] expectedResult = new int[] { 1, 2 };

            // Act
            int[] actualResult = MergeSortHelperMethods.GetArrFirstPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetArrFirstPart_ArrWithOddNumberOfElements()
        {
            // Arrange
            

            int[] arr = new int[] { 1, 2, 3 };
            int[] expectedResult = new int[] { 1 };

            // Act
            int[] actualResult = MergeSortHelperMethods.GetArrFirstPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetArrFirstPart_ArrWithOneElement()
        {
            // Arrange
            

            int[] arr = new int[] { 1 };
            int[] expectedResult = new int[] { };

            // Act
            int[] actualResult = MergeSortHelperMethods.GetArrFirstPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetArrFirstPart_ArrWithNoElement()
        {
            // Arrange
            

            int[] arr = new int[] { };
            int[] expectedResult = new int[] { };

            // Act
            int[] actualResult = MergeSortHelperMethods.GetArrFirstPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetArrSecondPart_ArrWithEvenNumberOfElements()
        {
            // Arrange
            

            int[] arr = new int[] { 1, 2, 3, 4 };
            int[] expectedResult = new int[] { 3, 4 };

            // Act
            int[] actualResult = MergeSortHelperMethods.GetSecondPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetArrSecondPart_ArrWithOddNumberOfElements()
        {
            // Arrange
            

            int[] arr = new int[] { 1, 2, 3 };
            int[] expectedResult = new int[] { 2, 3 };

            // Act
            int[] actualResult = MergeSortHelperMethods.GetSecondPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetArrSecondPart_ArrWithOneElement()
        {
            // Arrange
            

            int[] arr = new int[] { 1 };
            int[] expectedResult = new int[] { 1 };

            // Act
            int[] actualResult = MergeSortHelperMethods.GetSecondPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void GetArrSecondPart_ArrWithNoElement()
        {
            // Arrange
            

            int[] arr = new int[] { };
            int[] expectedResult = new int[] { };

            // Act
            int[] actualResult = MergeSortHelperMethods.GetSecondPart(arr);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void MergeSortedArrays_ArrsWithNoElement()
        {
            // Arrange
            
            int[] arr1 = new int[0];
            int[] arr2 = new int[0];

            int[] expectedResult = new int[] { };

            // Act
            var actualResult = MergeSortHelperMethods.MergeSortedArrays(arr1, arr2);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void MergeSortedArrays_ArrWithNoElementArrWithTwoElements()
        {
            // Arrange
            

            int[] arr1 = new int[0];
            int[] arr2 = new int[2] { 1, 2 };

            int[] expectedResult = new int[] { 1, 2 };

            // Act
            var actualResult = MergeSortHelperMethods.MergeSortedArrays(arr1, arr2);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void MergeSortedArrays_ArrsWithEvenNumberOfElements()
        {
            // Arrange
            

            int[] arr1 = new int[2] { 1, 2 };
            int[] arr2 = new int[4] { -50, -1, 0, 1 };

            int[] expectedResult = new int[] { -50, -1, 0, 1, 1, 2 };

            // Act
            var actualResult = MergeSortHelperMethods.MergeSortedArrays(arr1, arr2);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
