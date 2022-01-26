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
            Assert.Contains(V0, graph.Edges[0].Vertices);
            Assert.Contains(V1, graph.Edges[0].Vertices);
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
            #region Add Edges
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
            #endregion

            // Assert
            Assert.Equal(3, V0.Edges.Count);
            Assert.Equal(4, V1.Edges.Count);
            Assert.Equal(3, V2.Edges.Count);
            Assert.Equal(3, V3.Edges.Count);
            Assert.Equal(3, V4.Edges.Count);

            Assert.Contains(V0, graph.Edges[0].Vertices);
            Assert.Contains(V1, graph.Edges[0].Vertices);

            Assert.Contains(V0, graph.Edges[1].Vertices);
            Assert.Contains(V2, graph.Edges[1].Vertices);

            Assert.Contains(V0, graph.Edges[2].Vertices);
            Assert.Contains(V3, graph.Edges[2].Vertices);

            Assert.Contains(V1, graph.Edges[3].Vertices);
            Assert.Contains(V2, graph.Edges[3].Vertices);

            Assert.Contains(V1, graph.Edges[4].Vertices);
            Assert.Contains(V3, graph.Edges[4].Vertices);

            Assert.Contains(V1, graph.Edges[5].Vertices);
            Assert.Contains(V4, graph.Edges[5].Vertices);

            Assert.Contains(V2, graph.Edges[6].Vertices);
            Assert.Contains(V4, graph.Edges[6].Vertices);

            Assert.Contains(V3, graph.Edges[7].Vertices);
            Assert.Contains(V4, graph.Edges[7].Vertices);
        }
    }
}
