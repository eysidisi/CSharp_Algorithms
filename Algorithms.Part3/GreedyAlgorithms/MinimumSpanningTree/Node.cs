namespace Algorithms.Part3.GreedyAlgorithms.MinimumSpanningTree
{
    public class Node
    {
        public int ID { get; private set; }
        public IReadOnlyCollection<Edge> Edges => edges;
        private List<Edge> edges = new List<Edge>();

        public Node(int iD)
        {
            ID = iD;
        }

        public void AddEdge(Edge edge)
        {
            edges.Add(edge);
        }
    }
}