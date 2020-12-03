using System;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program
    {
        public static int Solve(int vertical, int horizontal, System.Collections.Generic.List<string> forest)
        {
            var trees = 0;
            var verticalIndex = 1;

            for (int i = 0; i < forest.Count - horizontal; i += horizontal)
            {
                var temp = forest[i + horizontal];
                if (forest[i + horizontal][verticalIndex + vertical - 1].Equals('#'))
                {
                    ++trees;
                    
                }

                verticalIndex += vertical;
                

                if (verticalIndex + vertical > forest[i + horizontal].Length)
                {
                    verticalIndex = verticalIndex + vertical - forest[i + horizontal].Length - vertical ;
                }

            }
            return trees;
        }

        static void Main(string[] args)
        {
            var inp = File.ReadAllLines("input.txt").ToList();
            Console.WriteLine(Solve(3, 1, inp));

            Console.WriteLine(Solve(1, 1, inp) * Solve(3, 1, inp) * Solve(5, 1, inp) * Solve(7, 1, inp) * Solve(1, 2, inp));
        }
    }
}
