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

        // These Ids are used for debugging purposes
        int nextEdgeId = 0;
        int nextVertexId = 0;

        public IReadOnlyList<Vertex> Vertices { get { return vertices; } }
        public IReadOnlyList<Edge> Edges { get { return edges; } }

        public GraphRepresentation(int numberOfvertices)
        {
            Initializevertices(numberOfvertices);
        }

        public int SelectRandomEdgeId()
        {
            var random = new Random();
            int index = random.Next(edges.Count);
            return edges[index].Id;
        }

        public GraphRepresentation(GraphRepresentation graph)
        {
            Initializevertices(graph.Vertices.Count);

            foreach (var edge in graph.edges)
            {
                AddEdge(edge.Vertices[0].Id, edge.Vertices[1].Id);
            }
        }

        public void ConnectVertices(int rootVertexIndex, int[] adjacentVertices)
        {
            var rootVertex = vertices[rootVertexIndex];

            foreach (var adjacentVertexIndex in adjacentVertices)
            {
                var adjacentVertex = vertices[adjacentVertexIndex];

                // Checking if two vertices are already connected
                if (edges.Any(edge =>
                edge.Vertices.Contains(rootVertex) && edge.Vertices.Contains(adjacentVertex)) == false)
                {
                    AddEdge(rootVertexIndex, adjacentVertexIndex);
                }
            }
        }

        private void Initializevertices(int numberOfvertices)
        {
            vertices = new List<Vertex>();

            for (int i = 0; i < numberOfvertices; i++)
            {
                vertices.Add(new Vertex(nextVertexId));
                nextVertexId++;
            }
        }

        public void AddEdge(int vertexId1, int vertexId2)
        {
            var vertex1 = vertices[vertexId1];
            var vertex2 = vertices[vertexId2];

            Edge edge = new Edge(nextEdgeId, vertex1, vertex2);
            nextEdgeId++;

            edges.Add(edge);

            vertex1.AddEdge(edge);
            vertex2.AddEdge(edge);
        }

        public void ContractEdge(int edgeIdToDelete)
        {
            var edgeToDelete = edges.Find(e => e.Id == edgeIdToDelete);

            // Delete one vertex and contract with the other
            var deletedVertex = edgeToDelete.Vertices[0];
            var unitedVertex = edgeToDelete.Vertices[1];

            var edgesConnectedToDeletedVertex = edges.Where(edge => edge.Vertices.Contains(deletedVertex)).ToArray();

            for (int edgeIndex = 0; edgeIndex < edgesConnectedToDeletedVertex.Length; edgeIndex++)
            {
                var currentEdge = edgesConnectedToDeletedVertex[edgeIndex];

                // Self loop
                if (currentEdge.Vertices.Contains(unitedVertex))
                {
                    DeleteEdge(currentEdge);
                }

                else
                {
                    currentEdge.RemoveVertex(deletedVertex);
                    currentEdge.AddVertex(unitedVertex);
                    unitedVertex.AddEdge(currentEdge);
                }
            }

            edges.Remove(edgeToDelete);
            vertices.Remove(deletedVertex);
        }

        private void DeleteEdge(Edge currentEdge)
        {
            currentEdge.RemoveEdgeFromVertices();
            edges.Remove(currentEdge);
        }
    }
}
