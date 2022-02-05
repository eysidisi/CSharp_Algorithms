namespace Algorithms.Part1.Graph
{
    public class Vertex
    {
        public int Id { get; private set; }
        public Vertex(int id)
        {
            Id = id;
        }
        public IReadOnlyList<Edge> Edges { get { return edges; } }
        public List<Edge> edges = new List<Edge>();

        public void RemoveEdge(Edge edge)
        {
            if (edges.Remove(edge) == false)
            {
                throw new ArgumentException("edge is not connected to the vertex");
            }
        }

        public void AddEdge(Edge edge)
        {
            if (edges.Contains(edge))
            {
                throw new ArgumentException("edge is already present");
            }

            edges.Add(edge);
        }
    }
}
