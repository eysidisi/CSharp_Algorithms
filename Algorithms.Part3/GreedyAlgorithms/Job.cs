using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part3.GreedyAlgorithms
{
    public class Job
    {
        public Job(int weight, int length)
        {
            Weight = weight;
            Length = length;
        }

        public int Length { get; private set; }
        public int Weight { get; private set; }
    }
}
