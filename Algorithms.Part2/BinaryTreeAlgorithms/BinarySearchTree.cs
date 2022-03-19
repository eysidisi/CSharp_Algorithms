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
            throw new NotImplementedException();

            Node nodeWithGivenElement = FindNodeWithGivenData(element);

            if (nodeWithGivenElement == null)
            {
                return null;
            }

            Node predecessorNode = FindNodeWithGivenRank(nodeWithGivenElement.NumOfTotalChildren - 1);

            if (predecessorNode == null)
            {
                return null;
            }

            return predecessorNode.data;
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

                else if (element > rootNode.data)
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

        private Node FindNodeWithGivenRank(int rank)
        {
            Node currentNode = rootNode;

            while (currentNode != null)
            {
                if (rank == currentNode.NumOfTotalChildren)
                {
                    return currentNode;
                }

                else if (rank > currentNode.NumOfTotalChildren)
                {
                    currentNode = currentNode.rChild;
                }

                else
                {
                    currentNode = currentNode.lChild;
                }
            }

            return currentNode;
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
                currentNode.NumOfTotalChildren++;

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
    }
}
