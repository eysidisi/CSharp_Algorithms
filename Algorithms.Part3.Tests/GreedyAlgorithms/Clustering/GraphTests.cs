using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Part3.GreedyAlgorithms.Clustering;
using Xunit;
namespace Algorithms.Part3.Tests.GreedyAlgorithms.Clustering
{
    public class GraphTests
    {
        [Fact]
        public void CalculateMaxSpacing_TwoNodes_ReturnsResult()
        {
            // Arrange
            int numOfNodes = 2;
            int node0ID = 0;
            int node1ID = 1;
            int distanceBetweenNodes = 5;
            int numberOfClusters = 2;

            Graph graph = new Graph(numOfNodes);
            graph.AddDistance(node0ID, node1ID, distanceBetweenNodes);

            int expectedMaxSpacing = 5;

            // Act
            int actualMaxSpacing = graph.CalculateMaxSpacing(numberOfClusters);

            // Assert
            Assert.Equal(expectedMaxSpacing, actualMaxSpacing);
        }

        [Theory]
        [InlineData(1, 3, 4, 3)]
        [InlineData(1, 1, 4, 1)]
        public void CalculateMaxSpacing_ThreeNodes_ReturnsResult(
            int distanceBetweenNodes0To1, int distanceBetweenNodes0To2, int distanceBetweenNodes1To2, int expectedMaxSpacing)
        {
            // Arrange
            int numOfNodes = 3;
            int node0ID = 0;
            int node1ID = 1;
            int node2ID = 2;

            int numberOfClusters = 2;

            Graph graph = new Graph(numOfNodes);
            graph.AddDistance(node0ID, node1ID, distanceBetweenNodes0To1);
            graph.AddDistance(node0ID, node2ID, distanceBetweenNodes0To2);
            graph.AddDistance(node1ID, node2ID, distanceBetweenNodes1To2);


            // Act
            int actualMaxSpacing = graph.CalculateMaxSpacing(numberOfClusters);

            // Assert
            Assert.Equal(expectedMaxSpacing, actualMaxSpacing);
        }

        [Fact]
        public void CalculateMaxSpacing_ComplexGraph_ReturnsResult()
        {
            // Arrange
            int numOfNodes = 9;
            Graph graph = new Graph(numOfNodes);

            int distanceBetweenNodes0To3 = 2;
            int distanceBetweenNodes0To7 = 6;
            int distanceBetweenNodes0To8 = 7;
            graph.AddDistance(0, 3, distanceBetweenNodes0To3);
            graph.AddDistance(0, 7, distanceBetweenNodes0To7);
            graph.AddDistance(0, 8, distanceBetweenNodes0To8);

            int distanceBetweenNodes1To2 = 4;
            int distanceBetweenNodes1To8 = 8;
            graph.AddDistance(1, 2, distanceBetweenNodes1To2);
            graph.AddDistance(1, 8, distanceBetweenNodes1To8);

            int distanceBetweenNodes2To3 = 8;
            int distanceBetweenNodes2To8 = 11;
            graph.AddDistance(2, 3, distanceBetweenNodes2To3);
            graph.AddDistance(2, 8, distanceBetweenNodes2To8);

            int distanceBetweenNodes3To4 = 7;
            int distanceBetweenNodes3To6 = 4;
            graph.AddDistance(3, 4, distanceBetweenNodes3To4);
            graph.AddDistance(3, 6, distanceBetweenNodes3To6);

            int distanceBetweenNodes4To5 = 9;
            graph.AddDistance(4, 5, distanceBetweenNodes4To5);

            int distanceBetweenNodes5To6 = 10;
            graph.AddDistance(5, 6, distanceBetweenNodes5To6);

            int distanceBetweenNodes6To7 = 2;
            graph.AddDistance(6, 7, distanceBetweenNodes6To7);

            int distanceBetweenNodes7To8 = 1;
            graph.AddDistance(7, 8, distanceBetweenNodes7To8);

            int expectedMaxSpacing = 7;
            int numberOfClusters = 4;

            // Act
            int actualMaxSpacing = graph.CalculateMaxSpacing(numberOfClusters);

            // Assert
            Assert.Equal(expectedMaxSpacing, actualMaxSpacing);
        }

        [Fact(Skip ="Takes too long!")]
        public void CalculateMaxSpacing_CourseraAssignment()
        {
            string path = Directory.GetCurrentDirectory() + @"\GreedyAlgorithms\Clustering\InputFiles\clustering.txt";

            Graph graph = Graph.ReadFile(path);

            int result = graph.CalculateMaxSpacing(4);

            Assert.Equal(4, result);
        }
    }
}
