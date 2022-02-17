using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part2.GraphAlgorithms
{
    public class DirectedGraphHelperMethods
    {
        public Dictionary<int, List<int>> ReverseVertexToConnectedVertexIDs(Dictionary<int, List<int>> vertexIdsToConnectedVertexIds)
        {
            Dictionary<int, List<int>> reversedVertexToConnectedVertexIDs = new Dictionary<int, List<int>>();

            foreach (var vertexIdToConnectedIds in vertexIdsToConnectedVertexIds)
            {
                int vertexId = vertexIdToConnectedIds.Key;
                List<int> connectedVertices = vertexIdToConnectedIds.Value;

                foreach (var connectedVertex in connectedVertices)
                {
                    ConnectVertex1ToVertex2(connectedVertex, vertexId, reversedVertexToConnectedVertexIDs);
                }
            }

            return reversedVertexToConnectedVertexIDs;
        }

        static private object syncObj=new object();
        public DirectedGraph ReadInputFile(string filePath)
        {
            List<string> vertexLines = File.ReadAllLines(filePath).ToList();
            DirectedGraph graph = new DirectedGraph();

            List<int> sourceIndices = new List<int>();
            List<int> targetIndices = new List<int>();

            for (int i = 0; i < vertexLines.Count; i++)
            {
                string index1 = vertexLines[i].Split(" ")[0];
                string index2 = vertexLines[i].Split(" ")[1];

                int source = int.Parse(index1);
                int target = int.Parse(index2);

                sourceIndices.Add(source);
                targetIndices.Add(target);
            }


            int numberOfVertices = Math.Max(sourceIndices.Max(), targetIndices.Max());

            for (int i = 0; i < numberOfVertices; i++)
                graph.AddVertex();

            for (int i = 0; i < sourceIndices.Count; i++)
            {
                int source = sourceIndices[i] - 1;
                int target = targetIndices[i] - 1;

                graph.AddEdge(source, target);
            }

            return graph;
        }

        private void ConnectVertex1ToVertex2(int vertex1, int vertex2, Dictionary<int, List<int>> reversedVertexToConnectedVertexIDs)
        {
            if (reversedVertexToConnectedVertexIDs.TryGetValue(vertex1, out List<int> connectedVertices))
            {
                connectedVertices.Add(vertex2);
            }
            else
            {
                connectedVertices = new List<int>();
                reversedVertexToConnectedVertexIDs.Add(vertex1, connectedVertices);
                connectedVertices.Add(vertex2);
            }
        }


    }
}
