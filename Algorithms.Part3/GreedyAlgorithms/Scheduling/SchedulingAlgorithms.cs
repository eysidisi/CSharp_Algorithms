using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Part3.GreedyAlgorithms
{
    public class SchedulingAlgorithms
    {
        public long CalculateWeightedSumUsingDifference(Job[] jobs)
        {

            Job[] sortedJobs = jobs.OrderByDescending(j => (j.Weight - j.Length)).ThenByDescending(j => j.Weight).ToArray();

            long weightedSum = 0;

            long totalTimePassed = 0;
            for (int i = 0; i < sortedJobs.Length; i++)
            {
                Job currentJob = sortedJobs[i];
                totalTimePassed += currentJob.Length;
                weightedSum += currentJob.Weight * totalTimePassed;
            }
            return weightedSum;
        }
        public long CalculateWeightedSumUsingRatio(Job[] jobs)
        {

            Job[] sortedJobs = jobs.OrderByDescending(j => ((double)j.Weight) / j.Length).ToArray();

            long weightedSum = 0;

            long totalTimePassed = 0;
            for (int i = 0; i < sortedJobs.Length; i++)
            {
                Job currentJob = sortedJobs[i];
                totalTimePassed += currentJob.Length;
                weightedSum += currentJob.Weight * totalTimePassed;
            }
            return weightedSum;
        }

        public Job[] ReadFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath).ToList();
            lines.RemoveAt(0);

            List<Job> jobs = new List<Job>();

            foreach (var line in lines)
            {
                var weightAndLength = line.Split(' ');
                string weight = weightAndLength[0];
                string length = weightAndLength[1];
                Job job = new Job(int.Parse(weight), int.Parse(length));
                jobs.Add(job);
            }

            return jobs.ToArray();
        }
    }
}
