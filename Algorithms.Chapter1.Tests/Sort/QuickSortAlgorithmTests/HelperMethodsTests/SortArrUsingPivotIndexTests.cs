using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Part1.Sort.QuickSortAlgorithm;

namespace Algorithms.Part1.Tests.Sort.QuickSortAlgorithmTests.HelperMethodsTests
{
    public class SortArrUsingPivotIndexTests
    {
        [Fact]
        public void ArrWithLengthTwo_Unsorted()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            var arr = new int[] { 2, 1 };
            var expectedOutput = new int[] { 1, 2 };

            // Act
            helperMethods.SortArrUsingPivotIndex(ref arr, 0, 1, 1);

            // Assert
            Assert.Equal(expectedOutput, arr);
        }

        [Fact]
        public void ArrWithLengthTwo_Sorted()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            var arr = new int[] { 1, 2 };
            var expectedOutput = new int[] { 1, 2 };

            // Act
            helperMethods.SortArrUsingPivotIndex(ref arr, 0, 1, 1);

            // Assert
            Assert.Equal(expectedOutput, arr);
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

            var expectedSortedArr = new int[] { 1, 0, 2 };
            var expectedPivotIndex = 2;

            // Act
            var actualPivotIndex = helperMethods.SortArrUsingPivotIndex(ref arr, leftIndex, rightIndex, pivotIndex);

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

            var expectedSortedArr = new int[] { 0,1,2 };
            var expectedPivotIndex = 1;

            // Act
            var actualPivotIndex = helperMethods.SortArrUsingPivotIndex(ref arr, leftIndex, rightIndex, pivotIndex);

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

            var expectedSortedArr = new int[] { 0, 1, 2 };
            var expectedPivotIndex = 0;

            // Act
            var actualPivotIndex = helperMethods.SortArrUsingPivotIndex(ref arr, leftIndex, rightIndex, pivotIndex);

            // Assert
            Assert.Equal(expectedSortedArr, arr);
            Assert.Equal(expectedPivotIndex, actualPivotIndex);
        }


        [Fact]
        public void ArrWithLengthThree_Sorted()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();
            var arr = new int[] { 0, 1, 2 };
            int leftIndex = 0;
            int rightIndex = 2;
            int pivotIndex = 1;

            var expectedSortedArr = new int[] { 0,1,2 };
            var expectedPivotIndex = 1;

            // Act
            var actualPivotIndex = helperMethods.SortArrUsingPivotIndex(ref arr, leftIndex, rightIndex, pivotIndex);

            // Assert
            Assert.Equal(expectedSortedArr, arr);
            Assert.Equal(expectedPivotIndex, actualPivotIndex);
        }

    }
}
