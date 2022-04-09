using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace Algorithms.Part3.GreedyAlgorithms.MinimumSpanningTree
{
    public class Tree
    {
        List<Edge> edges;
        List<Node> nodes;

        int currentEdgeID = 0;
        int currentNodeID = 0;

        public Tree(int numOfNodes, int numOfEdges)
        {
            InitializeNodesNEdges(numOfNodes, numOfEdges);
        }

        public Tree()
        {
        }

        private void InitializeNodesNEdges(int numOfNodes, int numOfEdges)
        {
            edges = new List<Edge>(numOfEdges);
            nodes = new List<Node>(numOfNodes);

            for (int i = 0; i < numOfNodes; i++)
            {
                Node newNode = new Node(currentNodeID);
                currentNodeID++;
                nodes.Add(newNode);
            }
        }

        public void AddEdge(int node1ID, int node2ID, int length)
        {
            Edge edge = new Edge(currentEdgeID, length);
            currentEdgeID++;

            Node node1 = nodes.Find(n => n.ID == node1ID);
            Node node2 = nodes.Find(n => n.ID == node2ID);

            edge.ConnectNodes(node1, node2);
        }

        public long FindMinimumSpanningTreeTotalCost(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            string[] treeEdgeNodeInfo = lines[0].Split(new char[] { ' ' });

            int numOfNodes = int.Parse(treeEdgeNodeInfo[0]);
            int numOfEdges = int.Parse(treeEdgeNodeInfo[1]);

            InitializeNodesNEdges(numOfNodes, numOfEdges);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] edgeInfo = lines[i].Split(new char[] { ' ' });

                int nodeIndex1 = int.Parse(edgeInfo[0]) - 1;
                int nodeIndex2 = int.Parse(edgeInfo[1]) - 1;
                int edgeLength = int.Parse(edgeInfo[2]);

                AddEdge(nodeIndex1, nodeIndex2, edgeLength);
            }

            return FindMinimumSpanningTreeTotalCost();
        }

        SimplePriorityQueue<Node, int> nodesHeap;
        Dictionary<int, Edge> nodeIDToSelectedShortestEdge;
        int[] nodeDistances;
        List<Edge> minimumSpanTreeEdges;
        bool[] isNodeVisited;
        Node startingNode;

        public long FindMinimumSpanningTreeTotalCost()
        {
            SetStartingNode();

            InitializeGlobalVariables();

            InitializeNodeDistancesHeap();

            VisitStartingNode();

            while (nodesHeap.Count() != 0)
            {
                Node closestNode = nodesHeap.Dequeue();
                VisitNode(closestNode);
            }

            long result = CalculateSumOfLengths();
            return result;
        }

        private Node FindNotVisitedNode(Edge edge)
        {
            return edge.Nodes.ToList().Find(n => isNodeVisited[n.ID] == false);
        }

        private void SetStartingNode()
        {
            int startingNodeIndex = 0;
            startingNode = nodes.Find(n => n.ID == startingNodeIndex);
        }

        private bool DoesNewEdgeGetsNotVisitedNodeCloser(Edge edge, Node notVisitedNode)
        {
            return nodeDistances[notVisitedNode.ID] > edge.Length;
        }

        private long CalculateSumOfLengths()
        {
            long result = 0;

            minimumSpanTreeEdges.ForEach(e => result += e.Length);
            return result;
        }

        private void UpdateNodeDistance(Node node, Edge edge)
        {
            nodeDistances[node.ID] = edge.Length;
            nodeIDToSelectedShortestEdge[node.ID] = edge;
            nodesHeap.UpdatePriority(node, edge.Length);
        }

        private void VisitNode(Node node)
        {
            isNodeVisited[node.ID] = true;
            Edge shortestEdgeToTheNode = nodeIDToSelectedShortestEdge[node.ID];
            minimumSpanTreeEdges.Add(shortestEdgeToTheNode);
            UpdateConnectedNodeDistancesToTheGivenNode(node);
        }

        private void UpdateConnectedNodeDistancesToTheGivenNode(Node node)
        {
            var closestNodeEdges = node.Edges;

            foreach (var edge in closestNodeEdges)
            {
                if (CheckIfEdgeIsFrontier(edge))
                {
                    Node notVisitedNode = FindNotVisitedNode(edge);

                    if (DoesNewEdgeGetsNotVisitedNodeCloser(edge, notVisitedNode))
                    {
                        UpdateNodeDistance(notVisitedNode, edge);
                    }
                }
            }
        }

        private void VisitStartingNode()
        {
            isNodeVisited[startingNode.ID] = true;

            var edgesFromStartingNode = startingNode.Edges;

            foreach (var edge in edgesFromStartingNode)
            {
                Node notVisitedNode = edge.Nodes.ToList().Find(n => n != startingNode);

                nodesHeap.UpdatePriority(notVisitedNode, edge.Length);

                nodeDistances[notVisitedNode.ID] = edge.Length;

                nodeIDToSelectedShortestEdge.Add(notVisitedNode.ID, edge);
            }
        }

        private void InitializeNodeDistancesHeap()
        {
            foreach (var node in nodes)
            {
                if (node != startingNode)
                {
                    nodesHeap.Enqueue(node, int.MaxValue);
                }
            }

            for (int i = 0; i < nodeDistances.Length; i++)
            {
                nodeDistances[i] = int.MaxValue;
            }
        }

        private void InitializeGlobalVariables()
        {
            nodesHeap = new SimplePriorityQueue<Node, int>();
            nodeIDToSelectedShortestEdge = new Dictionary<int, Edge>();
            isNodeVisited = new bool[nodes.Count];
            minimumSpanTreeEdges = new List<Edge>();
            nodeDistances = new int[nodes.Count];
        }

        private bool CheckIfEdgeIsFrontier(Edge edge)
        {
            foreach (var node in edge.Nodes)
            {
                if (isNodeVisited[node.ID] == false)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
