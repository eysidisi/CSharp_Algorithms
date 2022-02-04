using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part2.GraphAlgorithms
{
    public class Graph
    {
        public List<int> VerticesId { get; private set; } = new List<int>();
        private Dictionary<int, List<int>> VertexIdToConnectedVertexIds { get; set; } =
            new Dictionary<int, List<int>>();

        int nextVertexIndex = 0;

        public void AddVertex()
        {
            VerticesId.Add(nextVertexIndex++);
        }

        public void AddEdge(int vertex1Id, int vertex2Id)
        {
            if (VerticesId.Contains(vertex1Id) == false ||
                VerticesId.Contains(vertex2Id) == false)
            {
                throw new ArgumentException("Invalid vertex Id");
            }

            ConnectSourceVertexToTarget(vertex1Id, vertex2Id);
            ConnectSourceVertexToTarget(vertex2Id, vertex1Id);
        }

        private void ConnectSourceVertexToTarget(int sourceVertex, int targetVertex)
        {
            if (VertexIdToConnectedVertexIds.TryGetValue(sourceVertex, out _) == false)
            {
                VertexIdToConnectedVertexIds.Add(sourceVertex, new List<int>());

            }

            VertexIdToConnectedVertexIds[sourceVertex].Add(targetVertex);

            // To make sure that in search algorithms vertices with smaller indices
            // come before the ones with larger indices
            VertexIdToConnectedVertexIds[sourceVertex].Sort();
        }

        public List<int> GetConnectedVertices(int vertexId)
        {
            VertexIdToConnectedVertexIds.TryGetValue(vertexId, out List<int> connectedVertices);
            return connectedVertices;
        }

        public List<int> BreadthFirstTravel(int startingVertexIndex)
        {
            List<int> visitedVertices = new List<int>();

            Queue<int> verticesToVisit = new Queue<int>();

            verticesToVisit.Enqueue(startingVertexIndex);

            while (verticesToVisit.Count != 0)
            {
                int currentVertexId = verticesToVisit.Dequeue();

                visitedVertices.Add(currentVertexId);

                foreach (int adjacentVertexId in VertexIdToConnectedVertexIds[currentVertexId])
                {
                    if (visitedVertices.Contains(adjacentVertexId) == false &&
                        verticesToVisit.Contains(adjacentVertexId) == false)
                    {
                        verticesToVisit.Enqueue(adjacentVertexId);
                    }
                }
            }

            return visitedVertices;
        }

        public Dictionary<int, int> FindMinDistancesToVertex(int rootVertexIndex)
        {
            List<int> visitedVertices = new List<int>();

            Queue<int> verticesToVisit = new Queue<int>();

            verticesToVisit.Enqueue(rootVertexIndex);

            Dictionary<int, int> vertexIdToDistance = new Dictionary<int, int>();

            // Distance from the source vertex to itself is 0
            vertexIdToDistance.Add(rootVertexIndex, 0);

            while (verticesToVisit.Count != 0)
            {
                int currentVertexId = verticesToVisit.Dequeue();

                visitedVertices.Add(currentVertexId);

                foreach (var adjacentVertexId in VertexIdToConnectedVertexIds[currentVertexId])
                {
                    if (visitedVertices.Contains(adjacentVertexId) == false &&
                        verticesToVisit.Contains(adjacentVertexId) == false)
                    {
                        verticesToVisit.Enqueue(adjacentVertexId);

                        vertexIdToDistance.Add(adjacentVertexId, vertexIdToDistance[currentVertexId] + 1);
                    }
                }
            }

            return vertexIdToDistance;
        }
    }
}
