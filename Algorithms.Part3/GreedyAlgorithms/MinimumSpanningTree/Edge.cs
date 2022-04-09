using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part3.GreedyAlgorithms.MinimumSpanningTree
{
    public class Edge
    {
        public int ID { get; private set; }
        public IReadOnlyList<Node> Nodes => connectedNodes;
        public int Length { get; private set; }

        List<Node> connectedNodes;

        public Edge(int iD, int length)
        {
            ID = iD;
            Length = length;
        }
        public void ConnectNodes(Node node1, Node node2)
        {
            connectedNodes = new List<Node>();
            connectedNodes.Add(node1);
            connectedNodes.Add(node2);
            node1.AddEdge(this);
            node2.AddEdge(this);
        }
    }
}
