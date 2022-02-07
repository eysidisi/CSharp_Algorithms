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

        public List<int> FindTopologicalOrder()
        {
            List<int> notVisitedVertices = new List<int>(VertexIds);

            List<int> topologicalOrder = new List<int>();

            Stack<int> nodesToVisitStack = new Stack<int>();

            int firstIndexToVisit = GetRandomVertexId(notVisitedVertices);

            nodesToVisitStack.Push(firstIndexToVisit);

            while (notVisitedVertices.Count() != 0)
            {
                int vertexIdToStart;

                if (nodesToVisitStack.Count != 0)
                {
                    vertexIdToStart = nodesToVisitStack.Pop();
                }

                else
                {
                    vertexIdToStart = GetRandomVertexId(notVisitedVertices);
                }

                List<int> depthFirstVisitedVertices = new List<int>(topologicalOrder);

                DepthFirstRecursiveTravel(depthFirstVisitedVertices, vertexIdToStart);

                int visitedVertexIndex = depthFirstVisitedVertices.Last();

                topologicalOrder.Add(visitedVertexIndex);

                notVisitedVertices.Remove(visitedVertexIndex);
            }

            return topologicalOrder;
        }

        private int GetRandomVertexId(List<int> notVisitedVertices)
        {
            int nodeIndexToVisit;
            Random random = new Random();
            var index = random.Next(notVisitedVertices.Count);
            nodeIndexToVisit = notVisitedVertices[index];
            return nodeIndexToVisit;
        }
    }
}
