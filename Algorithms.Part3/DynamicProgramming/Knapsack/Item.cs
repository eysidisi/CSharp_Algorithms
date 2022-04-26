using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part3.DynamicProgramming.Knapsack
{
    public class Item
    {
        public int Value { get; private set; }
        public int Weight { get; private set; }
        public Item(int value, int weight)
        {
            Value = value;
            Weight = weight;
        }
    }
}
