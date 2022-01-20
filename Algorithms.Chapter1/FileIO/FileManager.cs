using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part1.FileIO
{
    public class FileManager
    {
        public int[] ReadFileIntoIntArray(string path)
        {
            var readString = File.ReadAllLines(path);

            var output = new int[readString.Length];

            for (int i = 0; i < readString.Length; i++)
            {
                output[i] = Convert.ToInt32(readString[i]);
            }

            return output;
        }
    }
}
