using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part2.HashTableAlgorithms
{
    public class TwoSumsProblem
    {
        Dictionary<long, int> arrElementsToFrequency = new Dictionary<long, int>();
        long[] arr;
        public TwoSumsProblem(int[] arr)
        {
            this.arr = new long[arr.Length];
            Array.Copy(arr, this.arr, arr.Length);
            
            AddArrayElementsToTheDictionary();
            Array.Sort(this.arr);
        }

        public TwoSumsProblem(string inputFolderPath)
        {
            ReadFile(inputFolderPath);
            Array.Sort(arr);
            AddArrayElementsToTheDictionary();
        }

        private void ReadFile(string inputFolderPath)
        {
            string[] lines = File.ReadAllLines(inputFolderPath);

            arr = new long[lines.Length];

            int index = 0;

            foreach (string line in lines)
            {
                arr[index] = long.Parse(line);
                index++;
            }
        }

        public bool CheckIfSumExists(long sum)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                long num1 = arr[i];

                if (num1 > sum) return false;

                long requiredNum = sum - num1;

                if (requiredNum == num1)
                {
                    if (arrElementsToFrequency.TryGetValue(requiredNum, out int freq))
                    {
                        if (freq >= 2)
                        {
                            return true;
                        }
                    }
                }

                else
                {
                    if (arrElementsToFrequency.TryGetValue(requiredNum, out int _))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void AddArrayElementsToTheDictionary()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                long element = arr[i];

                if (arrElementsToFrequency.ContainsKey(element))
                {
                    arrElementsToFrequency[element]++;
                }
                else
                {
                    arrElementsToFrequency.Add(element, 1);
                }
            }
        }
    }
}
