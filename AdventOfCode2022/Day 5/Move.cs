using AdventOfCode2022.Days;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day_5
{
    internal class Move
    {
        int number, from, to;
        public Move(string input)
        {
            var result = ParseMove(input);
            Number = result.number;
            From = result.from;
            To = result.to;
        }

        public int Number { get => number;private set => number = value; }
        public int From { get => from; private set => from = value; }
        public int To { get => to; private set => to = value; }

        private (int number, int from, int to) ParseMove(string line)
        {
            string[] segments = line.Split(' ');
            var n = int.Parse(segments[1]);
            var f = int.Parse(segments[3]);
            var t = int.Parse(segments[5]);
            return (n, f-1, t-1);
        }

        public void PerformOn(ref Stack<char>[] stacks, CraneMover method)
        {
            if (method == CraneMover.old)
            {
                for (int i = 0; i < number; i++)
                {
                    stacks[to].Push(stacks[from].Pop());
                }
            }else if(method == CraneMover.fancy)
            {
                Stack<char> crane = new();
                for (int i = 0; i < number; i++)
                {
                    crane.Push(stacks[from].Pop());
                }
                for (int i = 0; i < number; i++)
                {
                    stacks[to].Push(crane.Pop());
                }
            }
        }
    }
}
