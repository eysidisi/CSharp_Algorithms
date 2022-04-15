using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part3.GreedyAlgorithms.Clustering
{
    public class Graph
    {
        private int nextDistanceID = 0;
        List<Node> nodes = new List<Node>();
        List<Distance> distances = new List<Distance>();

        public Graph(int numOfNodes)
        {
            InitializeNodes(numOfNodes);
        }

        public static Graph ReadFile(string path)
        {
            string[] lines = File.ReadAllLines(path);

            int numOfNodes = int.Parse(lines[0]);

            Graph graph = new Graph(numOfNodes);

            for (int index = 1; index < lines.Length; index++)
            {
                string line = lines[index];
                string[] parsedLine = line.Split(' ');
                int nodeIndex1 = int.Parse(parsedLine[0]) - 1;
                int nodeIndex2 = int.Parse(parsedLine[1]) - 1;
                int length = int.Parse(parsedLine[2]);
                graph.AddDistance(nodeIndex1, nodeIndex2, length);
            }

            return graph;
        }
        public void AddDistance(int node0ID, int node1ID, int distanceBetweenNodes)
        {
            var node0 = nodes.Find(n => n.ID == node0ID);
            var node1 = nodes.Find(n => n.ID == node1ID);
            Distance distance = CreateDistance(node0, node1, distanceBetweenNodes);
            distances.Add(distance);
        }


        int currentNumOfClusters;
        List<Distance> sortedDistances;
        int nextShortesDistanceIndex;
        int[] clusterLeaders;
        public int CalculateMaxSpacing(int numberOfClusters)
        {
            currentNumOfClusters = nodes.Count;
            sortedDistances = distances.OrderBy(d => d.Length).ToList();
            nextShortesDistanceIndex = 0;
            clusterLeaders = new int[currentNumOfClusters];
            for (int i = 0; i < clusterLeaders.Length; i++)
            {
                clusterLeaders[i] = i;
            }

            while (currentNumOfClusters != numberOfClusters)
            {
                ClusterGraph();
                currentNumOfClusters--;
            }

            int maxSpacing = CalculateMaxSpacing();

            return maxSpacing;
        }

        private void ClusterGraph()
        {
            while (true)
            {
                var shortestDistance = sortedDistances[nextShortesDistanceIndex];
                nextShortesDistanceIndex++;
                Node node1 = shortestDistance.ConnectedNodes.ElementAt(0);
                Node node2 = shortestDistance.ConnectedNodes.ElementAt(1);

                if (AreTheNodesInTheSameCluster(node1, node2))
                {
                    continue;
                }

                else
                {
                    ClusterNodes(node1, node2);
                    break;
                }
            }
        }

        private void ClusterNodes(Node node1, Node node2)
        {
            int oldLeaderID = clusterLeaders[node1.ID];
            int newLeaderID = clusterLeaders[node2.ID];
            for (int i = 0; i < clusterLeaders.Length; i++)
            {
                if (clusterLeaders[i] == oldLeaderID)
                {
                    clusterLeaders[i] = newLeaderID;
                }
            }
        }

        private bool AreTheNodesInTheSameCluster(Node node1, Node node2)
        {
            if (clusterLeaders[node1.ID] == clusterLeaders[node2.ID])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int CalculateMaxSpacing()
        {
            foreach (var distance in sortedDistances)
            {
                Node node1 = distance.ConnectedNodes.ElementAt(0);
                Node node2 = distance.ConnectedNodes.ElementAt(1);

                if (clusterLeaders[node1.ID] != clusterLeaders[node2.ID])
                {
                    return distance.Length;
                }
            }

            throw new Exception();
        }

        private Distance CreateDistance(Node node0, Node node1, int distanceBetweenNodes)
        {
            Distance distance = new Distance(nextDistanceID++, distanceBetweenNodes);
            distance.ConnectNodes(node0, node1);
            return distance;
        }

        private void InitializeNodes(int numOfNodes)
        {
            for (int nodeID = 0; nodeID < numOfNodes; nodeID++)
            {
                nodes.Add(new Node(nodeID));
            }
        }
    }
}
