using Algorithms.Part1.Sort.QuickSortAlgorithm;
using Algorithms.Part1.Sort.QuickSortAlgorithm.PivotElementAlgorithms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Algorithms.Part1.Tests.Sort.QuickSortAlgorithmTests
{
    public class AlgorithmSpeedComparisonTests
    {
        private readonly ITestOutputHelper output;

        public AlgorithmSpeedComparisonTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        public class LongUnsortedArrData
        {
            static IFindPivotAlgorithm firstElementAlgorithm = new FirstElementPivotAlgorithm();
            static IFindPivotAlgorithm lastElementAlgorithm = new LastElementPivotAlgorithm();
            static IFindPivotAlgorithm medianElementAlgorithm = new MedianOfThreePivotAlgorithm();
            static IFindPivotAlgorithm randomElementAlgorithm = new RandomPivotIndexAlgorithm();

            public static IEnumerable<object[]> algorithms =>
                new List<object[]>
                {
           new object[]{ firstElementAlgorithm,"First Element" },
           new object[]{ lastElementAlgorithm ,"Last Element"},
           new object[]{ medianElementAlgorithm,"Median Element"},
           new object[]{ randomElementAlgorithm,"Random Element"}
                };
        }


        [Theory(Skip ="Used for comparing the speed")]
        [MemberData(nameof(LongUnsortedArrData.algorithms), MemberType = typeof(LongUnsortedArrData))]
        public void TestSpeed(IFindPivotAlgorithm pivotAlgorithm, string algorithmName)
        {
            // Arrange
            QuickSort quickSort = new QuickSort(pivotAlgorithm);
            int numOfElements = 10000000;
            var arr = new int[numOfElements];

            for (int i = 0; i < numOfElements; i++)
            {
                arr[i] = i ;
            }

            Random rnd = new Random();
            arr = arr.OrderBy(x => rnd.Next()).ToArray();

            // Act
            Stopwatch stopwatch = Stopwatch.StartNew();
            quickSort.Sort(ref arr, 0, numOfElements - 1);
            stopwatch.Stop();

            // Log
            output.WriteLine($"Using algorithm {algorithmName} took {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
