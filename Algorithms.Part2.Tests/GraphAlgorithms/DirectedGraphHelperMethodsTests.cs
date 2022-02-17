﻿using Algorithms.Part2.GraphAlgorithms;
using System;
using System.Collections.Generic;
using System.IO;
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

            var vertexIDsToConnectedIDs = Create7Edges();

            var expectedReversedVertexIDsToConnectedIDs = new Dictionary<int, List<int>>();
            expectedReversedVertexIDsToConnectedIDs.Add(5, new List<int>() { 2 });
            expectedReversedVertexIDsToConnectedIDs.Add(4, new List<int>() { 2, 3 });
            expectedReversedVertexIDsToConnectedIDs.Add(3, new List<int>() { 0, 2 });
            expectedReversedVertexIDsToConnectedIDs.Add(2, new List<int>() { 1 });
            expectedReversedVertexIDsToConnectedIDs.Add(1, new List<int>() { 0 });

            // Act
            var actualReversedVertexIDsToConnectedIDs = helperMethods.ReverseVertexToConnectedVertexIDs(vertexIDsToConnectedIDs);

            // Assert
            Assert.Equal(expectedReversedVertexIDsToConnectedIDs, actualReversedVertexIDsToConnectedIDs);
        }

        [Fact]
        public void ReadInputFile_Read7EdgeGraph()
        {
            // Arrange
            DirectedGraphHelperMethods helperMethods = new DirectedGraphHelperMethods();

            DirectedGraph expectedGraph = Create7EdgesGraph();

            string inputfilePath = Directory.GetCurrentDirectory() + @"\GraphAlgorithms\InputFiles\7EdgesGraph.txt";

            // Act
            var actualGraph = helperMethods.ReadInputFile(inputfilePath);

            // Assert
            for (int i = 0; i < actualGraph.VertexIds.Count; i++)
            {
                int vertexID = actualGraph.VertexIds[i];
                expectedGraph.GetConnectedVertices(vertexID).Sort();
                actualGraph.GetConnectedVertices(vertexID).Sort();

                Assert.Equal(expectedGraph.GetConnectedVertices(vertexID), actualGraph.GetConnectedVertices(vertexID));
            }

        }

        [Fact]
        public void ReadInputFile_CourseraAssignment()
        {
            // Arrange
            DirectedGraphHelperMethods helperMethods = new DirectedGraphHelperMethods();


            string inputfilePath = Directory.GetCurrentDirectory() + @"\GraphAlgorithms\InputFiles\CourseraAssignmentInput.txt";

            // Act
            var actualGraph = helperMethods.ReadInputFile(inputfilePath);

            // Assert
            
        }

        // 0->1-> 2 ->5
        //  \    | \
        //   \   ↓  ↓
        //    -> 3->4
        private Dictionary<int, List<int>> Create7Edges()
        {

            var vertexIDsToConnectedIDs = new Dictionary<int, List<int>>();

            vertexIDsToConnectedIDs.Add(0, new List<int>() { 1, 3 });
            vertexIDsToConnectedIDs.Add(1, new List<int>() { 2 });
            vertexIDsToConnectedIDs.Add(2, new List<int>() { 3, 4, 5 });
            vertexIDsToConnectedIDs.Add(3, new List<int>() { 4 });

            return vertexIDsToConnectedIDs;
        }

        // 0->1-> 2 ->5
        //  \    | \
        //   \   ↓  ↓
        //    -> 3->4
        private DirectedGraph Create7EdgesGraph()
        {
            DirectedGraph graph = new DirectedGraph();

            int numOfVertices = 6;

            for (int i = 0; i < numOfVertices; i++)
            {
                graph.AddVertex();
            }

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 3);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(2, 5);
            graph.AddEdge(3, 4);

            return graph;
        }


    }
}
