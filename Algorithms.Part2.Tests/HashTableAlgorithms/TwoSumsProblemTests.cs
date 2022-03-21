using Algorithms.Part2.HashTableAlgorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Algorithms.Part2.Tests.HashTableAlgorithms
{
    public class TwoSumsProblemTests
    {
        private readonly ITestOutputHelper output;

        public TwoSumsProblemTests(ITestOutputHelper output)
        {
            this.output = output;
        }


        [Theory]
        [InlineData(new int[] { 1 }, new bool[] { false, false }, new int[] { 1, 2 })]
        [InlineData(new int[] { 1, 2, 3 }, new bool[] { true, true, true, false }, new int[] { 3, 4, 5, -1 })]
        [InlineData(new int[] { 1, 2, 3, 1, 1, 0, -10 }, new bool[] { true, true, true, true, false, false }, new int[] { 2, 1, -10, -8, 15, -20 })]
        public void CheckIfSumExists_ReturnsTrue(int[] arr, bool[] expectedResults, int[] sums)
        {
            TwoSumsProblem twoSumsProblem = new TwoSumsProblem(arr);

            for (int i = 0; i < expectedResults.Length; i++)
            {
                int sum = sums[i];
                bool actualResult = twoSumsProblem.CheckIfSumExists(sum);
                Assert.Equal(expectedResults[i], actualResult);
            }
        }

        [Fact(Skip = "Coursera Assignment")]
        public void CourseraAssignment()
        {
            string inputFolderPath = Directory.GetCurrentDirectory() + @"\HashTableAlgorithms\InputFiles\Coursera.txt";

            TwoSumsProblem twoSumsProblem = new TwoSumsProblem(inputFolderPath);

            int numOfSums = 0;
            object lockObj = new object();

            Parallel.For(-10000, 10001, targetSum =>
             {
                 if (twoSumsProblem.CheckIfSumExists(targetSum))
                 {
                     lock (lockObj)
                     {
                         numOfSums++;
                     }
                 }
             });


            output.WriteLine(numOfSums.ToString());
        }
    }
}
