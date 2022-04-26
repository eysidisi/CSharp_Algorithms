using Algorithms.Part3.DynamicProgramming;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Algorithms.Part3.Tests.DynamicProgramming
{
    public class GraphTests
    {

        private readonly ITestOutputHelper log;

        public GraphTests(ITestOutputHelper output)
        {
            this.log = output;
        }

        [Theory]
        [InlineData(new int[] { 1, 5 }, 5, new int[] { 1 })]
        [InlineData(new int[] { 5, 1 }, 5, new int[] { 0 })]
        public void CalculateMaximumWeightedIndependentSet_TwoNodes(int[] nodes, long expectedResult, int[] expectedUsedNodeIds)
        {
            Graph graph = new Graph(nodes);

            long actualResult = graph.CalculateMaximumWeightedIndependentSet();
            List<int> actualUsedNodeIDs = graph.UsedNodeIds.ToList();

            Assert.Equal(expectedResult, actualResult);
            Assert.Equal(expectedUsedNodeIds.ToList(), actualUsedNodeIDs);
        }

        [Theory]
        [InlineData(new int[] { 1, 5, 2 }, 5, new int[] { 1 })]
        [InlineData(new int[] { 5, 3, 1 }, 6, new int[] { 2, 0 })]
        public void CalculateMaximumWeightedIndependentSet_ThreeNodes(int[] nodes, long expectedResult, int[] expectedUsedNodeIds)
        {
            Graph graph = new Graph(nodes);

            long actualResult = graph.CalculateMaximumWeightedIndependentSet();
            List<int> actualUsedNodeIDs = graph.UsedNodeIds.ToList();

            Assert.Equal(expectedResult, actualResult);
            Assert.Equal(expectedUsedNodeIds.ToList(), actualUsedNodeIDs);
        }

        [Theory]
        [InlineData(new int[] { 1, 5, 2, 4 }, 9, new int[] { 3, 1 })]
        [InlineData(new int[] { 5, 3, 4, 1 }, 9, new int[] { 2, 0 })]
        [InlineData(new int[] { 5, 3, 1, 4 }, 9, new int[] { 3, 0 })]
        public void CalculateMaximumWeightedIndependentSet_FourNodes(int[] nodes, long expectedResult, int[] expectedUsedNodeIds)
        {
            Graph graph = new Graph(nodes);

            long actualResult = graph.CalculateMaximumWeightedIndependentSet();
            List<int> actualUsedNodeIDs = graph.UsedNodeIds.ToList();

            Assert.Equal(expectedResult, actualResult);
            Assert.Equal(expectedUsedNodeIds.ToList(), actualUsedNodeIDs);
        }
        [Fact]
        public void CalculateMaximumWeightedIndependentSet_CourseraAssignment()
        {
            string filePath = Directory.GetCurrentDirectory() + @"/DynamicProgramming/InputFiles/mwis.txt";

            Graph graph = new Graph(filePath);

            graph.CalculateMaximumWeightedIndependentSet();

            List<int> nodeIdsToCheck = new List<int>() { 0, 1, 2, 3, 16, 116, 516, 996 };

            string output="";

            foreach (var nodeId in nodeIdsToCheck)
            {
                if (graph.UsedNodeIds.Contains(nodeId))
                {
                    output += "1";
                }
                else
                {
                    output += "0";
                }
            }

            log.WriteLine(output);
        }
    }
}
