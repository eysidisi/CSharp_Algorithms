using Algorithms.Part2.GraphAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Part2.Tests.GraphAlgorithms
{
    public class DirectedGraphTests
    {
        [Fact]
        public void AddVertex_AddsOneVertex()
        {
            // Arrange
            DirectedGraph graph = new DirectedGraph();
            int expectedVertexIndex = 0;

            // Act
            graph.AddVertex();

            // Assert
            Assert.Equal(expectedVertexIndex, graph.VertexIds[0]);
        }

        [Fact]
        public void AddVertex_AddsTwoVertices()
        {
            // Arrange
            DirectedGraph graph = new DirectedGraph();
            int expectedSecondVertexIndex = 1;

            // Act
            graph.AddVertex();
            graph.AddVertex();

            // Assert
            Assert.Equal(expectedSecondVertexIndex, graph.VertexIds[1]);
        }

        // 0-1
        [Fact]
        public void AddEdge_AddsOneEdge()
        {
            // Arrange
            DirectedGraph graph = new DirectedGraph();

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

        // 0->1-> 2 ->5
        //  \    | \
        //   \   ↓  ↓
        //    -> 3->4
        [Fact]
        public void AddEdge_AddsEightEdges()
        {
            // Arrange
            var graph = Create8EdgesGraph();

            List<int> expectedConnectedVerticesToVertex0 = new List<int>() { 1, 3 };
            List<int> expectedConnectedVerticesToVertex1 = new List<int>() { 2 };
            List<int> expectedConnectedVerticesToVertex2 = new List<int>() { 3, 4, 5 };
            List<int> expectedConnectedVerticesToVertex3 = new List<int>() { 4 };
            List<int> expectedConnectedVerticesToVertex4 = new List<int>() { };
            List<int> expectedConnectedVerticesToVertex5 = new List<int>() { };

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
            UndirectedGraph graph = new UndirectedGraph();
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

        // 0->1-> 2 ->5
        //  \    | \
        //   \   ↓  ↓
        //    -> 3->4
        [Fact]
        public void BreadthFirstTravel_EightEdgesGraph()
        {
            // Arrange
            DirectedGraph graph = Create8EdgesGraph();

            List<int> expectedVisitedIndicesStartingFrom0 = new List<int> { 0, 1, 3, 2, 4, 5 };
            List<int> expectedVisitedIndicesStartingFrom1 = new List<int> { 1, 2, 3, 4, 5 };
            List<int> expectedVisitedIndicesStartingFrom4 = new List<int> { 4 };

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
        public void DepthFirstTravel_OneEdgeGraph()
        {
            // Arrange
            UndirectedGraph graph = new UndirectedGraph();
            graph.AddVertex();
            graph.AddVertex();
            graph.AddEdge(0, 1);

            List<int> expectedVisitedIndicesStartingFrom0 = new List<int> { 0, 1 };
            List<int> expectedVisitedIndicesStartingFrom1 = new List<int> { 1, 0 };

            // Act
            List<int> actualVisitedIndicesStartingFrom0 = graph.DepthFirstTravel(0);
            List<int> actualVisitedIndicesStartingFrom1 = graph.DepthFirstTravel(1);

            // Assert
            Assert.Equal(expectedVisitedIndicesStartingFrom0, actualVisitedIndicesStartingFrom0);
            Assert.Equal(expectedVisitedIndicesStartingFrom1, actualVisitedIndicesStartingFrom1);
        }

        // 0->1-> 2 ->5
        //  \    | \
        //   \   ↓  ↓
        //    -> 3->4
        [Fact]
        public void DepthFirstTravel_EightEdgesGraph()
        {
            // Arrange
            DirectedGraph graph = Create8EdgesGraph();

            List<int> expectedVisitedIndicesStartingFrom0 = new List<int> { 0, 3, 4, 1, 2, 5 };
            List<int> expectedVisitedIndicesStartingFrom4 = new List<int> { 4 };

            // Act
            List<int> actualVisitedIndicesStartingFrom0 = graph.DepthFirstTravel(0);
            List<int> actualVisitedIndicesStartingFrom4 = graph.DepthFirstTravel(4);

            // Assert
            Assert.Equal(expectedVisitedIndicesStartingFrom0, actualVisitedIndicesStartingFrom0);
            Assert.Equal(expectedVisitedIndicesStartingFrom4, actualVisitedIndicesStartingFrom4);
        }

        // 0-1
        [Fact]
        public void DepthFirstRecursiveTravel_OneEdgeGraph()
        {
            // Arrange
            UndirectedGraph graph = new UndirectedGraph();
            graph.AddVertex();
            graph.AddVertex();
            graph.AddEdge(0, 1);

            List<int> expectedVisitedIndicesStartingFrom0 = new List<int> { 0, 1 };

            // Act
            List<int> actualVisitedIndicesStartingFrom0 = graph.DepthFirstRecursiveTravel(0);

            // Assert
            Assert.Equal(expectedVisitedIndicesStartingFrom0, actualVisitedIndicesStartingFrom0);
        }

        // 0->1-> 2 ->5
        //  \    | \
        //   \   ↓  ↓
        //    -> 3->4
        [Fact]
        public void DepthFirstRecursiveTravel_EightEdgesGraph()
        {
            // Arrange
            DirectedGraph graph = Create8EdgesGraph();

            List<int> expectedVisitedIndicesStartingFrom0 = new List<int> { 0, 1, 2, 3, 4, 5 };
            List<int> expectedVisitedIndicesStartingFrom3 = new List<int> { 3, 4 };

            // Act
            List<int> actualVisitedIndicesStartingFrom0 = graph.DepthFirstRecursiveTravel(0);
            List<int> actualVisitedIndicesStartingFrom3 = graph.DepthFirstRecursiveTravel(3);

            // Assert
            Assert.Equal(expectedVisitedIndicesStartingFrom0, actualVisitedIndicesStartingFrom0);
            Assert.Equal(expectedVisitedIndicesStartingFrom3, actualVisitedIndicesStartingFrom3);
        }

        // 0-1
        [Fact]
        public void CalculateMinDistance_OneEdgeGraph()
        {
            // Arrange
            UndirectedGraph graph = new UndirectedGraph();
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

        // 0->1-> 2 ->5
        //  \    | \
        //   \   ↓  ↓
        //    -> 3->4
        [Fact]
        public void CalculateMinDistance_EightEdgesGraph()
        {
            // Arrange
            DirectedGraph graph = Create8EdgesGraph();

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

        // 0->1->2->3 
        [Fact]
        public void FindConnectedComponents_OneConnectedComponents()
        {
            // Arrange
            UndirectedGraph graph = new UndirectedGraph();

            graph.AddVertex();
            graph.AddVertex();
            graph.AddVertex();
            graph.AddVertex();

            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);

            List<List<int>> expectedConnectedComponents = new List<List<int>>()
            {
                new List<int> { 0,1,2,3 }
            };

            // Act
            List<List<int>> actualConnectedComponents = graph.FindConnectedComponents();

            // Assert
            Assert.Equal(expectedConnectedComponents.Count, actualConnectedComponents.Count);

            foreach (List<int>? connectedIndices in expectedConnectedComponents)
            {
                Assert.Contains(connectedIndices, actualConnectedComponents);
            }
        }

        // 0->1  2->3 4
        [Fact]
        public void FindConnectedComponents_ThreeConnectedComponents()
        {
            // Arrange
            UndirectedGraph graph = new UndirectedGraph();

            graph.AddVertex();
            graph.AddVertex();
            graph.AddVertex();
            graph.AddVertex();
            graph.AddVertex();

            graph.AddEdge(0, 1);
            graph.AddEdge(2, 3);

            List<List<int>> expectedConnectedComponents = new List<List<int>>()
            {
                new List<int> { 2, 3 },
                new List<int> { 0, 1 },
                new List<int> { 4 }
            };

            // Act
            List<List<int>> actualConnectedComponents = graph.FindConnectedComponents();

            // Assert
            Assert.Equal(expectedConnectedComponents.Count, actualConnectedComponents.Count);

            foreach (List<int>? connectedIndices in expectedConnectedComponents)
            {
                Assert.Contains(connectedIndices, actualConnectedComponents);
            }
        }

        // 0->1->2
        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(30)]
        public void FindTopologicalOrder_StarightGraph(int seedVal)
        {
            // Arrange
            DirectedGraph graph = new DirectedGraph();

            graph.AddVertex();
            graph.AddVertex();
            graph.AddVertex();

            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);



            List<int> expectedTopologicalOrder = new List<int>() { 2, 1, 0 };

            // Act
            var actualTopologicalOrder = graph.FindTopologicalOrder();

            // Assert
            Assert.Equal(expectedTopologicalOrder, actualTopologicalOrder);
        }

        //    1
        //   ↗ ↘
        //  0   3
        //   ↘ ↗
        //    2 
        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(30)]
        public void FindTopologicalOrder_DiamondGraph(int seedVal)
        {
            // Arrange
            DirectedGraph graph = new DirectedGraph();

            graph.AddVertex();
            graph.AddVertex();
            graph.AddVertex();
            graph.AddVertex();

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);

            List<List<int>> expectedTopologicalOrders = new List<List<int>>()
           {
               new List<int>() { 3,1,2,0 },
               new List<int>() { 3,2,1,0 }
           };


            // Act
            List<int> actualTopologicalOrder = graph.FindTopologicalOrder();

            // Assert
            Assert.Contains(actualTopologicalOrder, expectedTopologicalOrders);
        }


        //    1 -> 4
        //   ↗ ↘  ↗
        //  0   3
        //   ↘ ↗  ↘
        //    2 -> 5 
        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(30)]
        public void FindTopologicalOrder_ComplexGraph(int seedVal)
        {
            // Arrange
            DirectedGraph graph = new DirectedGraph();

            graph.AddVertex();
            graph.AddVertex();
            graph.AddVertex();
            graph.AddVertex();
            graph.AddVertex();
            graph.AddVertex();

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 5);
            graph.AddEdge(3, 4);
            graph.AddEdge(3, 5);

            List<List<int>> expectedTopologicalOrders = new List<List<int>>()
           {
               new List<int>() {5,4,3,2,1,0 },
               new List<int>() {4,5,3,2,1,0 },
               new List<int>() {5,4,3,1,2,0},
               new List<int>() {4,5,3,1,2,0 }
           };


            // Act
            List<int> actualTopologicalOrder = graph.FindTopologicalOrder();

            // Assert
            Assert.Contains(actualTopologicalOrder, expectedTopologicalOrders);
        }

        //0->1->2
        [Fact]
        public void FindStronglyConnectedComponents_StraightGraph_ReturnsSCC()
        {
            // Arrange
            DirectedGraph graph = new DirectedGraph();

            graph.AddVertex();
            graph.AddVertex();
            graph.AddVertex();

            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);

            List<List<int>> expectedSCC = new List<List<int>>()
            {
                new List<int>(){0},
                new List<int>(){1},
                new List<int>(){2}
            };

            // Act
            List<List<int>> actualSCC = graph.FindStronglyConnectedComponents();
            expectedSCC.ForEach(s => s.Sort());
            actualSCC.ForEach(s => s.Sort());

            // Assert
            Assert.Equal(expectedSCC.Count, actualSCC.Count);
            foreach (List<int> scc in expectedSCC)
            {
                Assert.Contains(scc, actualSCC);
            }
        }

        //0->1->2
        //    <-
        [Fact]
        public void FindStronglyConnectedComponents_GraphWithTwoWay_ReturnsSCC()
        {
            // Arrange
            DirectedGraph graph = new DirectedGraph();

            graph.AddVertex();
            graph.AddVertex();
            graph.AddVertex();

            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 1);

            List<List<int>> expectedSCC = new List<List<int>>()
            {
                new List<int>(){0},
                new List<int>(){1,2}
            };

            // Act
            List<List<int>> actualSCC = graph.FindStronglyConnectedComponents();
            expectedSCC.ForEach(s => s.Sort());
            actualSCC.ForEach(s => s.Sort());

            // Assert
            Assert.Equal(expectedSCC.Count, actualSCC.Count);
            foreach (List<int> scc in expectedSCC)
            {
                Assert.Contains(scc, actualSCC);
            }
        }

        // 0->1-> 2 ->5
        //  \    | \
        //   \   ↓  ↓
        //    -> 3->4
        private DirectedGraph Create8EdgesGraph()
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
