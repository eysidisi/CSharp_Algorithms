using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Part1.Sort.QuickSortAlgorithm;
using Algorithms.Part1.FileIO;
using System.IO;
using Algorithms.Part1.Sort.QuickSortAlgorithm.PivotElementAlgorithms;

namespace Algorithms.Part1.Tests.Sort.QuickSortAlgorithmTests
{
    public class SortTests
    {
        [Fact]
        public void OneElemetArray_Sorted()
        {
            // Arrange
            QuickSort quickSort = new QuickSort(new FirstElementPivotAlgorithm());
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
            QuickSort quickSort = new QuickSort(new FirstElementPivotAlgorithm());
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
            QuickSort quickSort = new QuickSort(new FirstElementPivotAlgorithm());
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
            QuickSort quickSort = new QuickSort(new FirstElementPivotAlgorithm());
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
            QuickSort quickSort = new QuickSort(new FirstElementPivotAlgorithm());
            var inputArr = new int[] { 2, 1, 3 };
            var expectedOutput = new int[] { 1, 2, 3 };

            // Act
            quickSort.Sort(ref inputArr, 0, inputArr.Count() - 1);

            // Assert
            Assert.Equal(inputArr, expectedOutput);
        }

        [Fact]
        public void RandomArray_Unsorted_FirstIndexPivot()
        {
            // Arrange
            QuickSort quickSort = new QuickSort(new FirstElementPivotAlgorithm());
            var numberOfElements = 10000;
            var seedVal = 10;
            var inputArr = new int[numberOfElements];
            Random random = new Random(seedVal);

            for (int i = 0; i < numberOfElements; i++)
            {
                inputArr[i] = numberOfElements - i;
            }

            // Randomize array
            inputArr = inputArr.OrderBy(x => random.Next()).ToArray();

            int[] expectedOutput = inputArr.OrderBy(x => x).ToArray();

            // Act
            quickSort.Sort(ref inputArr, 0, inputArr.Count() - 1);

            // Assert
            Assert.Equal(expectedOutput, inputArr);
        }

        [Fact]
        public void CourseraAssignment_PivotElementIsTheFirstElement()
        {
            // Arrange
            QuickSort quickSort = new QuickSort(new FirstElementPivotAlgorithm());
            string inputFilePath = Directory.GetCurrentDirectory() + @"\Sort\QuickSortAlgorithmTests\InputFiles\QuickSort.txt";
            FileManager fileManager = new FileManager();

            var inputArr = fileManager.ReadFileIntoIntArray(inputFilePath);

            int[] expectedOutput = inputArr.OrderBy(x => x).ToArray();

            // Act
            quickSort.Sort(ref inputArr, 0, inputArr.Count() - 1);

            // Assert
            Assert.Equal(expectedOutput, inputArr);
        }

        [Fact]
        public void CourseraAssignment_PivotElementIsTheLastElement()
        {
            // Arrange
            QuickSort quickSort = new QuickSort(new LastElementPivotAlgorithm());
            string inputFilePath = Directory.GetCurrentDirectory() + @"\Sort\QuickSortAlgorithmTests\InputFiles\QuickSort.txt";
            FileManager fileManager = new FileManager();

            var inputArr = fileManager.ReadFileIntoIntArray(inputFilePath);

            int[] expectedOutput = inputArr.OrderBy(x => x).ToArray();

            // Act
            quickSort.Sort(ref inputArr, 0, inputArr.Count() - 1);

            // Assert
            Assert.Equal(expectedOutput, inputArr);
        }
        
        [Fact]
        public void CourseraAssignment_PivotElementIsTheMedian()
        {
            // Arrange
            QuickSort quickSort = new QuickSort(new MedianOfThreePivotAlgorithm());
            string inputFilePath = Directory.GetCurrentDirectory() + @"\Sort\QuickSortAlgorithmTests\InputFiles\QuickSort.txt";
            FileManager fileManager = new FileManager();

            var inputArr = fileManager.ReadFileIntoIntArray(inputFilePath);

            int[] expectedOutput = inputArr.OrderBy(x => x).ToArray();

            // Act
            quickSort.Sort(ref inputArr, 0, inputArr.Count() - 1);

            // Assert
            Assert.Equal(expectedOutput, inputArr);
        }
    }
}
