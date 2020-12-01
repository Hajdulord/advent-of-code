using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static int Solver(List<int> inputs)
        {
            for (int i = 0 ; i < inputs.Count - 1; i++)
            {
                for (int j = inputs.Count - 1; j >= i + 1; j--)
                {
                    if(inputs[i] + inputs[j] == 2020)
                    {
                        return inputs[i] * inputs[j];
                    }
                }
            }

            return -1;
        }

        static int Solver2(List<int> inputs)
        {
            for (int i = 0; i < inputs.Count - 1; i++)
            {
                for (int j = inputs.Count - 1; j >= i + 1; j--)
                {
                    for (int k = j - 1; k >= i + 1; k--)
                    {
                        if (inputs[i] + inputs[j] + inputs[k] == 2020)
                        {
                            return inputs[i] * inputs[j] * inputs[k];
                        }
                    }
                    
                }
            }

            return -1;
        }


        static void Main(string[] args)
        {
            Console.WriteLine(Solver(File.ReadAllLines("input.txt").ToList().ConvertAll(int.Parse)));
            Console.WriteLine(Solver2(File.ReadAllLines("input.txt").ToList().ConvertAll(int.Parse)));
        }
    }
}
