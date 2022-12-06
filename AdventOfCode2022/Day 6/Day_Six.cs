using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Numerics;

namespace AdventOfCode2022.Days
{
    internal class Day_Six
    {
        public static void PrintSolution_Part1(string _inputPath)
        {
            if (File.Exists(_inputPath) == false) return;
            byte[] input = File.ReadAllBytes(_inputPath);
            Console.WriteLine("Answer is : " + FindFirstUnique(ref input, 4));

        }

        public static void PrintSolution_Part2(string _inputPath)
        {
            if (File.Exists(_inputPath) == false) return;
            byte[] input = File.ReadAllBytes(_inputPath);
            Console.WriteLine("Answer is : " + FindFirstUnique(ref input, 14));
        }

        private static int FindFirstUnique(ref byte[] input, byte bufferSize)
       {
            for (int i = 0; i < input.Length - bufferSize; i++)
            {
                if (TestDuplicate(ref input, i, bufferSize) == false)
                {
                    return i+bufferSize+1;
                }
            }
            return -1;
       }

        private static bool TestDuplicate(ref byte[] array,int index, byte bufferSize)
        {
            HashSet<byte> unique = new HashSet<byte>();
            for (int offset = 1; offset <=  bufferSize; offset++)
            {
                if(unique.Add(array[index+offset]) == false) return true;
            }
            return false;
        }

        private static bool TestDuplicateV2(ref byte[] array, int index, byte bufferSize)
        {
            int set = 0;
            for (int offset = 1; offset <= bufferSize; offset++)
            {
                if (set == (set | (1 << (array[index + offset] - 'a')))) return true;

                set = set | (1 << ((array[index + offset] - 'a')));
            }
            return false;
        }
    }
}
