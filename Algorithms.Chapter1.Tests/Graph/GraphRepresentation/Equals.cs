using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Part1.Tests.Graph.GraphRepresentation
{
    public class Equals
    {
        [Fact]
        public void SameGraphs()
        {
            // Arrange
            var graph1 = new Part1.Graph.GraphRepresentation(3);
            var graph2 = new Part1.Graph.GraphRepresentation(3);

            graph1.AddEdge(0, 1);
            graph1.AddEdge(0, 2);
            graph1.AddEdge(1, 2);

            graph2.AddEdge(0, 1);
            graph2.AddEdge(0, 2);
            graph2.AddEdge(1, 2);

            // Act


            // Assert
            Assert.Equal(graph1, graph2);
        }

        [Fact]
        public void SameSize_DifferentGraphs()
        {
            // Arrange
            var graph1 = new Part1.Graph.GraphRepresentation(3);
            var graph2 = new Part1.Graph.GraphRepresentation(3);
            
            graph1.AddEdge(0, 1);
            graph1.AddEdge(0, 2);
            graph2.AddEdge(0, 1);
            graph2.AddEdge(1, 2);

            // Act


            // Assert
            Assert.NotEqual(graph1, graph2);
        }

        [Fact]
        public void DifferentSize_DifferentGraphs()
        {
            // Arrange
            var graph1 = new Part1.Graph.GraphRepresentation(2);
            var graph2 = new Part1.Graph.GraphRepresentation(3);
            graph1.AddEdge(0, 1);
            graph2.AddEdge(0, 1);
            graph2.AddEdge(0, 2);

            // Act


            // Assert
            Assert.NotEqual(graph1, graph2);
        }
    }
}
