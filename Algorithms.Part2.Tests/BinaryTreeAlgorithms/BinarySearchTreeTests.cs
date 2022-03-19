using Algorithms.Part2.BinaryTreeAlgorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Part2.Tests.BinaryTreeAlgorithms
{
    public class BinarySearchTreeTests
    {
        [Fact]
        public void InsertSearch_ReturnsTrueIfElementExists()
        {
            // Arrange
            BinarySearchTree searchTree = new BinarySearchTree();
            int[] elementsToAdd = new int[] { 1, 2, 3, 4, 5 };
            int[] elementsToSearchFor = new int[] { 1, 2, 0, 4, 5, 10, -1 };
            bool[] expectedResults = new bool[] { true, true, false, true, true, false, false };

            // Act 
            foreach (var item in elementsToAdd)
            {
                searchTree.Insert(item);
            }

            // Assert
            for (int i = 0; i < expectedResults.Length; i++)
            {
                int elementToSearchFor = elementsToSearchFor[i];
                bool expectedResult = expectedResults[i];
                bool actualResult = searchTree.Search(elementToSearchFor);
                Assert.Equal(expectedResult, actualResult);
            }
        }

        [Fact]
        public void MinMax_ReturnsMinMax()
        {
            // Arrange
            BinarySearchTree searchTree = new BinarySearchTree();
            int[] elementsToAdd = new int[] { 1, 2, -2, 3, 20, 4, 5, -13, 10 };

            // Act 
            List<int> addedElements = new List<int>();
            foreach (var item in elementsToAdd)
            {
                addedElements.Add(item);
                searchTree.Insert(item);
                int min = addedElements.Min();
                int max = addedElements.Max();

                Assert.Equal(min, searchTree.Min());
                Assert.Equal(max, searchTree.Max());
            }
        }

        [Fact]
        public void Predecessor_GetsPredecessors()
        {
            // Arrange
            BinarySearchTree searchTree = new BinarySearchTree();
            int[] elementsToAdd = new int[] { 1, 2, 3, 4, 5, 6, -1, -2, -3 };
            int[] precedessorsToFind = new int[] { -1, -2, -3, 1, 2, 3, 4, 5, 6 };
            int?[] precedessors = new int?[] { -2, -3, null, -1, 1, 2, 3, 4, 5 };

            // Act 
            foreach (var item in elementsToAdd)
            {
                searchTree.Insert(item);
            }

            // Assert
            for (int i = 0; i < precedessorsToFind.Length; i++)
            {
                int precedessorToFind = precedessorsToFind[i];
                int? precedessor = precedessors[i];

                Assert.Equal(precedessor, searchTree.FindPredecessorOfElement(precedessorToFind));
            }
        }
    }
}
