using Algorithms.Part2.GraphAlgorithms.TarjansAlgorithm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Part2.Tests.GraphAlgorithms.TarjansAlgorithm
{
    public class HelperMethodsTests
    {
        [Fact]
        public void ReadInputFile_Read7EdgeGraph()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();

            DirectedGraph expectedGraph = new DirectedGraph(6);
            expectedGraph.ConnectVertex1ToVertex2(0, 1);
            expectedGraph.ConnectVertex1ToVertex2(0, 3);
            expectedGraph.ConnectVertex1ToVertex2(1, 2);
            expectedGraph.ConnectVertex1ToVertex2(2, 3);
            expectedGraph.ConnectVertex1ToVertex2(2, 4);
            expectedGraph.ConnectVertex1ToVertex2(2, 5);
            expectedGraph.ConnectVertex1ToVertex2(3, 4);

            string inputfilePath = Directory.GetCurrentDirectory() + @"\GraphAlgorithms\InputFiles\7EdgesGraph.txt";

            // Act
            var actualGraph = helperMethods.ReadInputFile(inputfilePath);

            // Assert
            for (int i = 0; i < actualGraph.vertexToVertexIDs.Count; i++)
            {
                var actualGraphVertexToVertices = actualGraph.vertexToVertexIDs[i];
                var expectedGraphVertexToVertices = expectedGraph.vertexToVertexIDs[i];
                Assert.Equal(expectedGraphVertexToVertices, actualGraphVertexToVertices);
            }

        }

        [Fact(Skip ="Used for coursera assignment")]
        public void ReadInputFile_CourseraAssignment()
        {
            // Arrange
            HelperMethods helperMethods = new HelperMethods();


            string inputfilePath = Directory.GetCurrentDirectory() + @"\GraphAlgorithms\InputFiles\CourseraData.txt";

            // Act
            var actualGraph = helperMethods.ReadInputFile(inputfilePath);

            // Assert

        }

        //0->1->2
        [Fact]
        public void ReverseEdges_ReversesEdges()
        {
            // Arrange
            DirectedGraph graph = new DirectedGraph(3);
            graph.ConnectVertex1ToVertex2(0, 1);
            graph.ConnectVertex1ToVertex2(1, 2);

            HelperMethods helperMethods = new HelperMethods();

            DirectedGraph expedtedReversedGraph = new DirectedGraph(3);
            expedtedReversedGraph.ConnectVertex1ToVertex2(2, 1);
            expedtedReversedGraph.ConnectVertex1ToVertex2(1, 0);

            // Act
            var actualReversedGraph = helperMethods.ReverseEdges(graph.vertexToVertexIDs);

            // Assert
            for (int vertexIndex = 0; vertexIndex < expedtedReversedGraph.vertexToVertexIDs.Count; vertexIndex++)
            {
                var expectedConnedtedVertices = expedtedReversedGraph.vertexToVertexIDs[vertexIndex];
                var actulConnedtedVertices = actualReversedGraph[vertexIndex];
                Assert.Equal(expectedConnedtedVertices, actulConnedtedVertices);
            }
        }

        
    }
}
