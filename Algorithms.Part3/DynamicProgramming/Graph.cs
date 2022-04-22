using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part3.DynamicProgramming
{
    public class Graph
    {
        public IReadOnlyCollection<int> UsedNodeIds => usedNodeIds;

        int[] nodes;
        long[] results;
        List<int> usedNodeIds = new List<int>();

        public Graph(int[] nodes)
        {
            this.nodes = nodes;
        }

        public Graph(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            int numberOfNodes = int.Parse(lines[0]);

            nodes = new int[numberOfNodes];

            for (int i = 1; i < lines.Length; i++)
            {
                int weigth = int.Parse(lines[i]);
                nodes[i - 1] = weigth;
            }
        }

        public long CalculateMaximumWeightedIndependentSet()
        {
            results = new long[nodes.Length + 1];
            results[0] = 0;
            results[1] = nodes[0];

            long result = CalculateMaximumWeightedIndependentSet(2);

            CalculateUsedNodeIDs();

            return result;
        }

        private void CalculateUsedNodeIDs()
        {
            int nodeIndex = nodes.Length - 1;

            while (nodeIndex >= 1)
            {
                if (nodes[nodeIndex] + results[nodeIndex - 1] > results[nodeIndex])
                {
                    usedNodeIds.Add(nodeIndex);
                    nodeIndex -= 2;
                }
                else
                {
                    nodeIndex--;
                }
            }

            if (nodeIndex == 0)
            {
                usedNodeIds.Add(nodeIndex);
            }
        }

        private long CalculateMaximumWeightedIndependentSet(int nodeNumberToCalculate)
        {
            if (nodeNumberToCalculate == nodes.Length)
            {
                long withLastNode = results[nodeNumberToCalculate - 2] + nodes[nodeNumberToCalculate - 1];
                long withOutLastNode = results[nodeNumberToCalculate - 1];
                return Math.Max(withLastNode, withOutLastNode);
            }

            else
            {
                long withThisNode = results[nodeNumberToCalculate - 2] + nodes[nodeNumberToCalculate - 1];
                long withOutThisNode = results[nodeNumberToCalculate - 1];
                results[nodeNumberToCalculate] = withThisNode > withOutThisNode ? withThisNode : withOutThisNode;
                return CalculateMaximumWeightedIndependentSet(nodeNumberToCalculate + 1);
            }
        }
    }
}
