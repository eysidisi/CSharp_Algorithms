using Algorithms.Part1.Search.RSelectAlgorithm;
using Algorithms.Part1.Sort.QuickSortAlgorithm.PivotElementAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Part1.Tests.Search.RSelectAlgorithm
{
    public class RSelectAlgorithmTests
    {
        [Fact]
        public void FindOrderStatistic_OneElementArr()
        {
            // Arrange
            RSelect rSelect = new RSelect(new FirstElementPivotAlgorithm());
            var arr = new int[] { 1 };
            int elementIndex = 1;
            int expectedOutput = 1;

            // Act
            var actualOutput = rSelect.FindOrderStatistic(arr, elementIndex);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void FindOrderStatistic_TwoElementSortedArr()
        {
            // Arrange
            RSelect rSelect = new RSelect(new FirstElementPivotAlgorithm());
            var arr = new int[] { 1, 2 };
            int elementIndex = 2;
            int expectedOutput = 2;

            // Act
            var actualOutput = rSelect.FindOrderStatistic(arr, elementIndex);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void FindOrderStatistic_TwoElementUnsortedArr()
        {
            // Arrange
            RSelect rSelect = new RSelect(new FirstElementPivotAlgorithm());
            var arr = new int[] { 2, 1 };
            int elementIndex = 1;
            int expectedOutput = 1;

            // Act
            var actualOutput = rSelect.FindOrderStatistic(arr, elementIndex);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void FindOrderStatistic_ThreeElementSortedArr()
        {
            // Arrange
            RSelect rSelect = new RSelect(new FirstElementPivotAlgorithm());
            var arr = new int[] { 1, 2, 3 };
            int elementIndex = 2;
            int expectedOutput = 2;

            // Act
            var actualOutput = rSelect.FindOrderStatistic(arr, elementIndex);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
        public class PivotFindingAlgorithms
        {
            static IFindPivotAlgorithm lastElementAlgorithm = new LastElementPivotAlgorithm();
            static IFindPivotAlgorithm randomElementAlgorithm = new RandomPivotIndexAlgorithm();

            public static IEnumerable<object[]> algorithms =>
                new List<object[]>
                {
           new object[]{ lastElementAlgorithm },
           new object[]{ randomElementAlgorithm}
                };
        }

        [Theory]
        [MemberData(nameof(PivotFindingAlgorithms.algorithms), MemberType = typeof(PivotFindingAlgorithms))]
        public void FindOrderStatistic_LongUnsortedArr(IFindPivotAlgorithm pivotAlgorithm)
        {
            // Arrange
            RSelect rSelect = new RSelect(pivotAlgorithm);
            int numOfElements = 1000;
            var arr = new int[numOfElements];

            for (int i = 0; i < numOfElements; i++)
            {
                arr[i] = i + 1;
            }

            int elementIndex = 500;
            int expectedOutput = 500;

            Random rnd = new Random();
            arr = arr.OrderBy(x => rnd.Next()).ToArray();

            // Act
            var actualOutput = rSelect.FindOrderStatistic(arr, elementIndex);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
