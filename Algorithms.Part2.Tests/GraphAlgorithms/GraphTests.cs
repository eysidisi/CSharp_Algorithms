using Algorithms.Part2.GraphAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Part2.Tests.GraphAlgorithms
{
    public class GraphTests
    {
        [Fact]
        public void AddVertex_AddsOneVertex()
        {
            // Arrange
            Graph graph = new Graph();
            int expectedVertexIndex = 0;

            // Act
            graph.AddVertex();

            // Assert
            Assert.Equal(expectedVertexIndex, graph.VerticesId[0]);
        }

        [Fact]
        public void AddVertex_AddsTwoVertices()
        {
            // Arrange
            Graph graph = new Graph();
            int expectedSecondVertexIndex = 1;

            // Act
            graph.AddVertex();
            graph.AddVertex();

            // Assert
            Assert.Equal(expectedSecondVertexIndex, graph.VerticesId[1]);
        }


        // 0-1
        [Fact]
        public void AddEdge_AddsOneEdge()
        {
            // Arrange
            Graph graph = new Graph();

            // Act
            graph.AddVertex();
            graph.AddVertex();
            graph.AddEdge(0, 1);
            var connectedVerticesToVertex0 = graph.GetConnectedVertices(0);
            var neighbourVertexIndex = 1;
            var notNeighbourVertexIndex = 2;

            // Assert
            Assert.Contains(neighbourVertexIndex, connectedVerticesToVertex0);
            Assert.DoesNotContain(notNeighbourVertexIndex, connectedVerticesToVertex0);
        }

    }
}
