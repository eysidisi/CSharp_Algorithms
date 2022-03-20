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

        [Theory]
        [MemberData(nameof(FindPredecessorOfElement))]
        public void FindPredecessorOfElement_GetsPredecessors(int[] elementsToAdd, int[] precedessorsToFind, int?[] precedessors)
        {
            // Arrange
            BinarySearchTree searchTree = new BinarySearchTree();

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
        public static IEnumerable<object[]> FindPredecessorOfElement =>
            new List<object[]>
            {
                    new object[] { new int[] { 7,1, 2, 3, 4, 5, 6, -1, -2, -3 }, new int[] { -1, -2, -3, 1, 2, 3, 4, 5, 6,7 }, new int?[] { -2, -3, null, -1, 1, 2, 3, 4, 5,6 }},
                    new object[] { new int[] { 4,2,6,3,5,1,7,-3,-2,-1 }, new int[] { -1, -2, -3, 1, 2, 3, 4, 5, 6 }, new int?[] { -2, -3, null, -1, 1, 2, 3, 4, 5 }}
            };

        [Theory]
        [MemberData(nameof(FindSuccessorOfElementData))]
        public void FindSuccessorOfElement_GetsPredecessors(int[] elementsToAdd, int[] successorsToFind, int?[] successors)
        {
            // Arrange
            BinarySearchTree searchTree = new BinarySearchTree();

            // Act 
            foreach (var item in elementsToAdd)
            {
                searchTree.Insert(item);
            }

            // Assert
            for (int i = 0; i < successorsToFind.Length; i++)
            {
                int successorToFind = successorsToFind[i];
                int? successor = successors[i];

                Assert.Equal(successor, searchTree.FindSuccessorOfElement(successorToFind));
            }
        }
        public static IEnumerable<object[]> FindSuccessorOfElementData =>
        new List<object[]>
        {
            new object[] { new int[] { 7,1, 2, 3, 4, 5, 6, -1, -2, -3 }, new int[] { -1, -2, -3, 1, 2, 3, 4, 5, 6,7 }, new int?[] { 1, -1, -2, 2, 3, 4, 5, 6, 7,null }},
            new object[] { new int[] { 4,2,6,3,5,1,7,-3,-2,-1 }, new int[] { -1, -2, -3, 1, 2, 3, 4, 5, 6 }, new int?[] { 1, -1, -2, 2, 3, 4, 5, 6, 7, null } }
        };

        [Theory]
        [MemberData(nameof(FindRankOfElementData))]
        public void FindRankOfElement_ReturnsRanks(int[] elementsToAdd, int[] elementsToFindRanks, int?[] ranks)
        {
            // Arrange
            BinarySearchTree searchTree = new BinarySearchTree();

            // Act 
            foreach (var item in elementsToAdd)
            {
                searchTree.Insert(item);
            }

            // Assert
            for (int i = 0; i < elementsToFindRanks.Length; i++)
            {
                int elementToFindRank = elementsToFindRanks[i];
                int? expectedRanks = ranks[i];

                Assert.Equal(expectedRanks, searchTree.FindRankOfElement(elementToFindRank));
            }
        }
        public static IEnumerable<object[]> FindRankOfElementData =>
        new List<object[]>
        {
            new object[] { new int[] { 7,1, 2, 3, 4, 5, 6, -1, -2, -3 }, new int[] { -3,-2,-1,1,2,3,4,5,6,7 }, new int?[] {1,2,3,4,5,6,7,8,9,10  }},
            new object[] { new int[] { 4,2,6,3,5,1,7,-3,-2,-1 }, new int[] { -3, -2, -1, 1, 2, 3, 4, 5, 6, 7 }, new int?[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } }
        };

        [Theory]
        [MemberData(nameof(OutputSortedData))]
        public void OutputSorted_ReturnsSortedOutput(int[] elementsToAdd, List<int> expectedSortedElements)
        {
            // Arrange
            BinarySearchTree searchTree = new BinarySearchTree();

            // Act 
            foreach (var item in elementsToAdd)
            {
                searchTree.Insert(item);
            }
            var actualSortedElements = searchTree.OutputSorted();

            // Assert
            Assert.Equal(expectedSortedElements, actualSortedElements);
        }
        public static IEnumerable<object[]> OutputSortedData =>
        new List<object[]>
        {
            new object[] { new int[] { 7,1, 2, 3, 4, 5, 6, -1, -2, -3 }, new List<int>() { -3,-2,-1,1,2,3,4,5,6,7 }},
            new object[] { new int[] { 4,2,6,3,5,1,7,-3,-2,-1 }, new List<int>() { -3, -2, -1, 1, 2, 3, 4, 5, 6, 7 }}
        };
    }
}
