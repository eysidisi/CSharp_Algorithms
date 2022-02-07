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

            List<int> depthFirstVisitedNodes = new List<int>();

            Stack<>

            while (notVisitedVertices.Count() != 0)
            {
                int nodeIndexToVisit;

                if (depthFirstVisitedNodes.Count != 0)
                {
                    nodeIndexToVisit = depthFirstVisitedNodes.Last();
                }

                else
                {
                    Random random = new Random();
                    var index = random.Next(notVisitedVertices.Count);
                    nodeIndexToVisit = notVisitedVertices[index];
                }

                depthFirstVisitedNodes = new List<int>(topologicalOrder);

                DepthFirstRecursiveTravel(depthFirstVisitedNodes, nodeIndexToVisit);


            }
        }
    }
}
