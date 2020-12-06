using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
{
    class Program
    {

        private static int Solve(List<string> inp)
        {
            var yesSet = new HashSet<char>();
            var sum = 0;
            foreach (var item in inp)
            {
                if (!item.Equals(string.Empty))
                {
                    for (int i = 0; i < item.Length; i++)
                    {
                        yesSet.Add(item[i]);
                    }
                }
                else
                {
                    sum += yesSet.Count;

                    yesSet.Clear();
                }
                
            }
            sum += yesSet.Count;
            return sum;
        }

        private static int Solve2(List<string> inp)
        {
            var yesSet = new HashSet<char>();
            var sum = 0;
            var isFirst = true;
            foreach (var item in inp)
            {
                if (!item.Equals(string.Empty))
                {
                    var tempSet = new HashSet<char>();
                    for (int i = 0; i < item.Length; i++)
                    {
                        tempSet.Add(item[i]);
                    }

                    if (isFirst)
                    {
                        yesSet = tempSet;
                        isFirst = false;
                    }
                    else
                    {
                        yesSet.IntersectWith(tempSet);
                    }
                }
                else
                {
                    sum += yesSet.Count;
                    yesSet.Clear();
                    isFirst = true;
                }

            }

            sum += yesSet.Count;
            return sum;
        }

        static void Main(string[] args)
        {
            var list = File.ReadAllLines("input.txt").ToList();

            Console.WriteLine(Solve(list));
            Console.WriteLine(Solve2(list));
        }
    }
}
