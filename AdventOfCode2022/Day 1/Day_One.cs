using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace AdventOfCode2022
{
    internal static class Day_One
    {
        private const string INPUT_FILE = "../../../Day 1/input.txt";
        public static void PrintSolution_Part1()
        {
            if (File.Exists(INPUT_FILE) == false) return;
            
            StreamReader sr = new StreamReader(INPUT_FILE);
            string? line;
            int sum = 0;
            int max = int.MinValue;
            while (sr.EndOfStream == false)
            {
                line = sr.ReadLine();
                if (String.IsNullOrEmpty(line))
                {
                    if (sum > max)
                    {
                        max = sum;
                    }
                    sum = 0;
                }else if(int.TryParse(line, out int calorie))
                {
                    sum += calorie;
                }
            }
            sr.Close();
            Console.WriteLine($"The answer is: {max}");
        }

        public static void PrintSolution_Part2()
        {
            List<int> elfCalories = new();

            if (File.Exists(INPUT_FILE) == false) return;

            StreamReader sr = new StreamReader(INPUT_FILE);
            string? line;
            int sum = 0;
            while (sr.EndOfStream == false)
            {
                line = sr.ReadLine();
                if (String.IsNullOrEmpty(line))
                {
                    elfCalories.Add(sum);
                    sum = 0;
                }
                else if (int.TryParse(line, out int calorie))
                {
                    sum += calorie;
                }
            }
            sr.Close();

            elfCalories = elfCalories.OrderByDescending(x => x).ToList();
            int answer = 0;
            for (int i = 0; i < 3; i++)
            {
                answer += elfCalories[i];
            }

            Console.WriteLine($"The answer is: {answer}");

        }
    }
}
