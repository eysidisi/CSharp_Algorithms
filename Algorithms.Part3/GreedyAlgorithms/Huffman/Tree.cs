namespace Algorithms.Part3.GreedyAlgorithms.Huffman
{
    internal class Tree
    {
        public long Weight { get; internal set; }
        public int Height { get; internal set; }
        public int MinDepth { get; internal set; }

        public Tree(long treeWeight)
        {
            Weight = treeWeight;
            Height = 0;
            MinDepth = 0;
        }

        internal static Tree MergeTrees(Tree tree1, Tree tree2)
        {
            long newTreeWeight = tree1.Weight + tree2.Weight;
            Tree newTree = new Tree(newTreeWeight);
                
            int newTreeHeight = Math.Max(tree1.Height, tree2.Height) + 1;
            int newTreeMinDepth = Math.Min(tree1.MinDepth, tree2.MinDepth) + 1;
            
            newTree.Height = newTreeHeight;
            newTree.MinDepth = newTreeMinDepth;

            return newTree;
        }
    }
}