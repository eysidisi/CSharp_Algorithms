using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part3.DynamicProgramming.Knapsack
{
    public class KnapsackAlgorithm
    {
        private Item[] items;
        long[,] numberOfItemsAndSizesToTotalWeight;
        public KnapsackAlgorithm(Item[] items)
        {
            this.items = items;
        }

        public long CalculateMaxWeight(int maxKnapsackSize)
        {
            numberOfItemsAndSizesToTotalWeight = new long[items.Length + 1, maxKnapsackSize + 1];
            ImplementBaseCaseForTheArray();

            for (int knapsackSize = 0; knapsackSize <= maxKnapsackSize; knapsackSize++)
            {
                for (int numberOfItems = 1; numberOfItems <= items.Length; numberOfItems++)
                {
                    Item currentItem = items[numberOfItems - 1];
                    long totalMaxWeightForGivenValues;

                    if (currentItem.Value > knapsackSize)
                    {
                        totalMaxWeightForGivenValues = numberOfItemsAndSizesToTotalWeight[numberOfItems - 1, knapsackSize];
                    }

                    else
                    {
                        totalMaxWeightForGivenValues = Math.Max(numberOfItemsAndSizesToTotalWeight[numberOfItems - 1, knapsackSize],
                                                               numberOfItemsAndSizesToTotalWeight[numberOfItems - 1, knapsackSize - currentItem.Value] + currentItem.Weight);
                    }

                    numberOfItemsAndSizesToTotalWeight[numberOfItems, knapsackSize] = totalMaxWeightForGivenValues;
                }
            }

            return numberOfItemsAndSizesToTotalWeight[items.Length, maxKnapsackSize];
        }

        private void ImplementBaseCaseForTheArray()
        {
            for (int i = 0; i < numberOfItemsAndSizesToTotalWeight.GetLength(1); i++)
            {
                numberOfItemsAndSizesToTotalWeight[0, i] = 0;
            }
        }

        
    }
}
