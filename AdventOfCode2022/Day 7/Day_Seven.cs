using AdventOfCode2022.Day_7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    internal class Day_Seven
    {
        public static void PrintSolution_Part1(string _inputPath)
        {
            if (File.Exists(_inputPath) == false) return;
            var input = File.ReadAllLines(_inputPath);

            ElfDirectory root = new ElfDirectory("/");
            BuildTree(ref input, root);

            root.Visualize(2);

            ulong ans = 0;
            foreach (var dir in ElfDirectory.EveryDir)
            {
                if(dir.Size() <= 100_000)
                {
                    ans += dir.Size();
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Answer is: {ans}");
        }

        public static void PrintSolution_Part2(string _inputPath)
        {
            if (File.Exists(_inputPath) == false) return;
            var input = File.ReadAllLines(_inputPath);

            ElfDirectory root = new ElfDirectory("/");
            BuildTree(ref input, root);

            //root.Visualize(2);
            const ulong TOTAL = 70_000_000;
            const ulong NEEDED = 30_000_000;

            ulong avaliable = TOTAL - root.Size();
            ulong minSize = NEEDED - avaliable;

            ElfDirectory? candidate = ElfDirectory.EveryDir.Where(d => d.Size() >= minSize).OrderBy(d => d.Size()).FirstOrDefault();
            if (candidate == null)
            {
                Console.WriteLine("xD");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Answer is: {candidate.Size()}");
            }
            
        }


        private static void BuildTree(ref string[] input, ElfDirectory root)
        {
            ElfDirectory currentDir = root;
            foreach (var line in input)
            {
                if (line[0].Equals('$')) //Parancs
                {
                    var command = line.Split(' ');
                    if (command[1].Equals("cd"))
                    {
                        switch (command[2])
                        {
                            case "..":
                                currentDir = currentDir.StepBack();
                                break;
                            case "/":
                                currentDir = ElfDirectory.root;
                                break;
                            default:
                                currentDir = currentDir.FindDir(command[2]);
                                break;
                        }
                    }
                }
                else //reads ls content
                {
                    var output = line.Split(' ');
                    if (output[0].Equals("dir"))
                    {
                        currentDir.AddDirectory(output[1]);
                    }
                    else
                    {
                        currentDir.AddFile(ulong.Parse(output[0]));
                    }
                }

            }
        }

    }
}
