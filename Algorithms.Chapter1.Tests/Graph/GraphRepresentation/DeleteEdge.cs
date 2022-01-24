using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Part1.Tests.Graph.GraphRepresentation
{
    public class DeleteEdge
    {
        // V0-V1
        [Fact]
        public void DeleteEdge_TwoVerticesGraph()
        {
            // Arrange
            const int NumberOfVertices = 2;
            var graph = new Part1.Graph.GraphRepresentation(NumberOfVertices);

            graph.AddEdge(0, 1);

            var V0 = graph.Vertices[0];
            var V1 = graph.Vertices[1];

            // Act
            graph.DeleteEdge(0);

            // Assert
            Assert.Equal(0, graph.Edges.Count);
            Assert.Empty(V0.edges);
            Assert.Empty(V1.edges);
        }

        //    V2
        //   / | \
        // V0-V1-V4
        //   \ | /
        //    V3
        [Fact]
        public void DeleteEdgeZeroToOne_EightVerticesGraph()
        {
            #region Arrange
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
            #endregion

            // Act
            graph.DeleteEdge(0);

            // Assert
            Assert.Equal(7, graph.Edges.Count);
            Assert.Equal(V1, V2.edges[0].firstVertex);
            Assert.Equal(V1, V2.edges[1].firstVertex);

            Assert.Equal(V1, V3.edges[0].firstVertex);
            Assert.Equal(V1, V3.edges[1].firstVertex);
        }

        //    V2
        //   / | \
        // V0-V1-V4
        //   \ | /
        //    V3
        [Fact]
        public void DeleteEdgeOneToFour_EightVerticesGraph()
        {
            #region Arrange
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
            #endregion

            // Act
            graph.DeleteEdge(5);

            // Assert
            Assert.Equal(7, graph.Edges.Count);
            Assert.Equal(V4, V0.edges[0].secondVertex);
            Assert.Equal(V4, V2.edges[1].firstVertex);
            Assert.Equal(V4, V3.edges[1].firstVertex);

            Assert.Equal(3, V0.edges.Count);
            Assert.Equal(3, V2.edges.Count);
            Assert.Equal(3, V3.edges.Count);
            Assert.Equal(5, V4.edges.Count);

            Assert.NotEmpty(V4.edges.Where(e => e.firstVertex == V0));
            Assert.NotEmpty(V4.edges.Where(e => e.secondVertex == V3));
            Assert.NotEmpty(V4.edges.Where(e => e.secondVertex == V2));
        }

        //    V2
        //   / | \
        // V0-V1-V4
        //   \ | /
        //    V3
        [Fact]
        public void DeleteEdgeOneToFourZeroToTwo_EightVerticesGraph()
        {
            #region Arrange
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
            #endregion

            // Act
            graph.DeleteEdge(5);

            // Assert
            Assert.Equal(7, graph.Edges.Count);
            Assert.Equal(V4, V0.edges[0].secondVertex);
            Assert.Equal(V4, V2.edges[1].firstVertex);
            Assert.Equal(V4, V3.edges[1].firstVertex);

            Assert.Equal(3, V0.edges.Count);
            Assert.Equal(3, V2.edges.Count);
            Assert.Equal(3, V3.edges.Count);
            Assert.Equal(5, V4.edges.Count);

            Assert.NotEmpty(V4.edges.Where(e => e.firstVertex == V0));
            Assert.NotEmpty(V4.edges.Where(e => e.secondVertex == V3));
            Assert.NotEmpty(V4.edges.Where(e => e.secondVertex == V2));
        }
    }
}
