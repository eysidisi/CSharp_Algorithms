namespace Algorithms.Part1.Graph
{
    public class Edge
    {
        static int lastEdgeId = 0;
        static private object SyncObj = new object();

        public int Id { get; private set; }
        public Edge()
        {
            lock (SyncObj)
            {
                Id = lastEdgeId++;
            }
        }

        public Vertex firstVertex;
        public Vertex secondVertex;
    }

}
