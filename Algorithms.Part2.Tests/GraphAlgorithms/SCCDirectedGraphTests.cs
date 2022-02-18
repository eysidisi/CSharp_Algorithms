using Algorithms.Part2.GraphAlgorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Part2.Tests.GraphAlgorithms
{
    public class SCCDirectedGraphTests
    {

        //0->1->2
        [Fact]
        public void ConnectVertex1ToVertex2_CreatesStraightGraph()
        {
            // Arrange
            SCCDirectedGraph sCCDirectedGraph = new SCCDirectedGraph(3);
            List<List<int>> expectedVertices = new List<List<int>>();
            for (int i = 0; i < 3; i++)
            {
                expectedVertices.Add(new List<int>());
            }
            expectedVertices[0].Add(1);
            expectedVertices[1].Add(2);

            // Act
            sCCDirectedGraph.ConnectVertex1ToVertex2(0, 1);
            sCCDirectedGraph.ConnectVertex1ToVertex2(1, 2);

            // Assert
            Assert.Equal(expectedVertices, sCCDirectedGraph.indexIDsToIndexIDs);
        }

        [Fact]
        public void FindStronglyConnectedComponents_Coursera_ReturnsSCC()
        {
            // Arrange
            SCCDirectedGraphHelperMethods helper = new SCCDirectedGraphHelperMethods();
            string inputfilePath = Directory.GetCurrentDirectory() + @"\GraphAlgorithms\InputFiles\CourseraAssignmentInput.txt";

            SCCDirectedGraph graph = helper.ReadInputFile(inputfilePath);

            // Act
            List<List<int>> actualSCC = graph.FindStronglyConnectedComponents();

            actualSCC.Sort((l1, l2) => l1.Count().CompareTo(l2.Count));

            Console.WriteLine("asda");
        }

        // 0->1->2
        [Fact]
        public void FindStronglyConnectedComponents_ReturnsSCC()
        {
            // Arrange
            SCCDirectedGraph graph = new SCCDirectedGraph(3);

            graph.ConnectVertex1ToVertex2(0, 1);
            graph.ConnectVertex1ToVertex2(1, 2);

            List<List<int>> expectedSccs = new List<List<int>>();
            expectedSccs.Add(new List<int>()
            {
                0
            });
            expectedSccs.Add(new List<int>()
            {
                1
            });
            expectedSccs.Add(new List<int>()
            {
                2
            });

            // Act
            var actualSccs = graph.FindStronglyConnectedComponents();

            // Assert
            foreach (var scc in actualSccs)
            {
                Assert.Contains(scc, expectedSccs);
            }
        }


        // 0->1->2
        //     <-
        [Fact]
        public void FindStronglyConnectedComponents_TwoWay_ReturnsSCC()
        {
            // Arrange
            SCCDirectedGraph graph = new SCCDirectedGraph(3);

            graph.ConnectVertex1ToVertex2(0, 1);
            graph.ConnectVertex1ToVertex2(1, 2);
            graph.ConnectVertex1ToVertex2(2, 1);

            List<List<int>> expectedSccs = new List<List<int>>();
            expectedSccs.Add(new List<int>()
            {
                0
            });
            expectedSccs.Add(new List<int>()
            {
                1,2
            });

            // Act
            var actualSccs = graph.FindStronglyConnectedComponents();

            // Assert
            foreach (var scc in actualSccs)
            {
                Assert.Contains(scc, expectedSccs);
            }
        }

        [Fact]
        public void FindStronglyConnectedComponents_Complex_ReturnsSCC()
        {
            // Arrange
            SCCDirectedGraph graph = new SCCDirectedGraph(11);

            graph.ConnectVertex1ToVertex2(0, 1);
            graph.ConnectVertex1ToVertex2(1, 10);
            graph.ConnectVertex1ToVertex2(1, 2);

            graph.ConnectVertex1ToVertex2(2, 3);
            graph.ConnectVertex1ToVertex2(2, 4);
            graph.ConnectVertex1ToVertex2(3, 5);

            graph.ConnectVertex1ToVertex2(4, 3);
            graph.ConnectVertex1ToVertex2(5, 4);
            graph.ConnectVertex1ToVertex2(6, 4);

            graph.ConnectVertex1ToVertex2(6, 7);
            graph.ConnectVertex1ToVertex2(6, 8);
            graph.ConnectVertex1ToVertex2(7, 8);

            graph.ConnectVertex1ToVertex2(7, 5);
            graph.ConnectVertex1ToVertex2(8, 9);
            graph.ConnectVertex1ToVertex2(9, 6);

            graph.ConnectVertex1ToVertex2(10, 9);
            graph.ConnectVertex1ToVertex2(10, 6);
            graph.ConnectVertex1ToVertex2(10, 0);

            List<List<int>> expectedSccs = new List<List<int>>();
            expectedSccs.Add(new List<int>()
            {
                0,1,10
            });
            expectedSccs.Add(new List<int>()
            {
                2
            });
            expectedSccs.Add(new List<int>()
            {
                3,4,5
            });

            expectedSccs.Add(new List<int>()
            {
                6,7,8,9
            });


            // Act
            var actualSccs = graph.FindStronglyConnectedComponents();

            // Assert
            foreach (List<int> scc in actualSccs)
            {
                scc.Sort();
                Assert.Contains(scc, expectedSccs);
            }
        }

        [Fact]
        public void FindStronglyConnectedComponents_Complex2_ReturnsSCC()
        {
            // Arrange
            SCCDirectedGraph graph = new SCCDirectedGraph(9);

            graph.ConnectVertex1ToVertex2(0, 1);
            graph.ConnectVertex1ToVertex2(0, 2);

            graph.ConnectVertex1ToVertex2(1, 0);
            graph.ConnectVertex1ToVertex2(1, 3);

            graph.ConnectVertex1ToVertex2(2, 0);
            graph.ConnectVertex1ToVertex2(2, 3);

            graph.ConnectVertex1ToVertex2(3, 4);

            graph.ConnectVertex1ToVertex2(4, 3);

            graph.ConnectVertex1ToVertex2(5, 1);
            graph.ConnectVertex1ToVertex2(5, 4);
            graph.ConnectVertex1ToVertex2(5, 6);

            graph.ConnectVertex1ToVertex2(6, 4);
            graph.ConnectVertex1ToVertex2(6, 7);

            graph.ConnectVertex1ToVertex2(7, 5);

            graph.ConnectVertex1ToVertex2(8, 6);
            graph.ConnectVertex1ToVertex2(8, 7);
            graph.ConnectVertex1ToVertex2(8, 8);


            List<List<int>> expectedSccs = new List<List<int>>();
            expectedSccs.Add(new List<int>()
            {
                0,1,2
            });
            expectedSccs.Add(new List<int>()
            {
                3,4
            });
            expectedSccs.Add(new List<int>()
            {
                5,6,7
            });

            expectedSccs.Add(new List<int>()
            {
                8
            });


            // Act
            var actualSccs = graph.FindStronglyConnectedComponents();

            // Assert
            foreach (List<int> scc in actualSccs)
            {
                scc.Sort();
                Assert.Contains(scc, expectedSccs);
            }
        }
    }
}
