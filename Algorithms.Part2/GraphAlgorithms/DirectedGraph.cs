using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part2.GraphAlgorithms
{
    public class DirectedGraph : Graph
    {
        public override void AddEdge(int vertex1Id, int vertex2Id)
        {
            if (VertexIds.Contains(vertex1Id) == false ||
                VertexIds.Contains(vertex2Id) == false)
            {
                throw new ArgumentException("Invalid vertex ids");
            }

            ConnectSourceVertexToTheTargetVertex(vertex1Id, vertex2Id);
        }

        bool[] isVertexVisited;
        List<int> topologicalOrder;

        public List<int> FindTopologicalOrder()
        {
            isVertexVisited = new bool[VertexIds.Count];
            topologicalOrder = new List<int>();

            for (int i = 0; i < isVertexVisited.Length; i++)
            {
                isVertexVisited[i] = false;
            }

            foreach (var vertexId in VertexIds)
            {
                if (isVertexVisited[vertexId] == false)
                {
                    DepthFirstTopo(vertexId);
                }
            }

            return topologicalOrder;
        }

        private void DepthFirstTopo(int vertexIndex)
        {
            var neighbourNodes = VertexIdToConnectedVertexIds[vertexIndex];

            for (int i = 0; i < neighbourNodes.Count; i++)
            {
                int neighbourNodeIndex = neighbourNodes[i];

                if (isVertexVisited[neighbourNodeIndex] == false)
                {
                    DepthFirstTopo(neighbourNodeIndex);
                }
            }

            topologicalOrder.Add(vertexIndex);
            isVertexVisited[vertexIndex] = true;
        }

        SortedDictionary<int, int> vertexWeightToVertexID;
        int vertexWeight;
        public List<List<int>> FindStronglyConnectedComponents()
        {
            DirectedGraphHelperMethods helperMethods = new DirectedGraphHelperMethods();

            Dictionary<int, List<int>> reversedVertexDirections = helperMethods.ReverseVertexToConnectedVertexIDs(VertexIdToConnectedVertexIds);

            isVertexVisited = new bool[reversedVertexDirections.Count];
            vertexWeightToVertexID = new SortedDictionary<int, int>();
            vertexWeight = 0;

            for (int vertexIndex = 0; vertexIndex < reversedVertexDirections.Count; vertexIndex++)
            {
                if (isVertexVisited[vertexIndex] == false)
                {
                    isVertexVisited[vertexIndex] = true;

                    SCCDepthFirst(reversedVertexDirections, vertexIndex);
                }
            }

            throw new NotImplementedException();
        }

        private void SCCDepthFirst(Dictionary<int, List<int>> vertexIDsToConnectedVertexIDs, int vertexIndex)
        {
            List<int> neighbourVertices = vertexIDsToConnectedVertexIDs[vertexIndex];

            foreach (var vertexId in neighbourVertices)
            {
                if (isVertexVisited[vertexId] == false)
                {
                    isVertexVisited[vertexId] = true;
                    SCCDepthFirst(vertexIDsToConnectedVertexIDs, vertexId);
                }
            }

            vertexWeight++;

            vertexWeightToVertexID.Add(vertexWeight, vertexIndex);
        }
    }

}
