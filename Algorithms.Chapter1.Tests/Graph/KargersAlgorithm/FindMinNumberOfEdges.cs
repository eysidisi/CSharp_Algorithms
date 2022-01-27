using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Part1.Graph;
using Algorithms.Part1.FileIO;
using System.IO;
using System.Diagnostics;

namespace Algorithms.Part1.Tests.GraphRepresentation.KargersAlgorithm
{
    public class FindMinNumberOfEdges
    {
        // V1-V2
        [Fact]
        public void OneEdgeGraph()
        {
            // Arrange
            var graph = new Part1.Graph.GraphRepresentation(2);
            var kargers = new Part1.Graph.KargersAlgorithm();
            graph.AddEdge(0, 1);
            int expectedMinNumberOfEdges = 1;

            // Act
            var actualMinNumberOfEdges = kargers.FindMinNumberOfEdges(graph, 1);

            // Assert
            Assert.Equal(expectedMinNumberOfEdges, actualMinNumberOfEdges);
        }

        //    V2
        //   / | \
        // V0-V1-V4
        //   \ | /
        //    V3
        [Fact]
        public void EightEdgeGraph()
        {
            // Arrange
            const int NumberOfVertices = 5;
            var graph = new Part1.Graph.GraphRepresentation(NumberOfVertices);
            var kargers = new Part1.Graph.KargersAlgorithm();
            int expectedNumOfMinEdges = 3;
            const int NumOfRuningTimes = 30;

            // Act
            #region Add Edges
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);

            graph.AddEdge(0, 3);
            graph.AddEdge(1, 2);

            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);

            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);
            #endregion
            var actualNumOfMinEdges = kargers.FindMinNumberOfEdges(graph, NumOfRuningTimes);

            // Assert
            Assert.Equal(expectedNumOfMinEdges, actualNumOfMinEdges);
        }

        [Fact(Skip = "Takes more than 20 minutes to run. Used just for Coursera Assignment")]
        public void CourseraAssignmentGraph()
        {
            // Arrange
            var fileManager = new FileManager();
            string graphPath = Directory.GetCurrentDirectory() + @"\Graph\TestFiles\AssignmentMatrix.txt";
            var graph = fileManager.ReadGraph(graphPath);
            var kargers = new Part1.Graph.KargersAlgorithm();
            var expectedNumOfMinEdges = 17;

            // Act
            var actualNumOfMinEdges = kargers.FindMinNumberOfEdges(graph);

            // Assert
            Assert.Equal(expectedNumOfMinEdges, actualNumOfMinEdges);
        }


    }
}
