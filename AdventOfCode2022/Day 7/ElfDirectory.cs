using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day_7
{
    internal class ElfDirectory
    {
        public static List<ElfDirectory> EveryDir = new();

        string name;
        ElfDirectory? parent = null;
        List<ElfDirectory> directories;
        List<ulong> files;

        public ElfDirectory(string name)
        {
            this.name = name;
            directories = new();
            files = new();
            EveryDir.Add(this);
        }
        public ElfDirectory(string name,ElfDirectory parent)
        {
            this.parent = parent;
            this.name = name;
            directories = new();
            files = new();
            EveryDir.Add(this);
        }

        public void AddDirectory(string name)
        {
            directories.Add(new ElfDirectory(name,this));
        }
        public void AddFile(ulong _fileSize)
        {
            files.Add(_fileSize);
        }

        public ulong Size()
        {
            ulong sum = 0;
            foreach (var fileSize in files)
            {
                sum += fileSize;
            }
            foreach (var dir in directories)
            {
                sum += dir.Size();
            }
            return sum;
        }

        public ElfDirectory StepBack()
        {
            if (parent == null)
            {
                return this;
            }
            return parent;
        }

        public ElfDirectory FindDir(string name)
        {
            var dir = directories.Where(d => d.name.Equals(name)).FirstOrDefault();
            if (dir == null) return this;
            return dir;
        }


        public void Visualize(int depth)
        {
            Console.ForegroundColor = (ConsoleColor)depth;
            for (int i = 0; i < depth; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine($"-{name} (dir)");
            foreach (var dir in directories)
            {
                dir.Visualize(depth+1);
            }
            Console.ForegroundColor = (ConsoleColor)depth;
            foreach (var fileSize in files)
            {
                for (int i = 0; i <= depth; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine($"-{fileSize} (file)");
            }
        }

    }
}
