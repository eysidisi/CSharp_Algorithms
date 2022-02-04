using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part2.GraphAlgorithms
{
    public class Graph
    {
        public List<int> VertexIds { get; private set; } = new List<int>();
        private Dictionary<int, List<int>> VertexIdToConnectedVertexIds { get; set; } =
            new Dictionary<int, List<int>>();

        int nextVertexIndex = 0;

        public void AddVertex()
        {
            VertexIdToConnectedVertexIds.Add(nextVertexIndex, new List<int>());
            VertexIds.Add(nextVertexIndex++);
        }

        public void AddEdge(int vertex1Id, int vertex2Id)
        {
            if (VertexIds.Contains(vertex1Id) == false ||
                VertexIds.Contains(vertex2Id) == false)
            {
                throw new ArgumentException("Invalid vertex Id");
            }

            ConnectSourceVertexToTarget(vertex1Id, vertex2Id);
            ConnectSourceVertexToTarget(vertex2Id, vertex1Id);
        }

        private void ConnectSourceVertexToTarget(int sourceVertex, int targetVertex)
        {
            if (VertexIdToConnectedVertexIds.TryGetValue(sourceVertex, out _) == false)
            {
                VertexIdToConnectedVertexIds.Add(sourceVertex, new List<int>());

            }

            VertexIdToConnectedVertexIds[sourceVertex].Add(targetVertex);

            // To make sure that in search algorithms vertices with smaller indices
            // come before the ones with larger indices
            VertexIdToConnectedVertexIds[sourceVertex].Sort();
        }

        public List<int> GetConnectedVertices(int vertexId)
        {
            VertexIdToConnectedVertexIds.TryGetValue(vertexId, out List<int> connectedVertices);
            return connectedVertices;
        }

        public List<int> BreadthFirstTravel(int startingVertexIndex)
        {
            List<int> visitedVertices = new List<int>();

            Queue<int> verticesToVisit = new Queue<int>();

            verticesToVisit.Enqueue(startingVertexIndex);

            while (verticesToVisit.Count != 0)
            {
                int currentVertexId = verticesToVisit.Dequeue();

                visitedVertices.Add(currentVertexId);

                foreach (int adjacentVertexId in VertexIdToConnectedVertexIds[currentVertexId])
                {
                    if (visitedVertices.Contains(adjacentVertexId) == false &&
                        verticesToVisit.Contains(adjacentVertexId) == false)
                    {
                        verticesToVisit.Enqueue(adjacentVertexId);
                    }
                }
            }

            return visitedVertices;
        }

        public Dictionary<int, int> FindMinDistancesToVertex(int rootVertexIndex)
        {
            List<int> visitedVertices = new List<int>();

            Queue<int> verticesToVisit = new Queue<int>();

            verticesToVisit.Enqueue(rootVertexIndex);

            Dictionary<int, int> vertexIdToDistance = new Dictionary<int, int>();

            // Distance from the source vertex to itself is 0
            vertexIdToDistance.Add(rootVertexIndex, 0);

            while (verticesToVisit.Count != 0)
            {
                int currentVertexId = verticesToVisit.Dequeue();

                visitedVertices.Add(currentVertexId);

                foreach (var adjacentVertexId in VertexIdToConnectedVertexIds[currentVertexId])
                {
                    if (visitedVertices.Contains(adjacentVertexId) == false &&
                        verticesToVisit.Contains(adjacentVertexId) == false)
                    {
                        verticesToVisit.Enqueue(adjacentVertexId);

                        vertexIdToDistance.Add(adjacentVertexId, vertexIdToDistance[currentVertexId] + 1);
                    }
                }
            }

            return vertexIdToDistance;
        }

        public List<List<int>> FindConnectedComponents()
        {
            List<List<int>> allConnectedComponents = new List<List<int>>();
            List<int> notVisitedVertexIds = new List<int>(VertexIds);

            while (notVisitedVertexIds.Count != 0)
            {
                int currentVertexId = notVisitedVertexIds[0];

                List<int> connectedIndices = BreadthFirstTravel(currentVertexId);

                connectedIndices.Sort();

                allConnectedComponents.Add(connectedIndices);

                notVisitedVertexIds.RemoveAll(vertexId => connectedIndices.Contains(vertexId));
            }

            return allConnectedComponents;
        }

        public List<int> DepthFirstTravel(int startingIndex)
        {
            List<int> visitedVertexIndices = new List<int>();

            Stack<int> vertexIdStack = new Stack<int>();

            vertexIdStack.Push(startingIndex);

            while (vertexIdStack.Count != 0)
            {
                int vertexIdBeingVisited = vertexIdStack.Pop();

                if (visitedVertexIndices.Contains(vertexIdBeingVisited) == false)
                {
                    visitedVertexIndices.Add(vertexIdBeingVisited);

                    foreach (var neighbourVertexId in VertexIdToConnectedVertexIds[vertexIdBeingVisited])
                    {
                        vertexIdStack.Push(neighbourVertexId);
                    }
                }
            }

            return visitedVertexIndices;
        }

        public List<int> DepthFirstRecursiveTravel(int vertexIndex)
        {
            List<int> visitedVertices = new List<int>();
            DepthFirstRecursiveTravel(visitedVertices, vertexIndex);
            return visitedVertices;
        }

        public void DepthFirstRecursiveTravel(List<int> visitedVertices, int vertexIndex)
        {
            visitedVertices.Add(vertexIndex);

            foreach (var neighbourVertexId in VertexIdToConnectedVertexIds[vertexIndex])
            {
                if (visitedVertices.Contains(neighbourVertexId) == false)
                {
                    DepthFirstRecursiveTravel(visitedVertices, neighbourVertexId);
                }
            }

        }
    }
}
