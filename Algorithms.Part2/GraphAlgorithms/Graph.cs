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
        public Dictionary<int, List<int>> VertexIdToConnectedVertexIds { get; private set; } =
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
        }

        public List<int> GetConnectedVertices(int vertexId)
        {
            VertexIdToConnectedVertexIds.TryGetValue(vertexId, out List<int> connectedVertices);
            return connectedVertices;
        }
    }
}
