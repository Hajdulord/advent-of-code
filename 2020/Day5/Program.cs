using System;
using System.IO;
using System.Linq;

namespace Day5
{
    class Program
    {

        static int Parser(string instructions)
        {
            var (row, column) = (0, 0);
            var (min, max) = (0, 127);

            for (int i = 0; i < instructions.Length - 3; i++)
            {
                (min, max) = InstructionApplier(instructions[i], (min, max));
            }

            row = min;


            (min, max) = (0, 7);

            for (int i = instructions.Length - 3; i < instructions.Length; i++)
            {
                (min, max) = InstructionApplier(instructions[i], (min, max));
            }

            column = min;

            return row * 8 + column;
        }

        private static (int, int) InstructionApplier(char inp, (int min, int max) p) =>
            inp switch
            {

                'F' or 'L' => (p.min , (p.max + p.min) / 2),
                'B' or 'R' => ((p.min + p.max) / 2 + 1, p.max),
                _ => throw new ArgumentException()
            };


        static void Main(string[] args)
        {
            Console.WriteLine(File.ReadAllLines("input.txt").ToList().ConvertAll(Parser).Max());
            var list = File.ReadAllLines("input.txt").ToList().ConvertAll(Parser).OrderBy(x => x);
            //list.Select(x => x + 1).Except(list).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine(list.Select(x => x + 1).Except(list).First());
        }
    }
}
