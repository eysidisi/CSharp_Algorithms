using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part1.Graph
{
    public class Vertex
    {
        public List<Edge> edges = new List<Edge>();
    }

    public class Edge
    {
        public Vertex headVertex;
        public Vertex tailVertex;
    }
    public class GraphRepresentation
    {
        List<Vertex> vertices;
        List<Edge> edges = new List<Edge>();

        int numberOfVertices;

        public GraphRepresentation(int numberOfVertices)
        {
            this.numberOfVertices = numberOfVertices;
            InitializeVertices();
        }

        private void InitializeVertices()
        {
            vertices = new List<Vertex>(numberOfVertices);

            for (int i = 0; i < vertices.Count(); i++)
            {
                vertices[i] = new Vertex();
            }
        }

        public void AddEdge(int vertexId1, int vertexId2)
        {
            var vertex1 = vertices[vertexId1];
            var vertex2 = vertices[vertexId2];

            Edge edge = new Edge()
            {
                headVertex = vertex1,
                tailVertex = vertex2
            };

            edges.Add(edge);

            vertex1.edges.Add(edge);
            vertex2.edges.Add(edge);
        }

        public void DeleteEdge(int edgeId)
        {
            var edgeToDelete = edges[edgeId];

            var vertex1 = edgeToDelete.headVertex;
            var vertex2 = edgeToDelete.tailVertex;

            // Find all edges going to vertex2
            var edgesGoingInVertex2 = edges.Where(e => e.headVertex == vertex2 || e.tailVertex == vertex2).ToArray();

            foreach (var edge in edgesGoingInVertex2)
            {
                // Self loop
                if (edge.headVertex == vertex1 || edge.tailVertex == vertex1)
                {
                    edges.Remove(edge);
                }

                else
                {

                }
            }

        }

    }
}
