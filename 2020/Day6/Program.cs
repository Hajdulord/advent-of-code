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
            var yesSets = new List<HashSet<char>>();
            var sum = 0;
            foreach (var item in inp)
            {
                if (!item.Equals(string.Empty))
                {
                    var tempSet = new HashSet<char>();
                    for (int i = 0; i < item.Length; i++)
                    {
                        tempSet.Add(item[i]);
                    }
                    yesSets.Add(tempSet);
                }
                else
                {
                    var tempSet = yesSets.First();

                    for (int i = 1; i < yesSets.Count; i++)
                    {
                        tempSet.IntersectWith(yesSets[i]);
                    }
                    sum += tempSet.Count;
                    yesSets.Clear();
                }

            }
            var temp = yesSets.First();

            for (int i = 1; i < yesSets.Count; i++)
            {
                temp.IntersectWith(yesSets[i]);
            }
            sum += temp.Count;
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
