using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part2.GraphAlgorithms
{
    public class SCCDirectedGraph
    {
        public List<List<int>> indexIDsToIndexIDs = new List<List<int>>();

        public SCCDirectedGraph(int numOfIndices = 100)
        {
            indexIDsToIndexIDs = new List<List<int>>(numOfIndices);

            for (int i = 0; i < numOfIndices; i++)
            {
                indexIDsToIndexIDs.Add(new List<int>());
            }
        }

        public void ConnectVertex1ToVertex2(int vertex1ID, int vertex2ID)
        {
            indexIDsToIndexIDs[vertex1ID].Add(vertex2ID);
        }

        bool[] isVertexVisited;
        SortedDictionary<int, int> vertexWeightToVertexID;
        List<List<int>> reversed;

        public List<List<int>> FindStronglyConnectedComponents()
        {
            SCCDirectedGraphHelperMethods helperMethods = new SCCDirectedGraphHelperMethods();

            reversed = helperMethods.ReverseEdges(indexIDsToIndexIDs);

            isVertexVisited = new bool[reversed.Count];

            vertexWeightToVertexID = new SortedDictionary<int, int>();

            for (int vertexIndex = 0; vertexIndex < reversed.Count; vertexIndex++)
            {
                if (isVertexVisited[vertexIndex] == false)
                {
                    DepthFirstReversed();
                }
            }

            isVertexVisited = new bool[reversed.Count];

            List<List<int>> sCCs = new List<List<int>>(1000);

            foreach (var vertexWeightToVertexID in vertexWeightToVertexID.Reverse())
            {
                int vertexIndex = vertexWeightToVertexID.Value;

                if (isVertexVisited[vertexIndex] == false)
                {
                    var visitedNodes= DepthFirstStraight(vertexIndex);

                    sCCs.Add(visitedNodes);
                }
            }

            return sCCs;
        }

        private List<int> DepthFirstStraight(int vertexIndex)
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

                    List<int> neighbours = indexIDsToIndexIDs[currentIndex];

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

        int weight = 0;
        private void DepthFirstReversedRecursive(int vertexIndex)
        {
            if (isVertexVisited[vertexIndex] == false)
            {
                isVertexVisited[vertexIndex] = true;

                var neighbourVertices = reversed[vertexIndex];

                foreach (var neighbourVertex in neighbourVertices)
                {
                    DepthFirstReversedRecursive(neighbourVertex);
                }
            }

            weight++;
            vertexWeightToVertexID.Add(weight, vertexIndex);
        }

        private void DepthFirstReversed()
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

                    List<int> neighbours = reversed[currentIndex];

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

