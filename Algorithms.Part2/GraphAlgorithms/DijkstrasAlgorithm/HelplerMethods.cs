using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part2.GraphAlgorithms.DijkstrasAlgorithm
{
    public class HelplerMethods
    {
        public UndirectedGraph ReadFile(string path)
        {
            List<string> lines = File.ReadAllLines(path).ToList();

            int numberOfVertices = lines.Count;

            UndirectedGraph graph = new UndirectedGraph(numberOfVertices);

            for (int i = 0; i < lines.Count; i++)
            {
                string line = lines[i];
                List<string> pairs = line.Split("\t", StringSplitOptions.RemoveEmptyEntries).ToList();
                pairs.RemoveAt(0);

                foreach (string pair in pairs)
                {
                    string[] splittedPair = pair.Split(',');

                    int destIndex = int.Parse(splittedPair[0]) - 1;
                    int weight = int.Parse(splittedPair[1]);

                    graph.AddEdge(i, destIndex, weight);
                }
            }

            return graph;
        }
    }
}
