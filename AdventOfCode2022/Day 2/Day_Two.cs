using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day_2
{
    internal static class Day_Two
    {
        private const string INPUT_FILE = "../../../Day 2/input.txt";

        public static void PrintSolution_Part1()
        {
            if (File.Exists(INPUT_FILE) == false) return;
            int sumScore = 0;
            foreach (var line in File.ReadLines(INPUT_FILE))
            {
                //Console.WriteLine($"{line} |\t{CalcLineScore(line)}");
                sumScore += CalcLineScore(line);
            }
            Console.WriteLine($"Answer is: {sumScore}");
        }
        public static void PrintSolution_Part2()
        {
            if (File.Exists(INPUT_FILE) == false) return;
            int sumScore = 0;
            foreach (var line in File.ReadLines(INPUT_FILE))
            {
                //Console.WriteLine($"{line} |\t{CalcLineScore(line)}");
                sumScore += CalcLineScorePart2(line);
            }
            Console.WriteLine($"Answer is: {sumScore}");
        }

        private static int CalcLineScore(string _line)
        {
            ReadOnlySpan<char> lineAsSpan = _line;
            return CalcScore(lineAsSpan[0], lineAsSpan[2]);
        }
        private static int CalcLineScorePart2(string _line)
        {
            ReadOnlySpan<char> lineAsSpan = _line;
            return CalcScoreWithOutcome(lineAsSpan[0], lineAsSpan[2]);
        }
        private static int CalcScore(char op,char re)
        {

            return OutcomeScore(ref op,ref re) + GetResponseScore(re);
        }
        private static int CalcScoreWithOutcome(char op, char outcome)
        {
            return OutcomeScore(ref outcome) + GetResponseScore(GetResponse(ref op,ref outcome));
        }

        private static char GetResponse(ref char op, ref char outcome)
        {
            switch (op)
            {
                case 'A':
                    switch (outcome)
                    {
                        case 'X': return 'C'; //lose
                        case 'Y': return 'A'; //draw
                        case 'Z': return 'B'; //win
                        default:
                            throw new Exception("Bad outcome");
                    };
                case 'B':
                    switch (outcome)
                    {
                        case 'X': return 'A';
                        case 'Y': return 'B';
                        case 'Z': return 'C';
                        default:
                            throw new Exception("Bad outcome");
                    }; ;
                case 'C':
                    switch (outcome)
                    {
                        case 'X': return 'B';
                        case 'Y': return 'C';
                        case 'Z': return 'A';
                        default:
                            throw new Exception("Bad outcome");
                    }; ;
                default:
                    throw new Exception("Bad opponent");
            }
        }

        private static int OutcomeScore(ref char outcome)
        {
            switch (outcome)
            {
                case 'X': return 0;
                case 'Y': return 3;
                case 'Z': return 6;
                default:
                    throw new Exception("Invalid input...");
            }
        }
        private static int OutcomeScore(ref char op, ref char re)
        {
            switch (op)
            {
                case 'A':
                    switch (re)
                    {
                        case 'X': return 3; //Rock-Rock -- Draw
                        case 'Y': return 6; //Rock-Paper -- win
                        case 'Z': return 0; //Rock-Scissors -- lose
                        default:
                            throw new Exception("Bad response");
                    };
                case 'B':
                    switch (re)
                    {
                        case 'X': return 0; //Paper-Rock
                        case 'Y': return 3; //Paper-Paper
                        case 'Z': return 6; //Paper-Scissors
                        default:
                            throw new Exception("Bad response");
                    }; ;
                case 'C':
                    switch (re)
                    {
                        case 'X': return 6; //Scissors-Rock
                        case 'Y': return 0; //Scissors-Paper
                        case 'Z': return 3; //Scissors-Scissors
                        default:
                            throw new Exception("Bad response");
                    }; ;
                default:
                    throw new Exception("Bad opponent");
            }
        }
        private static int GetResponseScore(char re)
        {
            switch (re)
            {
                case 'A': return 1;
                case 'B': return 2;
                case 'C': return 3;
                default:
                    throw new Exception("Invalid input...");
            }
        }
    }
}
