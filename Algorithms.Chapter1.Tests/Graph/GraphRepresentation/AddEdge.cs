using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Part1.Tests.Graph.GraphRepresentation
{
    public class AddEdge
    {

        // V0-V1
        [Fact]
        public void AddOneEdge()
        {
            // Arrange
            const int NumberOfVertices = 2;
            var graph = new Part1.Graph.GraphRepresentation(NumberOfVertices);

            // Act
            graph.AddEdge(0, 1);
            var V0 = graph.Vertices[0];
            var V1 = graph.Vertices[1];

            // Assert
            Assert.Equal(V0, graph.Edges[0].firstVertex);
            Assert.Equal(V1, graph.Edges[0].secondVertex);
        }

        //    V2
        //   / | \
        // V0-V1-V4
        //   \ | /
        //    V3
        [Fact]
        public void AddEightEdges()
        {
            // Arrange
            const int NumberOfVertices = 5;
            var graph = new Part1.Graph.GraphRepresentation(NumberOfVertices);

            // Act
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);

            graph.AddEdge(0, 3);
            graph.AddEdge(1, 2);

            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);

            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);

            var V0 = graph.Vertices[0];
            var V1 = graph.Vertices[1];
            var V2 = graph.Vertices[2];
            var V3 = graph.Vertices[3];
            var V4 = graph.Vertices[4];

            // Assert
            Assert.Equal(3, V0.edges.Count);
            Assert.Equal(4, V1.edges.Count);
            Assert.Equal(3, V2.edges.Count);
            Assert.Equal(3, V3.edges.Count);
            Assert.Equal(3, V4.edges.Count);

            Assert.Equal(V0, graph.Edges[0].firstVertex);
            Assert.Equal(V1, graph.Edges[0].secondVertex);

            Assert.Equal(V0, graph.Edges[1].firstVertex);
            Assert.Equal(V2, graph.Edges[1].secondVertex);

            Assert.Equal(V0, graph.Edges[2].firstVertex);
            Assert.Equal(V3, graph.Edges[2].secondVertex);

            Assert.Equal(V1, graph.Edges[3].firstVertex);
            Assert.Equal(V2, graph.Edges[3].secondVertex);

            Assert.Equal(V1, graph.Edges[4].firstVertex);
            Assert.Equal(V3, graph.Edges[4].secondVertex);

            Assert.Equal(V1, graph.Edges[5].firstVertex);
            Assert.Equal(V4, graph.Edges[5].secondVertex);

            Assert.Equal(V2, graph.Edges[6].firstVertex);
            Assert.Equal(V4, graph.Edges[6].secondVertex);

            Assert.Equal(V3, graph.Edges[7].firstVertex);
            Assert.Equal(V4, graph.Edges[7].secondVertex);
        }
    }
}
