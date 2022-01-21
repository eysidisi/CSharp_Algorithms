using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Part1.Sort.QuickSortAlgorithm;

namespace Algorithms.Part1.Tests.Sort.QuickSortAlgorithmTests.HelperMethodsTests
{
    public class PartitionArrTests
    {
        [Fact]
        public void ArrWithLengthTwo_Unsorted()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            var arr = new int[] { 2, 1 };
            var expectedOutput = new int[] { 1, 2 };
            var expectedIndex = 1;

            int leftIndex = 0;
            int rightIndex = 1;
            int pivotIndex = 0;

            // Act
            var actualIndex = helperMethods.PartitionArr(ref arr, leftIndex, rightIndex, pivotIndex);

            // Assert
            Assert.Equal(expectedOutput, arr);
            Assert.Equal(expectedIndex, actualIndex);

        }

        [Fact]
        public void ArrWithLengthTwo_Sorted()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            var arr = new int[] { 1, 2 };
            var expectedOutput = new int[] { 1, 2 };
            var expectedIndex = 0;

            int leftIndex = 0;
            int rightIndex = 1;
            int pivotIndex = 0;

            // Act
            var actualIndex = helperMethods.PartitionArr(ref arr, leftIndex, rightIndex, pivotIndex);

            // Assert
            Assert.Equal(expectedOutput, arr);
            Assert.Equal(expectedIndex, actualIndex);
        }

        [Fact]
        public void ArrWithLengthThree_Unsorted_PivotMiddleElement()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            var arr = new int[] { 1, 2, 0 };
            int leftIndex = 0;
            int rightIndex = 2;
            int pivotIndex = 1;

            var expectedSortedArr = new int[] { 0,1, 2 };
            var expectedPivotIndex = 2;

            // Act
            var actualPivotIndex = helperMethods.PartitionArr(ref arr, leftIndex, rightIndex, pivotIndex);

            // Assert
            Assert.Equal(expectedSortedArr, arr);
            Assert.Equal(expectedPivotIndex, actualPivotIndex);
        }

        [Fact]
        public void ArrWithLengthThree_Unsorted_PivotFirstElement()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            var arr = new int[] { 1, 2, 0 };
            int leftIndex = 0;
            int rightIndex = 2;
            int pivotIndex = 0;

            var expectedSortedArr = new int[] { 0, 1, 2 };
            var expectedPivotIndex = 1;

            // Act
            var actualPivotIndex = helperMethods.PartitionArr(ref arr, leftIndex, rightIndex, pivotIndex);

            // Assert
            Assert.Equal(expectedSortedArr, arr);
            Assert.Equal(expectedPivotIndex, actualPivotIndex);
        }

        [Fact]
        public void ArrWithLengthThree_Unsorted_PivotLastElement()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            var arr = new int[] { 1, 2, 0 };
            int leftIndex = 0;
            int rightIndex = 2;
            int pivotIndex = 2;

            var expectedSortedArr = new int[] { 0, 2, 1 };
            var expectedPivotIndex = 0;

            // Act
            var actualPivotIndex = helperMethods.PartitionArr(ref arr, leftIndex, rightIndex, pivotIndex);

            // Assert
            Assert.Equal(expectedSortedArr, arr);
            Assert.Equal(expectedPivotIndex, actualPivotIndex);
        }

        [Fact]
        public void ArrWithLengthThree_Sorted_PivotFirstElement()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            var arr = new int[] { 0, 1, 2 };
            int leftIndex = 0;
            int rightIndex = 2;
            int pivotIndex = 0;

            var expectedSortedArr = new int[] { 0, 1, 2 };
            var expectedPivotIndex = 0;

            // Act
            var actualPivotIndex = helperMethods.PartitionArr(ref arr, leftIndex, rightIndex, pivotIndex);

            // Assert
            Assert.Equal(expectedSortedArr, arr);
            Assert.Equal(expectedPivotIndex, actualPivotIndex);
        }


        [Fact]
        public void ArrWithLengthThree_Sorted_PivotMiddleElement()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            var arr = new int[] { 0, 1, 2 };
            int leftIndex = 0;
            int rightIndex = 2;
            int pivotIndex = 1;

            var expectedSortedArr = new int[] { 0, 1, 2 };
            var expectedPivotIndex = 1;

            // Act
            var actualPivotIndex = helperMethods.PartitionArr(ref arr, leftIndex, rightIndex, pivotIndex);

            // Assert
            Assert.Equal(expectedSortedArr, arr);
            Assert.Equal(expectedPivotIndex, actualPivotIndex);
        }

        [Fact]
        public void ArrWithLengthThree_Sorted_PivotLastElement()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            var arr = new int[] { 0, 1, 2 };
            int leftIndex = 0;
            int rightIndex = 2;
            int pivotIndex = 2;

            var expectedSortedArr = new int[] { 0, 1, 2 };
            var expectedPivotIndex = 2;

            // Act
            var actualPivotIndex = helperMethods.PartitionArr(ref arr, leftIndex, rightIndex, pivotIndex);

            // Assert
            Assert.Equal(expectedSortedArr, arr);
            Assert.Equal(expectedPivotIndex, actualPivotIndex);
        }

        [Fact]
        public void LongArr_Unsorted_PivotSmallestElement()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            var arr = new int[] { -3, -5, 2, -7, 13, 0 };
            int leftIndex = 1;
            int rightIndex = 4;
            int pivotIndex = 3;

            var expectedSortedArr = new int[] { -3, -7, 2, -5, 13, 0 };
            var expectedPivotIndex = 1;

            // Act
            var actualPivotIndex = helperMethods.PartitionArr(ref arr, leftIndex, rightIndex, pivotIndex);

            // Assert
            Assert.Equal(expectedSortedArr, arr);
            Assert.Equal(expectedPivotIndex, actualPivotIndex);
        }

        [Fact]
        public void LongArr_Unsorted_PivotLargestElement()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            var arr = new int[] { -3, -5, 2, 13, -7, 0 };
            int leftIndex = 1;
            int rightIndex = 4;
            int pivotIndex = 3;

            var expectedSortedArr = new int[] { -3, -7, 2, -5, 13, 0 };
            var expectedPivotIndex = 4;

            // Act
            var actualPivotIndex = helperMethods.PartitionArr(ref arr, leftIndex, rightIndex, pivotIndex);

            // Assert
            Assert.Equal(expectedSortedArr, arr);
            Assert.Equal(expectedPivotIndex, actualPivotIndex);
        }
    }
}
