namespace Algorithms.Part1.Graph
{
    public class Vertex
    {
        static int vertexId = 0;
        private static object SyncObj = new object();
        public int Id { get; private set; }
        public Vertex()
        {
            lock (SyncObj)
            {
                Id = vertexId++;
            }
        }
        public List<Edge> edges = new List<Edge>();
    }
}
