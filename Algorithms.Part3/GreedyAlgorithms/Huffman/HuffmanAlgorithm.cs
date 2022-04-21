using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;
namespace Algorithms.Part3.GreedyAlgorithms.Huffman
{
    public class HuffmanAlgorithm
    {
        private int[] symbolWeights;
        private PriorityQueue<Tree, long> treeHeap = new PriorityQueue<Tree, long>();

        public HuffmanAlgorithm(int[] symbolWeights)
        {
            this.symbolWeights = symbolWeights;
        }

        public HuffmanAlgorithm(string filePath)
        {
            ReadSymbolsFromFile(filePath);
        }

        private void ReadSymbolsFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int numberOfSymbols = int.Parse(lines[0]);
            symbolWeights = new int[numberOfSymbols];

            int lineIndex = 1;
            for (int symbolIndex = 0; symbolIndex < numberOfSymbols; symbolIndex++)
            {
                string weightLine = lines[lineIndex];
                lineIndex++;
                int weigth = int.Parse(weightLine);
                symbolWeights[symbolIndex] = weigth;
            }
        }

        public int CalculateMinLengthOfCodeword()
        {
            RunHuffmanAlgorithm();
            Tree resultantTree = treeHeap.Dequeue();
            return resultantTree.MinDepth;
        }

        public int CalculateMaxLengthOfCodeword()
        {
            RunHuffmanAlgorithm();
            Tree resultantTree = treeHeap.Dequeue();
            return resultantTree.Height;
        }

        private void RunHuffmanAlgorithm()
        {
            FillTreeHeap();

            while (treeHeap.Count > 1)
            {
                Tree mergedTree = MergeTwoTreesWithMinimumWeights();
                treeHeap.Enqueue(mergedTree, mergedTree.Weight);
            }
        }

        private void FillTreeHeap()
        {
            for (int index = 0; index < symbolWeights.Length; index++)
            {
                int treeWeight = symbolWeights[index];
                Tree newTree = new Tree(treeWeight);
                treeHeap.Enqueue(newTree, newTree.Weight);
            }
        }

        private Tree MergeTwoTreesWithMinimumWeights()
        {
            Tree minTree1 = treeHeap.Dequeue();
            Tree minTree2 = treeHeap.Dequeue();
            Tree mergedTree = Tree.MergeTrees(minTree1, minTree2);
            return mergedTree;
        }
    }
}
