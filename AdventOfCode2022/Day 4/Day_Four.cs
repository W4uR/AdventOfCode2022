using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    internal static class Day_Four
    {
        public static void PrintSolution_Part1(string _inputPath)
        {
            if (File.Exists(_inputPath) == false) return;
            int conatinment = 0;
            foreach (ReadOnlySpan<char> pair in File.ReadLines(_inputPath))
            {
                conatinment += IsFullyContained(pair) ? 1:0;
            }
            Console.WriteLine($"The answer is: {conatinment}");
        }
        public static void PrintSolution_Part2(string _inputPath)
        {
            if (File.Exists(_inputPath) == false) return;
            int overlap = 0;
            foreach (ReadOnlySpan<char> pair in File.ReadLines(_inputPath))
            {
                overlap += HasOverlap(pair) ? 1 : 0;
            }
            Console.WriteLine($"The answer is: {overlap}");
        }

        private static bool IsFullyContained(ReadOnlySpan<char> pair)
        {
            var edges = ParsePair(pair);

            return (edges.min1 <= edges.min2 && edges.max1 >= edges.max2) || 
                (edges.min2 <= edges.min1 && edges.max2 >= edges.max1);
        }

        private static bool HasOverlap(ReadOnlySpan<char> pair)
        {
            var edges = ParsePair(pair);

            return (edges.min1 <= edges.min2 && edges.min2 <= edges.max1) ||
                (edges.min2 <= edges.min1 && edges.min1 <= edges.max2);
        }

        private static (int min1,int max1,int min2,int max2) ParsePair(ReadOnlySpan<char> pair)
        {
            int index = pair.IndexOf(',');
            var e1 = pair.Slice(0, index);
            var e2 = pair.Slice(index+1);
            index = e1.IndexOf('-');
            var e1_min = int.Parse(e1.Slice(0, index));
            var e1_max = int.Parse(e1.Slice(index + 1));
            index = e2.IndexOf('-');
            var e2_min = int.Parse(e2.Slice(0, index));
            var e2_max = int.Parse(e2.Slice(index + 1));
            return (e1_min, e1_max, e2_min, e2_max);
        }
    }
}
