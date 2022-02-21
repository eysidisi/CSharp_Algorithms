using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part2.GraphAlgorithms.DijkstrasAlgorithm
{
    public struct Edge
    {
        public int destVertex;
        public int weight;

        public Edge(int destVertex, int weight)
        {
            this.destVertex = destVertex;
            this.weight = weight;
        }
    }
    public class UndirectedGraph
    {
        public IReadOnlyList<List<Edge>> Edges
        {
            get
            {
                return edges;
            }
        }

        public int NumOfVertices { get; private set; }
        List<List<Edge>> edges;

        public UndirectedGraph(int numberOfVertices)
        {
            NumOfVertices = numberOfVertices;
            edges = new List<List<Edge>>(numberOfVertices);

            for (int i = 0; i < numberOfVertices; i++)
            {
                edges.Add(new List<Edge>());
            }
        }

        public void AddEdge(int vertexIndex1, int vertexIndex2, int weight)
        {
            var edgeFromVertex1To2 = new Edge(vertexIndex2, weight);
            var edgeFromVertex2To1 = new Edge(vertexIndex1, weight);

            edges[vertexIndex1].Add(edgeFromVertex1To2);
            edges[vertexIndex2].Add(edgeFromVertex2To1);
        }
    }
}
