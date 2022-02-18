using Algorithms.Part2.GraphAlgorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Part2.Tests.GraphAlgorithms
{
    public class SCCDirectedGraphHelperMethodsTests
    {
        [Fact]
        public void ReadInputFile_Read7EdgeGraph()
        {
            // Arrange
            SCCDirectedGraphHelperMethods helperMethods = new SCCDirectedGraphHelperMethods();

            SCCDirectedGraph expectedGraph = new SCCDirectedGraph(6);
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
            for (int i = 0; i < actualGraph.indexIDsToIndexIDs.Count; i++)
            {
                var actualGraphVertexToVertices = actualGraph.indexIDsToIndexIDs[i];
                var expectedGraphVertexToVertices = expectedGraph.indexIDsToIndexIDs[i];
                Assert.Equal(expectedGraphVertexToVertices, actualGraphVertexToVertices);
            }

        }

        [Fact]
        public void ReadInputFile_CourseraAssignment()
        {
            // Arrange
            SCCDirectedGraphHelperMethods helperMethods = new SCCDirectedGraphHelperMethods();


            string inputfilePath = Directory.GetCurrentDirectory() + @"\GraphAlgorithms\InputFiles\CourseraAssignmentInput.txt";

            // Act
            var actualGraph = helperMethods.ReadInputFile(inputfilePath);

            // Assert

        }

        //0->1->2
        [Fact]
        public void ReverseEdges_ReversesEdges()
        {
            // Arrange
            SCCDirectedGraph graph = new SCCDirectedGraph(3);
            graph.ConnectVertex1ToVertex2(0, 1);
            graph.ConnectVertex1ToVertex2(1, 2);

            SCCDirectedGraphHelperMethods helperMethods = new SCCDirectedGraphHelperMethods();

            SCCDirectedGraph expedtedReversedGraph = new SCCDirectedGraph(3);
            expedtedReversedGraph.ConnectVertex1ToVertex2(2, 1);
            expedtedReversedGraph.ConnectVertex1ToVertex2(1, 0);

            // Act
            var actualReversedGraph = helperMethods.ReverseEdges(graph.indexIDsToIndexIDs);

            // Assert
            for (int vertexIndex = 0; vertexIndex < expedtedReversedGraph.indexIDsToIndexIDs.Count; vertexIndex++)
            {
                var expectedConnedtedVertices = expedtedReversedGraph.indexIDsToIndexIDs[vertexIndex];
                var actulConnedtedVertices = actualReversedGraph[vertexIndex];
                Assert.Equal(expectedConnedtedVertices, actulConnedtedVertices);
            }
        }

        
    }
}
