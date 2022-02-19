using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part2.GraphAlgorithms.TarjansAlgorithm
{
    /// <summary>
    /// This class is created just for calculating the SCCs 
    /// since the original DirectedGraph implementation is slower when working with large graphs
    /// I used a loop instead of recursion when doing the depth first search
    /// Because it caused stack overflow with recursive approach
    /// </summary>
    public class DirectedGraph
    {
        public List<List<int>> vertexToVertexIDs = new List<List<int>>();

        public DirectedGraph(int numOfIndices = 100)
        {
            vertexToVertexIDs = new List<List<int>>(numOfIndices);

            for (int i = 0; i < numOfIndices; i++)
            {
                vertexToVertexIDs.Add(new List<int>());
            }
        }

        public void ConnectVertex1ToVertex2(int vertex1ID, int vertex2ID)
        {
            vertexToVertexIDs[vertex1ID].Add(vertex2ID);
        }

        bool[] isVertexVisited;
        SortedDictionary<int, int> vertexWeightToVertexID;
        List<List<int>> reversedVertexToVertexIDs;
        int weight = 0;

        public List<List<int>> FindStronglyConnectedComponents()
        {
            HelperMethods helperMethods = new HelperMethods();

            reversedVertexToVertexIDs = helperMethods.ReverseEdges(vertexToVertexIDs);

            isVertexVisited = new bool[reversedVertexToVertexIDs.Count];

            vertexWeightToVertexID = new SortedDictionary<int, int>();

            for (int vertexIndex = 0; vertexIndex < reversedVertexToVertexIDs.Count; vertexIndex++)
            {
                if (isVertexVisited[vertexIndex] == false)
                {
                    FindWeightsInReversedGraph();
                }
            }

            isVertexVisited = new bool[reversedVertexToVertexIDs.Count];

            List<List<int>> sCCs = new List<List<int>>(1000);

            foreach (var vertexWeightToVertexID in vertexWeightToVertexID.Reverse())
            {
                int vertexIndex = vertexWeightToVertexID.Value;

                if (isVertexVisited[vertexIndex] == false)
                {
                    var visitedNodes= GetDepthFirstVertices(vertexIndex);

                    sCCs.Add(visitedNodes);
                }
            }

            return sCCs;
        }

        private List<int> GetDepthFirstVertices(int vertexIndex)
        {
            Stack<int> stack = new Stack<int>(10000);
            stack.Push(vertexIndex);

            List<int> visitedNodes = new List<int>(1000);
            while (stack.Count > 0)
            {
                int currentIndex = stack.Pop();

                if (isVertexVisited[currentIndex] == false)
                {
                    isVertexVisited[currentIndex] = true;

                    visitedNodes.Add(currentIndex);

                    List<int> neighbours = vertexToVertexIDs[currentIndex];

                    foreach (int neighbour in neighbours)
                    {
                        if (isVertexVisited[neighbour] == false)
                        {
                            stack.Push(neighbour);
                        }
                    }
                }
            }

            return visitedNodes;
        }

        private void FindWeightsInReversedGraph()
        {
            for (int index = 0; index < isVertexVisited.Length; index++)
            {
                if (isVertexVisited[index] == false)
                {
                    List<int> visitedNodes = new List<int>(100000);

                    VisitDepthFirstReversed(index, visitedNodes);

                    for (int i = visitedNodes.Count - 1; i >= 0; i--)
                    {
                        weight++;
                        var vertexIndex = visitedNodes[i];
                        vertexWeightToVertexID.Add(weight, vertexIndex);
                    }
                }
            }
        }

        private void VisitDepthFirstReversed(int index, List<int> visitedNodes)
        {
            Stack<int> stack = new Stack<int>(10000);
            stack.Push(index);

            while (stack.Count > 0)
            {
                int currentIndex = stack.Pop();

                if (isVertexVisited[currentIndex] == false)
                {
                    isVertexVisited[currentIndex] = true;
                    visitedNodes.Add(currentIndex);

                    List<int> neighbours = reversedVertexToVertexIDs[currentIndex];

                    foreach (int neighbour in neighbours)
                    {
                        if (isVertexVisited[neighbour] == false)
                        {
                            stack.Push(neighbour);
                        }
                    }
                }
            }
        }
    }
}

