using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part2.BinaryTreeAlgorithms
{
    public class BinarySearchTree : BinaryTree
    {
        public override void Insert(int element)
        {
            if (rootNode == null)
            {
                rootNode = new Node();
                rootNode.data = element;
            }

            else
            {
                Node parent = FindParentNodeToAdd(element);
                Node childNode = AddChildNodeToParent(element, parent);
                childNode.parent = parent;
                IncreaseRanksUntilNode(childNode);
            }
        }

        public override int Max()
        {
            Node temp = rootNode;

            while (temp.rChild != null)
            {
                temp = temp.rChild;
            }

            return temp.data;
        }

        public override int Min()
        {
            Node temp = rootNode;

            while (temp.lChild != null)
            {
                temp = temp.lChild;
            }

            return temp.data;
        }

        public override int? FindPredecessorOfElement(int element)
        {
            Node nodeWithGivenElement = FindNodeWithGivenData(element);

            if (nodeWithGivenElement == null)
            {
                return null;
            }

            else if (nodeWithGivenElement.lChild != null)
            {
                return FindMaxNodeInSubTree(nodeWithGivenElement.lChild).data;
            }

            else
            {
                Node parent = nodeWithGivenElement.parent;

                while (parent != null)
                {
                    if (parent.data < element)
                    {
                        return parent.data;
                    }
                    parent = parent.parent;
                }

                return null;
            }
        }

        public override int? FindSuccessorOfElement(int element)
        {
            Node nodeWithGivenElement = FindNodeWithGivenData(element);

            if (nodeWithGivenElement == null)
            {
                return null;
            }

            else if (nodeWithGivenElement.rChild != null)
            {
                return FindMinNodeInSubTree(nodeWithGivenElement.rChild).data;
            }

            else
            {
                Node parent = nodeWithGivenElement.parent;

                while (parent != null)
                {
                    if (parent.data > element)
                    {
                        return parent.data;
                    }
                    parent = parent.parent;
                }

                return null;
            }
        }

        public override bool Search(int element)
        {
            Node node = FindNodeWithGivenData(element);

            if (node == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override int? FindRankOfElement(int element)
        {
            int numberOfElementsSmallerThanGivenElement = 0;
            Node node = FindNodeWithGivenData(element);

            if (node.lChild != null)
            {
                numberOfElementsSmallerThanGivenElement += (node.lChild.size + 1);
            }

            Node parent = node.parent;

            while (parent != null)
            {
                if (parent.rChild == node)
                {
                    int numberOfSmallerElements = parent.lChild != null ? parent.lChild.size + 2 : 1;
                    numberOfElementsSmallerThanGivenElement += numberOfSmallerElements;
                }
                node = parent;
                parent = parent.parent;
            }

            return numberOfElementsSmallerThanGivenElement + 1;
        }

        public override List<int> OutputSorted()
        {
            return GetOutputSorted(rootNode);
        }

        private List<int> GetOutputSorted(Node node)
        {
            List<int> sortedOutput = new List<int>();

            if (node.lChild != null)
            {
                sortedOutput.AddRange(GetOutputSorted(node.lChild));
            }

            sortedOutput.Add(node.data);

            if (node.rChild != null)
            {
                sortedOutput.AddRange(GetOutputSorted(node.rChild));
            }

            return sortedOutput;
        }

        private Node FindNodeWithGivenData(int element)
        {
            Node temp = rootNode;

            while (true)
            {
                if (temp == null)
                    return null;

                if (temp.data == element)
                {
                    return temp;
                }

                else if (element > temp.data)
                {
                    temp = temp.rChild;
                }

                else
                {
                    temp = temp.lChild;
                }
            }
        }

        private Node FindParentNodeToAdd(int element)
        {
            Node temp = rootNode;
            Node parent = temp;

            while (temp != null)
            {
                parent = temp;

                if (parent.data == element)
                {
                    throw new ArgumentException("Elements need to be unique");
                }

                if (element < temp.data)
                {
                    temp = temp.lChild;
                }

                else
                {
                    temp = temp.rChild;
                }
            }

            return parent;
        }

        private Node AddChildNodeToParent(int element, Node parent)
        {
            Node newNode = new Node();

            newNode.data = element;

            if (element == parent.data)
            {
                throw new ArgumentException("Elements need to be unique");
            }

            if (element < parent.data)
            {
                parent.lChild = newNode;
            }

            else
            {
                parent.rChild = newNode;
            }

            return newNode;
        }

        private void IncreaseRanksUntilNode(Node node)
        {
            Node currentNode = rootNode;

            while (currentNode != node)
            {
                currentNode.size++;

                if (node.data > currentNode.data)
                {
                    currentNode = currentNode.rChild;
                }

                else
                {
                    currentNode = currentNode.lChild;
                }
            }
        }

        private Node FindMaxNodeInSubTree(Node node)
        {
            while (node.rChild != null)
            {
                node = node.rChild;
            }

            return node;
        }

        private Node FindMinNodeInSubTree(Node node)
        {
            while (node.lChild != null)
            {
                node = node.lChild;
            }

            return node;
        }
    }
}
