using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part1.Graph
{
    public partial class GraphRepresentation
    {

        List<Vertex> vertices;
        List<Edge> edges = new List<Edge>();

        public IReadOnlyList<Vertex> Vertices { get { return vertices; } }
        public IReadOnlyList<Edge> Edges { get { return edges; } }

        public GraphRepresentation(int numberOfvertices)
        {
            Initializevertices(numberOfvertices);
        }

        private void Initializevertices(int numberOfvertices)
        {
            vertices = new List<Vertex>();

            for (int i = 0; i < numberOfvertices; i++)
            {
                vertices.Add(new Vertex());
            }
        }

        public void AddEdge(int vertexId1, int vertexId2)
        {
            var vertex1 = vertices[vertexId1];
            var vertex2 = vertices[vertexId2];

            Edge edge = new Edge()
            {
                firstVertex = vertex1,
                secondVertex = vertex2
            };

            edges.Add(edge);

            vertex1.edges.Add(edge);
            vertex2.edges.Add(edge);
        }

        public void DeleteEdge(int edgeIdToDelete)
        {
            var edgeToDelete = edges.Find(e => e.Id == edgeIdToDelete);

            // Delete one vertex and contract with the other
            var deletedVertex = edgeToDelete.firstVertex;
            var contractedVertex = edgeToDelete.secondVertex;

            // Find all edges related to deleted vertex to assign them to contracted vertex
            var edgesConnectedToHeadVertex = edges.Where(e => e.firstVertex == deletedVertex || e.secondVertex == deletedVertex).ToArray();

            for (int edgeIndex = 0; edgeIndex < edgesConnectedToHeadVertex.Length; edgeIndex++)
            {
                var currentEdge = edgesConnectedToHeadVertex[edgeIndex];

                // Self loop
                if (currentEdge.firstVertex == contractedVertex || currentEdge.secondVertex == contractedVertex)
                {
                    currentEdge.firstVertex.edges.Remove(currentEdge);
                    currentEdge.secondVertex.edges.Remove(currentEdge);
                    edges.Remove(currentEdge);
                }

                else if (currentEdge.firstVertex == deletedVertex)
                {
                    currentEdge.firstVertex = contractedVertex;
                    contractedVertex.edges.Add(currentEdge);
                }

                else
                {
                    currentEdge.secondVertex = contractedVertex;
                    contractedVertex.edges.Add(currentEdge);
                }
            }

            deletedVertex.edges.Clear();
            edges.Remove(edgeToDelete);
            vertices.Remove(deletedVertex);
        }

    }
}
