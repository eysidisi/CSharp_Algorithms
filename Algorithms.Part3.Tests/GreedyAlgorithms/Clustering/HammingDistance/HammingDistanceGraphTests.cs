using Algorithms.Part3.GreedyAlgorithms.Clustering.HammingDistance;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms.Part3.Tests.GreedyAlgorithms.Clustering.HammingDistance
{
    public class HammingDistanceGraphTests
    {
        [Fact(Skip ="Takes forever")]
        public void CourseraAssignment()
        {
            HammingDistanceGraph hammingDistanceGraph = new HammingDistanceGraph();
            string path = Directory.GetCurrentDirectory() + @"\GreedyAlgorithms\Clustering\HammingDistance\InputFiles\hammingDistances.txt";
            int clusters = hammingDistanceGraph.GetNumberOfClusters(path);
            Assert.Equal(1, clusters);
        }
    }
}
