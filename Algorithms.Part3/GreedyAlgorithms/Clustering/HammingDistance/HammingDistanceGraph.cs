using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part3.GreedyAlgorithms.Clustering.HammingDistance
{
    public class HammingDistanceGraph
    {
        Dictionary<int, List<int>> leaderToNodeIDs;
        int[] nodeIDToLeader;
        public int GetNumberOfClusters(string path)
        {
            List<HammingDistanceNode> nodes = ReadNodes(path);
            int numOfClusters = nodes.Count;

            InitializeClusterLeaders(nodes.Count);

            for (int i = 0; i < nodes.Count - 1; i++)
            {
                for (int j = i + 1; j < nodes.Count; j++)
                {
                    HammingDistanceNode node1 = nodes[i];
                    HammingDistanceNode node2 = nodes[j];

                    if (AreNodesCloseEnough(node1, node2))
                    {
                        if (AreNodesInDifferentClusters(node1, node2))
                        {
                            ClusterNodes(node1, node2);
                            numOfClusters--;
                        }
                    }
                }
            }

            return numOfClusters;
        }

        private void InitializeClusterLeaders(int numOfNodes)
        {
            leaderToNodeIDs = new Dictionary<int, List<int>>();
            nodeIDToLeader = new int[numOfNodes];

            for (int i = 0; i < numOfNodes; i++)
            {
                nodeIDToLeader[i] = i;
                List<int> nodeIDs = new List<int>() { i };
                leaderToNodeIDs.Add(i, nodeIDs);
            }
        }

        private static List<HammingDistanceNode> ReadNodes(string path)
        {
            string[] lines = File.ReadAllLines(path);
            lines = lines.TakeLast(lines.Length - 1).ToArray();
            lines = lines.Distinct().ToArray();

            List<HammingDistanceNode> nodes = new List<HammingDistanceNode>();
            for (int i = 0; i < lines.Length; i++)
            {
                HammingDistanceNode node = new HammingDistanceNode(lines[i], i);
                nodes.Add(node);
            }

            return nodes;
        }

        private void ClusterNodes(HammingDistanceNode node1, HammingDistanceNode node2)
        {
            int node1ClusterLeader = nodeIDToLeader[node1.ID];
            int node2ClusterLeader = nodeIDToLeader[node2.ID];

            List<int> nodesInCluster1 = leaderToNodeIDs[node1ClusterLeader];
            leaderToNodeIDs.Remove(node1ClusterLeader);

            leaderToNodeIDs[node2ClusterLeader].AddRange(nodesInCluster1);

            foreach (var nodeID in nodesInCluster1)
            {
                nodeIDToLeader[nodeID] = node2ClusterLeader;
            }
        }

        private bool AreNodesInDifferentClusters(HammingDistanceNode node1, HammingDistanceNode node2)
        {
            int node1ClusterLeader = nodeIDToLeader[node1.ID];
            int node2ClusterLeader = nodeIDToLeader[node2.ID];

            if (node1ClusterLeader != node2ClusterLeader)
            {
                return true;
            }

            return false;
        }

        private bool AreNodesCloseEnough(HammingDistanceNode node1, HammingDistanceNode node2)
        {
            int hammingDistance = CalculateHammingDistance(node1.BinaryValue, node2.BinaryValue);

            if (hammingDistance < 3)
            {
                return true;
            }

            return false;
        }

        private int CalculateHammingDistance(int n1, int n2)
        {
            int x = n1 ^ n2;
            int setBits = 0;

            while (x > 0)
            {
                setBits += x & 1;
                x >>= 1;
            }

            return setBits;
        }
    }
}
