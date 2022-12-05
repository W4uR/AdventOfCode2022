using AdventOfCode2022.Day_5;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    internal static class Day_Five
    {
        public static void PrintSolution_Part1(string _inputPath)
        {
            if (File.Exists(_inputPath) == false) return;
            string[] input = File.ReadAllLines(_inputPath);

            
            int w = 0, h = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Contains('1'))
                {
                    h = i;
                    string[] stuff = input[i].Split(' ');
                    for (int j = stuff.Length-1; j >=0 ; j--)
                    {
                        if (int.TryParse(stuff[j], out w)) break;
                    }
                    break;
                }
            }

            Stack<char>[] stacks = new Stack<char>[w];

            for (int i = 0; i < w; i++)//filling stacks
            {
                Console.Write(i);
                stacks[i] = new Stack<char>();
                for (int j = h - 1; j >= 0; j--)
                {
                    Console.Write(" " + input[j][4*i+1]);
                    if (input[j][4 * i + 1].Equals(' ')) break;
                    stacks[i].Push(input[j][4 * i + 1]);
                }
                Console.WriteLine();
            }
            
            for (int i = h+2; i < input.Length; i++)
            {
                Console.WriteLine(input[i]);
                new Move(input[i]).PerformOn(ref stacks, CraneMover.fancy);
            }

            StringBuilder sb = new();
            for (int i = 0; i < w; i++)
            {
                sb.Append(stacks[i].Peek());
            }
            Console.WriteLine(sb.ToString());
        }
        public static void PrintSolution_Part2(string _inputPath)
        {

        }

    }
}
