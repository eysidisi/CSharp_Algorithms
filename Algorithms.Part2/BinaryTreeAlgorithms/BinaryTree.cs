using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part2.BinaryTreeAlgorithms
{
    public abstract class BinaryTree
    {
        protected Node rootNode = null;

        public abstract void Insert(int element);
        public abstract bool Search(int element);
        public abstract int Min();
        public abstract int Max();
        public abstract int? FindPredecessorOfElement(int element);
        public abstract int? FindSuccessorOfElement(int element);
        public abstract int? FindRankOfElement(int element);
        public abstract List<int> OutputSorted();
    }
}
