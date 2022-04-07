using Algorithms.Part3.GreedyAlgorithms;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Algorithms.Part3.Tests.GreedyAlgorithms
{
    public class SchedulingAlgorithmsTests
    {
        private readonly ITestOutputHelper output;

        public SchedulingAlgorithmsTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void CalculateWeightedSumUsingDifference_OneJob_ReturnsWeightedCompletion()
        {
            // Arrange
            SchedulingAlgorithms schedulingAlgorithms = new SchedulingAlgorithms();

            Job job = new Job(weight: 2, length: 3);
            var jobs = new Job[] { job };
            int expectedOutput = 6;

            // Act
            var actualOutput = schedulingAlgorithms.CalculateWeightedSumUsingDifference(jobs);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }


        [Theory]
        [MemberData(nameof(TwoJobsData))]
        public void CalculateWeightedSumUsingDifference_TwoJobs_ReturnsWeightedCompletion(Job job1, Job job2, int expectedOutput)
        {
            // Arrange
            SchedulingAlgorithms schedulingAlgorithms = new SchedulingAlgorithms();
            Job[] jobs = new Job[] { job1, job2 };

            // Act
            var actualOutput = schedulingAlgorithms.CalculateWeightedSumUsingDifference(jobs);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
        public static IEnumerable<object[]> TwoJobsData =>
    new List<object[]>
    {
            new object[] { new Job(2,5), new Job(3,4), 30},
            new object[] { new Job(3,5), new Job(2,3), 31},
            new object[] { new Job(3,1), new Job(4,2), 17}
    };
        [Fact]
        public void CourseraAssignment()
        {
            string filePath=Directory.GetCurrentDirectory()+ @"\GreedyAlgorithms\InputFiles\courseraAssignment.txt";
            
            SchedulingAlgorithms schedulingAlgorithms = new SchedulingAlgorithms();
            
            Job[] jobs = schedulingAlgorithms.ReadFile(filePath);

            var weightedSum = schedulingAlgorithms.CalculateWeightedSumUsingDifference(jobs);

            output.WriteLine(weightedSum.ToString());
        }
    }
}