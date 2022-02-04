﻿using Algorithms.Part2.GraphAlgorithms;
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

        // 0-1-2-5
        //  \  |\
        //   \-3-4
        [Fact]
        public void AddEdge_AddsEightEdges()
        {
            // Arrange
            var graph = Create8EdgesGraph();

            List<int> expectedConnectedVerticesToVertex0 = new List<int>() { 1, 3 };
            List<int> expectedConnectedVerticesToVertex1 = new List<int>() { 0, 2 };
            List<int> expectedConnectedVerticesToVertex2 = new List<int>() { 1, 3, 4, 5 };
            List<int> expectedConnectedVerticesToVertex3 = new List<int>() { 0, 2, 4 };
            List<int> expectedConnectedVerticesToVertex4 = new List<int>() { 2, 3 };
            List<int> expectedConnectedVerticesToVertex5 = new List<int>() { 2 };

            List<List<int>> expectedValues = new List<List<int>>()
            {
                expectedConnectedVerticesToVertex0,
                expectedConnectedVerticesToVertex1,
                expectedConnectedVerticesToVertex2,
                expectedConnectedVerticesToVertex3,
                expectedConnectedVerticesToVertex4,
                expectedConnectedVerticesToVertex5,
            };

            // Act

            List<int> actualConnectedVerticesToVertex0 = graph.GetConnectedVertices(0);
            List<int> actualConnectedVerticesToVertex1 = graph.GetConnectedVertices(1);
            List<int> actualConnectedVerticesToVertex2 = graph.GetConnectedVertices(2);
            List<int> actualConnectedVerticesToVertex3 = graph.GetConnectedVertices(3);
            List<int> actualConnectedVerticesToVertex4 = graph.GetConnectedVertices(4);
            List<int> actualConnectedVerticesToVertex5 = graph.GetConnectedVertices(5);

            List<List<int>> actualValues = new List<List<int>>()
            {
                actualConnectedVerticesToVertex0,
                actualConnectedVerticesToVertex1,
                actualConnectedVerticesToVertex2,
                actualConnectedVerticesToVertex3,
                actualConnectedVerticesToVertex4,
                actualConnectedVerticesToVertex5
            };

            // Assert
            for (int index = 0; index < actualValues.Count; index++)
            {
                Assert.Equal(expectedValues[index], actualValues[index]);
            }

        }

        // 0-1
        [Fact]
        public void BreadthFirstTravel_OneEdgeGraph()
        {
            // Arrange
            Graph graph = new Graph();
            graph.AddVertex();
            graph.AddVertex();
            graph.AddEdge(0, 1);

            List<int> expectedVisitedIndicesStartingFrom0 = new List<int> { 0, 1 };
            List<int> expectedVisitedIndicesStartingFrom1 = new List<int> { 1, 0 };

            // Act
            List<int> actualVisitedIndicesStartingFrom0 = graph.BreadthFirstTravel(0);
            List<int> actualVisitedIndicesStartingFrom1 = graph.BreadthFirstTravel(1);

            // Assert
            Assert.Equal(expectedVisitedIndicesStartingFrom0, actualVisitedIndicesStartingFrom0);
            Assert.Equal(expectedVisitedIndicesStartingFrom1, actualVisitedIndicesStartingFrom1);
        }

        // 0-1-2-5
        //  \  |\
        //   \-3-4
        [Fact]
        public void BreadthFirstTravel_EightEdgesGraph()
        {
            // Arrange
            Graph graph = Create8EdgesGraph();

            List<int> expectedVisitedIndicesStartingFrom0 = new List<int> { 0, 1, 3, 2, 4, 5 };
            List<int> expectedVisitedIndicesStartingFrom1 = new List<int> { 1, 0, 2, 3, 4, 5 };
            List<int> expectedVisitedIndicesStartingFrom4 = new List<int> { 4, 2, 3, 1, 5, 0 };

            // Act
            List<int> actualVisitedIndicesStartingFrom0 = graph.BreadthFirstTravel(0);
            List<int> actualVisitedIndicesStartingFrom1 = graph.BreadthFirstTravel(1);
            List<int> actualVisitedIndicesStartingFrom4 = graph.BreadthFirstTravel(4);

            // Assert
            Assert.Equal(expectedVisitedIndicesStartingFrom0, actualVisitedIndicesStartingFrom0);
            Assert.Equal(expectedVisitedIndicesStartingFrom1, actualVisitedIndicesStartingFrom1);
            Assert.Equal(expectedVisitedIndicesStartingFrom4, actualVisitedIndicesStartingFrom4);
        }

        // 0-1
        [Fact]
        public void CalculateMinDistance_OneEdgeGraph()
        {
            // Arrange
            Graph graph = new Graph();
            graph.AddVertex();
            graph.AddVertex();
            graph.AddEdge(0, 1);

            Dictionary<int, int> expectedVertexIndexToDistanceIndex0 = new Dictionary<int, int>();
            expectedVertexIndexToDistanceIndex0.Add(0, 0);
            expectedVertexIndexToDistanceIndex0.Add(1, 1);

            // Act
            Dictionary<int, int> actualVertexIndexToDistance = graph.FindMinDistancesToVertex(0);

            // Assert
            Assert.Equal(expectedVertexIndexToDistanceIndex0, actualVertexIndexToDistance);
        }

        // 0-1-2-5
        //  \  |\
        //   \-3-4
        [Fact]
        public void CalculateMinDistance_EightEdgesGraph()
        {
            // Arrange
            Graph graph = Create8EdgesGraph();

            var expectedVertexIndexToDistanceIndex0 = new Dictionary<int, int>();
            expectedVertexIndexToDistanceIndex0.Add(0, 0);
            expectedVertexIndexToDistanceIndex0.Add(1, 1);
            expectedVertexIndexToDistanceIndex0.Add(2, 2);
            expectedVertexIndexToDistanceIndex0.Add(3, 1);
            expectedVertexIndexToDistanceIndex0.Add(4, 2);
            expectedVertexIndexToDistanceIndex0.Add(5, 3);

            // Act
            var actualVertexIndexToDistanceIndex0 = graph.FindMinDistancesToVertex(0);


            // Assert
            foreach (var vertexIndex in expectedVertexIndexToDistanceIndex0.Keys)
            {
                Assert.Equal(expectedVertexIndexToDistanceIndex0[vertexIndex], actualVertexIndexToDistanceIndex0[vertexIndex]);
            }
        }

        // 0-1-2-5
        //  \  |\
        //   \-3-4
        private Graph Create8EdgesGraph()
        {
            Graph graph = new Graph();

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
