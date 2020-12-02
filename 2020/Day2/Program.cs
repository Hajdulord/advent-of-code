using System;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {

        public struct Input
        {
            public int Min { get; private set; }
            public int Max { get; private set; }
            public char NeededChar { get; private set; }
            public string Password { get; private set; }

            public Input(int min, int max, char neededChar, string password)
            {
                Min = min;
                Max = max;
                NeededChar = neededChar;
                Password = password;
            }
        }

        static Input Parse(string inp)
        {
            var splitSpace = inp.Split(" ");

            var password = splitSpace[2];

            var neededChar = splitSpace[1].ToCharArray()[0];

            var min = int.Parse(splitSpace[0].Split('-')[0]);

            var max = int.Parse(splitSpace[0].Split('-')[1]);

            return new Input(min, max, neededChar, password);
        }

        static bool IsValid(Input input)
        {
            var g = input.Password.Where(t => t == input.NeededChar).Count();

            return g >= input.Min && g <= input.Max;
        }

        static bool IsValid2(Input input)
        {
            return (input.Password[input.Min - 1].Equals(input.NeededChar) || input.Password[input.Max - 1].Equals(input.NeededChar)) && !input.Password[input.Max - 1].Equals(input.Password[input.Min - 1]);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(File.ReadAllLines("input.txt").ToList().ConvertAll(Parse).Where(i => IsValid(i)).Count());
            Console.WriteLine(File.ReadAllLines("input.txt").ToList().ConvertAll(Parse).Where(i => IsValid2(i)).Count());
        }
    }
}
