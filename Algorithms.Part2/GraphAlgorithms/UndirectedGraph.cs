using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part2.GraphAlgorithms
{
    public class UndirectedGraph : Graph
    {
        public override void AddEdge(int vertex1Id, int vertex2Id)
        {
            if (VertexIds.Contains(vertex1Id) == false ||
                VertexIds.Contains(vertex2Id) == false)
            {
                throw new ArgumentException("Invalid vertex Id");
            }

            ConnectSourceVertexToTheTargetVertex(vertex1Id, vertex2Id);
            ConnectSourceVertexToTheTargetVertex(vertex2Id, vertex1Id);
        }
    }
}
