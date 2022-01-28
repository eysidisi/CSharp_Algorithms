using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part1.Graph
{
    public class KargersAlgorithm
    {

        public int FindMinNumberOfEdges(GraphRepresentation graph)
        {
            int n = graph.Vertices.Count;

            // n^2 * ln(n)
            int numOfRunningTimes = (int)(Math.Pow(n, 2) * Math.Ceiling(Math.Log(n)));

            return FindMinNumberOfEdgesParallelFor(graph, numOfRunningTimes);
        }

        static object MinNumberOfEdgesSynccObj = new object();
        public int FindMinNumberOfEdgesParallelFor(GraphRepresentation graph, int numOfRuningTimes)
        {
            int minNumberOfEdges = int.MaxValue;

            Parallel.For(0, numOfRuningTimes, i =>
            {
                GraphRepresentation copyGraph = new GraphRepresentation(graph);

                while (copyGraph.Vertices.Count != 2)
                {
                    int randomEdgeId = copyGraph.SelectRandomEdgeId();
                    copyGraph.ContractEdge(randomEdgeId);
                }

                int numberOfRemainingEdges = copyGraph.Edges.Count;

                lock (MinNumberOfEdgesSynccObj)
                {
                    if (numberOfRemainingEdges < minNumberOfEdges)
                    {
                        minNumberOfEdges = numberOfRemainingEdges;
                    }
                }
            });

            return minNumberOfEdges;
        }

        public int FindMinNumberOfEdges(GraphRepresentation graph, int numOfRuningTimes)
        {
            int minNumberOfEdges = int.MaxValue;

            for (int i = 0; i < numOfRuningTimes; i++)
            {
                GraphRepresentation copyGraph = new GraphRepresentation(graph);

                while (copyGraph.Vertices.Count != 2)
                {
                    int randomEdgeId = copyGraph.SelectRandomEdgeId();
                    copyGraph.ContractEdge(randomEdgeId);
                }

                int numberOfRemainingEdges = copyGraph.Edges.Count;

                if (numberOfRemainingEdges < minNumberOfEdges)
                {
                    minNumberOfEdges = numberOfRemainingEdges;
                }
            }

            return minNumberOfEdges;
        }
    }
}
