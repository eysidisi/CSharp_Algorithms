using Algorithms.Part2.GraphAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Part2.Tests.GraphAlgorithms
{
    public class DirectedGraphHelperMethodsTests
    {
        //0->1->2
        [Fact]
        public void ReverseVertexToConnectedVertexIDs_GraphWithThreeVertices_ReturnsReversedGraph()
        {
            // Arrange
            DirectedGraphHelperMethods helperMethods = new DirectedGraphHelperMethods();

            var vertexIDsToConnectedIDs = new Dictionary<int, List<int>>();
            vertexIDsToConnectedIDs.Add(0, new List<int>() { 1 });
            vertexIDsToConnectedIDs.Add(1, new List<int>() { 2 });

            var expectedReversedVertexIDsToConnectedIDs = new Dictionary<int, List<int>>();
            expectedReversedVertexIDsToConnectedIDs.Add(2, new List<int>() { 1 });
            expectedReversedVertexIDsToConnectedIDs.Add(1, new List<int>() { 0 });

            // Act
            var actualReversedVertexIDsToConnectedIDs = helperMethods.ReverseVertexToConnectedVertexIDs(vertexIDsToConnectedIDs);

            // Assert
            Assert.Equal(expectedReversedVertexIDsToConnectedIDs, actualReversedVertexIDsToConnectedIDs);
        }

        //0->1->2
        //    <-
        [Fact]
        public void ReverseVertexToConnectedVertexIDs_GraphWithThreeVerticesTwoWayConnected_ReturnsReversedGraph()
        {
            // Arrange
            DirectedGraphHelperMethods helperMethods = new DirectedGraphHelperMethods();

            var vertexIDsToConnectedIDs = new Dictionary<int, List<int>>();
            vertexIDsToConnectedIDs.Add(0, new List<int>() { 1 });
            vertexIDsToConnectedIDs.Add(1, new List<int>() { 2 });
            vertexIDsToConnectedIDs.Add(2, new List<int>() { 1 });

            var expectedReversedVertexIDsToConnectedIDs = new Dictionary<int, List<int>>();
            expectedReversedVertexIDsToConnectedIDs.Add(2, new List<int>() { 1 });
            expectedReversedVertexIDsToConnectedIDs.Add(1, new List<int>() { 0, 2 });

            // Act
            var actualReversedVertexIDsToConnectedIDs = helperMethods.ReverseVertexToConnectedVertexIDs(vertexIDsToConnectedIDs);

            // Assert
            Assert.Equal(expectedReversedVertexIDsToConnectedIDs, actualReversedVertexIDsToConnectedIDs);
        }

        // 0->1-> 2 ->5
        //  \    | \
        //   \   ↓  ↓
        //    -> 3->4
        [Fact]
        public void ReverseVertexToConnectedVertexIDs_GraphWithEightVertices_ReturnsReversedGraph()
        {
            // Arrange
            DirectedGraphHelperMethods helperMethods = new DirectedGraphHelperMethods();

            var vertexIDsToConnectedIDs = Create8Edges();

            var expectedReversedVertexIDsToConnectedIDs = new Dictionary<int, List<int>>();
            expectedReversedVertexIDsToConnectedIDs.Add(5, new List<int>() { 2 });
            expectedReversedVertexIDsToConnectedIDs.Add(4, new List<int>() { 3, 2 });
            expectedReversedVertexIDsToConnectedIDs.Add(3, new List<int>() { 0, 2 });
            expectedReversedVertexIDsToConnectedIDs.Add(2, new List<int>() { 1 });
            expectedReversedVertexIDsToConnectedIDs.Add(1, new List<int>() { 0 });

            // Act
            var actualReversedVertexIDsToConnectedIDs = helperMethods.ReverseVertexToConnectedVertexIDs(vertexIDsToConnectedIDs);

            // Assert
            Assert.Equal(expectedReversedVertexIDsToConnectedIDs.Count, actualReversedVertexIDsToConnectedIDs.Count);
            throw new NotImplementedException();
        }

        // 0->1-> 2 ->5
        //  \    | \
        //   \   ↓  ↓
        //    -> 3->4
        private Dictionary<int, List<int>> Create8Edges()
        {

            var vertexIDsToConnectedIDs = new Dictionary<int, List<int>>();

            vertexIDsToConnectedIDs.Add(0, new List<int>() { 1, 3 });
            vertexIDsToConnectedIDs.Add(1, new List<int>() { 2 });
            vertexIDsToConnectedIDs.Add(2, new List<int>() { 3, 4, 5 });
            vertexIDsToConnectedIDs.Add(3, new List<int>() { 4 });

            return vertexIDsToConnectedIDs;
        }

    }
}
