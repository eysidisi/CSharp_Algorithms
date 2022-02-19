using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part2.GraphAlgorithms.TarjansAlgorithm
{
    public class HelperMethods
    {
        public DirectedGraph ReadInputFile(string filePath)
        {
            List<string> vertexLines = File.ReadAllLines(filePath).ToList();

            List<int> sourceIndices = new List<int>();
            List<int> targetIndices = new List<int>();

            for (int i = 0; i < vertexLines.Count; i++)
            {
                string[] splittedLine = vertexLines[i].Split(" ");

                string index1 = splittedLine[0];
                string index2 = splittedLine[1];

                int source = int.Parse(index1) - 1;
                int target = int.Parse(index2) - 1;

                sourceIndices.Add(source);
                targetIndices.Add(target);
            }

            int numberOfVertices = Math.Max(sourceIndices.Max(), targetIndices.Max());

            DirectedGraph graph = new DirectedGraph(numberOfVertices + 1);

            for (int i = 0; i < sourceIndices.Count; i++)
            {
                int source = sourceIndices[i];
                int target = targetIndices[i];

                graph.ConnectVertex1ToVertex2(source, target);
            }
            return graph;
        }

        public List<List<int>> ReverseEdges(List<List<int>> edges)
        {
            List<List<int>> reversedEdges = new List<List<int>>(edges.Count);
            for (int i = 0; i < edges.Count; i++)
            {
                reversedEdges.Add(new List<int>());
            }

            for (int vertexIndex = 0; vertexIndex < edges.Count; vertexIndex++)
            {
                var connectedVertexIndices = edges[vertexIndex];

                foreach (var connectedVertexIndex in connectedVertexIndices)
                {
                    reversedEdges[connectedVertexIndex].Add(vertexIndex);
                }
            }

            return reversedEdges;
        }
    }
}
