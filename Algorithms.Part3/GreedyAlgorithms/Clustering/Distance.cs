using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part3.GreedyAlgorithms.Clustering
{
    public class Distance
    {
        public int ID { get; private set; }
        public int Length { get; private set; }
       public IReadOnlyCollection<Node> ConnectedNodes => connectedNodes;

        List<Node> connectedNodes = new List<Node>();
        public Distance(int iD, int length)
        {
            ID = iD;
            Length = length;
        }

        public void ConnectNodes(Node node0, Node node1)
        {
            connectedNodes.Add(node0);
            connectedNodes.Add(node1);
        }
    }
}
