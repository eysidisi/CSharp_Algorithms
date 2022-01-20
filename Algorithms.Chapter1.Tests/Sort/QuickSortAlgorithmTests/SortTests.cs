using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Part1.Sort.QuickSortAlgorithm;

namespace Algorithms.Part1.Tests.Sort.QuickSortAlgorithmTests
{
    public class SortTests
    {
        #region Pivot is the first element
        [Fact]
        public void OneElemetArray_Sorted()
        {
            // Arrange
            QuickSort quickSort = new QuickSort(new DumbPivotAlgorithm());
            var inputArr = new int[] { 1 };
            var expectedOutput = new int[] { 1 };

            // Act
            quickSort.Sort(ref inputArr, 0, inputArr.Count() - 1);

            // Assert
            Assert.Equal(inputArr, expectedOutput);
        }
        [Fact]
        public void TwoElemetArray_Sorted()
        {
            // Arrange
            QuickSort quickSort = new QuickSort(new DumbPivotAlgorithm());
            var inputArr = new int[] { 1, 2 };
            var expectedOutput = new int[] { 1, 2 };

            // Act
            quickSort.Sort(ref inputArr, 0, inputArr.Count() - 1);

            // Assert
            Assert.Equal(inputArr, expectedOutput);
        }

        [Fact]
        public void TwoElemetArray_Unsorted()
        {
            // Arrange
            QuickSort quickSort = new QuickSort(new DumbPivotAlgorithm());
            var inputArr = new int[] { 2, 1 };
            var expectedOutput = new int[] { 1, 2 };

            // Act
            quickSort.Sort(ref inputArr, 0, inputArr.Count() - 1);

            // Assert
            Assert.Equal(inputArr, expectedOutput);
        }

        [Fact]
        public void ThreeElement_Sorted()
        {
            // Arrange
            QuickSort quickSort = new QuickSort(new DumbPivotAlgorithm());
            var inputArr = new int[] { 1, 2, 3 };
            var expectedOutput = new int[] { 1, 2, 3 };

            // Act
            quickSort.Sort(ref inputArr, 0, inputArr.Count() - 1);

            // Assert
            Assert.Equal(inputArr, expectedOutput);
        }

        [Fact]
        public void ThreeElement_Unsorted()
        {
            // Arrange
            QuickSort quickSort = new QuickSort(new DumbPivotAlgorithm());
            var inputArr = new int[] { 2, 1, 3 };
            var expectedOutput = new int[] { 1, 2, 3 };

            // Act
            quickSort.Sort(ref inputArr, 0, inputArr.Count() - 1);

            // Assert
            Assert.Equal(inputArr, expectedOutput);
        }

        [Fact]
        public void RandomArray_Unsorted()
        {
            // Arrange
            QuickSort quickSort = new QuickSort(new DumbPivotAlgorithm());
            var numberOfLength = 10;
            var seedVal = 10;
            var inputArr = new int[numberOfLength];
            Random random = new Random(seedVal);

            for (int i = 0; i < numberOfLength; i++)
            {
                inputArr[i] = numberOfLength - i;
            }

            inputArr = inputArr.OrderBy(x => random.Next()).ToArray();

            int[] expectedOutput = inputArr.OrderBy(x => x).ToArray();

            // Act
            quickSort.Sort(ref inputArr, 0, inputArr.Count() - 1);

            // Assert
            Assert.Equal(expectedOutput,inputArr );
        }

        #endregion
    }
}
