using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    internal static class Day_Three
    {
        
        public static void PrintSolution_Part1(string _inputPath)
        {
            if (File.Exists(_inputPath) == false) return;
            int sum = 0;

            foreach (ReadOnlySpan<char> racksack in File.ReadLines(_inputPath))
            {
                sum += GetDuplicatePriority(racksack);
            }
            Console.WriteLine($"The answer is: {sum}");

        }
        public static void PrintSolution_Part2(string _inputPath)
        {
            if (File.Exists(_inputPath) == false) return;
            int sum = 0;
            string[] lines = File.ReadAllLines(_inputPath);
            string[] t = {
                "vJrwpWtwJgWrhcsFMMfFFhFp",
                "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
                "PmmdzqPrVvPwwTWBwg",
                "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
                "ttgJtRGJQctTZtZT",
                "CrZsJsPPZsGzwwsLwLmpwMDw"
                };
            //lines = t;
            for (int i = 0; i <= lines.Length-3; i+=3)
            {
                sum += GetBadgePriority(lines[i], lines[i + 1], lines[i + 2]);
            }

            Console.WriteLine($"The answer is: {sum}");

        }
        private static int GetDuplicatePriority(ReadOnlySpan<char> _racksack)
        {
            int half = _racksack.Length / 2;
            ReadOnlySpan<char> comp1 = _racksack.Slice(0, half);
            ReadOnlySpan<char> comp2 = _racksack.Slice(half);
            for (int i = 0; i < half; i++)
            {
                for (int j = 0; j < half; j++)
                {
                    if (comp1[i] == comp2[j])
                    {
                        return GetPriority(comp1[i]);
                    }
                }
            }
            return -1;
        }
        private static int GetBadgePriority(ReadOnlySpan<char> e1, ReadOnlySpan<char> e2, ReadOnlySpan<char> e3)
        {
            for (int i = 0; i < e1.Length; i++)
            {
                if (e2.Contains(e1[i]) && e3.Contains(e1[i]))
                {
                    return GetPriority(e1[i]);
                }
            }
            return -1;
        }
        private static int GetPriority(char item)
        {
            if (item - 'a' >= 0)
            {
                return item - 'a' + 1;
            }
            else
            {
                return item - 'A' + 27;
            }
        }

    }
}
