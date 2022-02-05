namespace Algorithms.Part1.Graph
{
    public class Edge
    {
        List<Vertex> vertices = new List<Vertex>();
        public IReadOnlyList<Vertex> Vertices { get { return vertices; } }
        public int Id { get; private set; }
        public Edge(int id, Vertex vertex1, Vertex vertex2)
        {
            Id = id;
            vertices.Add(vertex1);
            vertices.Add(vertex2);
        }

        public void AddVertex(Vertex vertex)
        {
            if (vertices.Count() == 2)
            {
                throw new InvalidOperationException("Can't add new vertex!");
            }

            vertices.Add(vertex);
        }

        public void RemoveVertex(Vertex vertex)
        {
            if (vertices.Remove(vertex) == false)
            {
                throw new InvalidOperationException("Edge is not connected to the given vertex!");
            }
        }

        public void RemoveEdgeFromVertices()
        {
            vertices.ForEach(v => v.RemoveEdge(this));
        }
    }
}
