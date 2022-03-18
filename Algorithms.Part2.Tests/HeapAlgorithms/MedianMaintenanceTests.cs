using Algorithms.Part2.HeapAlgorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Algorithms.Part2.Tests.HeapAlgorithms
{
    public class MedianMaintenanceTests
    {
        private readonly ITestOutputHelper output;

        public MedianMaintenanceTests(ITestOutputHelper output)
        {
            this.output = output;
        }


        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 1, 2, 2, 3, 3 })]
        [InlineData(new int[] { 6, 5, 4, 3, 2, 1 }, new int[] { 6, 5, 5, 4, 4, 3 })]
        [InlineData(new int[] { 5, 1, 3, 2, 10 }, new int[] { 5, 1, 3, 2, 3 })]
        [InlineData(new int[] { 23, 9, 35, 4, 13, 24, 2, 5, 27, 1, 34, 8, 15, 39, 32, 22, 29, 21, 19, 20, 36, 33, 7, 31, 14, 17, 26, 16, 38, 6, 30, 40, 25, 28, 11, 37, 3, 10, 18, 12 }, new int[] { 23, 9, 23, 9, 13, 13, 13, 9, 13, 9, 13, 9, 13, 13, 15, 15, 22, 21, 21, 20, 21, 21, 21, 21, 21, 20, 21, 20, 21, 20, 21, 21, 22, 22, 22, 22, 22, 21, 21, 20 })]
        public void GetMedian_ReturnsMedian(int[] input, int[] expectedMedians)
        {
            // Arrange
            MinHeap minHeap = new MinHeap();
            MaxHeap maxHeap = new MaxHeap();
            MedianMaintenance medianMaintenance = new MedianMaintenance(minHeap, maxHeap);

            // Act
            List<int> actualMedians = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                int element = input[i];
                medianMaintenance.AddElement(element);
                actualMedians.Add(medianMaintenance.GetMedian());
            }

            // Assert
            Assert.Equal(expectedMedians, actualMedians.ToArray());
        }

        [Theory]
        [InlineData(new int[] { 1, 666, 10, 667, 100, 2, 3 }, 142)]
        [InlineData(new int[] { 6331, 2793, 1640, 9290, 225, 625, 6195, 2303, 5685, 1354 }, 9335)]
        public void MedianSums(int[] input, int expectedSum)
        {
            // Arrange
            MinHeap minHeap = new MinHeap();
            MaxHeap maxHeap = new MaxHeap();
            MedianMaintenance medianMaintenance = new MedianMaintenance(minHeap, maxHeap);

            // Act
            List<int> medians = new List<int>();
            for (int i = 0; i < input.Count(); i++)
            {
                int num = input[i];

                medianMaintenance.AddElement(num);

                medians.Add(medianMaintenance.GetMedian());
            }

            int actualSum = medians.Sum() % 10000;

            Assert.Equal(expectedSum, actualSum);
        }

        [Fact]
        public void MedianSums_InputFromTextFiles()
        {
            // Arrange

            string inputFolderPath = Directory.GetCurrentDirectory() + @"\HeapAlgorithms\InputFiles";
            var files = Directory.GetFiles(inputFolderPath);

            for (int fileIndex = 1; fileIndex < 45; fileIndex++)
            {
                MinHeap minHeap = new MinHeap(10000);
                MaxHeap maxHeap = new MaxHeap(10000);
                MedianMaintenance medianMaintenance = new MedianMaintenance(minHeap, maxHeap);

                string inputFileInitials = "input_random_" + fileIndex + "_";

                string inputFilePath = files.Where(f => Regex.Match(f, inputFileInitials).Success == true).First();

                List<int> input = medianMaintenance.ReadInputFile(inputFilePath);

                string outputFileInitials = "output_random_" + fileIndex + "_";

                string outputFilePath = files.Where(f => Regex.Match(f, outputFileInitials).Success == true).First();

                int expectedSum = int.Parse(File.ReadAllLines(outputFilePath)[0]);

                List<int> medians = new List<int>();

                for (int i = 0; i < input.Count; i++)
                {
                    int num = input[i];

                    medianMaintenance.AddElement(num);

                    medians.Add(medianMaintenance.GetMedian());
                }

                int actualSum = medians.Sum() % 10000;

                output.WriteLine(fileIndex.ToString());

                Assert.Equal(expectedSum, actualSum);
            }
        }
        [Fact]
        public void CourseraAssignment()
        {
            // Arrange

            MinHeap minHeap = new MinHeap();
            MaxHeap maxHeap = new MaxHeap();
            MedianMaintenance medianMaintenance = new MedianMaintenance(minHeap, maxHeap);

            string inputFilePath = Directory.GetCurrentDirectory() + @"\HeapAlgorithms\InputFiles\CourseraData.txt";

            var input = medianMaintenance.ReadInputFile(inputFilePath);

            List<int> medians = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                int num = input[i];

                medianMaintenance.AddElement(num);

                medians.Add(medianMaintenance.GetMedian());
            }

            int actualSum = medians.Sum() % 10000;

            output.WriteLine(actualSum.ToString());
        }

    }
}
