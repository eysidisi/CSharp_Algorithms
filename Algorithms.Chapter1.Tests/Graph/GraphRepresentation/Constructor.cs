using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Part1.Tests.Graph.GraphRepresentation
{
    public class Constructor
    {
        // V0-V1
        [Fact]
        public void OneEdgeGraph()
        {
            // Arrange
            var graph = new Part1.Graph.GraphRepresentation(2);
            graph.AddEdge(0, 1);

            // Act
            var newGraph = new Part1.Graph.GraphRepresentation(graph);
            var edge = newGraph.Edges[0];
            var vertex1 = newGraph.Vertices[0];
            var vertex2 = newGraph.Vertices[1];

            // Assert
            Assert.Equal(1, newGraph.Edges.Count);
            Assert.Contains(vertex1, edge.Vertices);
            Assert.Contains(vertex2, edge.Vertices);
        }
    }
}
