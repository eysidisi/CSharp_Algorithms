using Algorithms.Part2.GraphAlgorithms.DijkstrasAlgorithm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Part2.Tests.GraphAlgorithms.DijkstrasAlgorithm
{
    public class DijkstrasAlgorithmTests
    {
        // 0-1-2
        [Fact]
        public void CalculateShortestDistanceFromVertex_StraightGraphWithWeight1_ReturnsShortestPaths()
        {
            // Arrange
            Dijkstra dijkstra = new Dijkstra();
            UndirectedGraph graph = new UndirectedGraph(3);
            graph.AddEdge(0, 1, 1);
            graph.AddEdge(1, 2, 1);

            var expectedDistancesTo0 = new int[] { 0, 1, 2 };
            var expectedDistancesTo1 = new int[] { 1, 0, 1 };
            var expectedDistancesTo2 = new int[] { 2, 1, 0 };

            // Act
            int[] actualDistancesTo0 = dijkstra.FindClosestDistances(graph, 0);
            int[] actualDistancesTo1 = dijkstra.FindClosestDistances(graph, 1);
            int[] actualDistancesTo2 = dijkstra.FindClosestDistances(graph, 2);

            // Assert
            Assert.Equal(expectedDistancesTo0, actualDistancesTo0);
            Assert.Equal(expectedDistancesTo1, actualDistancesTo1);
            Assert.Equal(expectedDistancesTo2, actualDistancesTo2);
        }

        //     2
        //    / \
        // 0-1- -3
        [Fact]
        public void CalculateShortestDistanceFromVertex_ComplexGraphWithDifferentWeights_ReturnsShortestPaths()
        {
            // Arrange
            Dijkstra dijkstra = new Dijkstra();
            UndirectedGraph graph = new UndirectedGraph(4);

            graph.AddEdge(0, 1, 2);
            graph.AddEdge(1, 2, 3);
            graph.AddEdge(1, 3, 5);
            graph.AddEdge(2, 3, 1);

            var expectedDistancesTo0 = new int[] { 0, 2, 5, 6 };
            var expectedDistancesTo1 = new int[] { 2, 0, 3, 4 };
            var expectedDistancesTo2 = new int[] { 5, 3, 0, 1 };
            var expectedDistancesTo3 = new int[] { 6, 4, 1, 0 };

            // Act
            int[] actualDistancesTo0 = dijkstra.FindClosestDistances(graph, 0);
            int[] actualDistancesTo1 = dijkstra.FindClosestDistances(graph, 1);
            int[] actualDistancesTo2 = dijkstra.FindClosestDistances(graph, 2);
            int[] actualDistancesTo3 = dijkstra.FindClosestDistances(graph, 3);

            // Assert
            Assert.Equal(expectedDistancesTo0, actualDistancesTo0);
            Assert.Equal(expectedDistancesTo1, actualDistancesTo1);
            Assert.Equal(expectedDistancesTo2, actualDistancesTo2);
            Assert.Equal(expectedDistancesTo3, actualDistancesTo3);
        }

        //     2
        //    / \
        // 0-1- -3 4
        [Fact]
        public void CalculateShortestDistanceFromVertex_ComplexGraphWithDifferentWeightsAndUnreachableVertices_ReturnsShortestPaths()
        {
            // Arrange
            Dijkstra dijkstra = new Dijkstra();
            UndirectedGraph graph = new UndirectedGraph(5);

            graph.AddEdge(0, 1, 2);
            graph.AddEdge(1, 2, 3);
            graph.AddEdge(1, 3, 5);
            graph.AddEdge(2, 3, 1);

            var expectedDistancesTo0 = new int[] { 0, 2, 5, 6, 10000 };
            var expectedDistancesTo1 = new int[] { 2, 0, 3, 4, 10000 };
            var expectedDistancesTo2 = new int[] { 5, 3, 0, 1, 10000 };
            var expectedDistancesTo3 = new int[] { 6, 4, 1, 0, 10000 };
            var expectedDistancesTo4 = new int[] { 10000, 10000, 10000, 10000, 0 };

            // Act
            int[] actualDistancesTo0 = dijkstra.FindClosestDistances(graph, 0);
            int[] actualDistancesTo1 = dijkstra.FindClosestDistances(graph, 1);
            int[] actualDistancesTo2 = dijkstra.FindClosestDistances(graph, 2);
            int[] actualDistancesTo3 = dijkstra.FindClosestDistances(graph, 3);
            int[] actualDistancesTo4 = dijkstra.FindClosestDistances(graph, 4);

            // Assert
            Assert.Equal(expectedDistancesTo0, actualDistancesTo0);
            Assert.Equal(expectedDistancesTo1, actualDistancesTo1);
            Assert.Equal(expectedDistancesTo2, actualDistancesTo2);
            Assert.Equal(expectedDistancesTo3, actualDistancesTo3);
            Assert.Equal(expectedDistancesTo4, actualDistancesTo4);
        }

        [Fact]
        public void CalculateShortestDistanceFromVertex_CourseraAssignment_ReturnsShortestPath()
        {
            HelplerMethods helplerMethods = new HelplerMethods();
            Dijkstra dijkstra = new Dijkstra();

            string path = Directory.GetCurrentDirectory() + @"\GraphAlgorithms\DijkstrasAlgorithm\InputFiles\CourseraData.txt";

            UndirectedGraph graph = helplerMethods.ReadFile(path);

            var distances = dijkstra.FindClosestDistances(graph, 0);

            string outputPath = "output.txt";

            List<int> result = new List<int>();

            result.Add(distances[6]);
            result.Add(distances[36]);
            result.Add(distances[58]);
            result.Add(distances[81]);
            result.Add(distances[98]);
            result.Add(distances[114]);
            result.Add(distances[132]);
            result.Add(distances[164]);
            result.Add(distances[187]);
            result.Add(distances[196]);

            File.WriteAllText(outputPath, string.Join(',', result));

            Console.WriteLine("asdsa");
        }
    }
}
