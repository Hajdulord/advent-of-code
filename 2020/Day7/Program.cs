using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7
{
    class Program
    {
        public record Bag
        {
            public string Type { get; init; }
            public string Color { get; init; }

            public string Name
            {
                get { return string.Concat(Type, " ", Color); }
            }

            public Dictionary<string, int> ContainableBags { get; private set; }

            public Bag(string type, string color, Dictionary<string, int> bags) => (Type, Color, ContainableBags) = (type, color, bags);

            public static Bag Parse(string inp)
            {
                var subStrings = inp.Split(' ');
                var bags = new Dictionary<string, int>();

                if (!subStrings[4].Equals("no"))
                {
                    var volume = 0;
                    var name = string.Empty;
                    for (int i = 4; i < subStrings.Length; i++)
                    {
                        switch (i % 4)
                        {
                            case 0:
                                volume = int.Parse(subStrings[i]);
                                break;
                            case 1:
                                name = subStrings[i];
                                break;
                            case 2:
                                name = string.Concat(name, " ", subStrings[i]);
                                break;
                            case 3:
                                bags.Add(name, volume);
                                break;
                            default:
                                break;
                        }
                    }
                }

                return new Bag(subStrings[0], subStrings[1], bags);
            }
        }

        public static int Solve(List<Bag> bags, string myBag)
        {
            var validBags = new HashSet<string>();
            validBags.Add(myBag);

            for (int i = 0; i < bags.Count; i++)
            {
                var temp = new HashSet<string>();
                var validBagsNum = validBags.Count;
                foreach (var valid in validBags)
                {
                    if (bags[i].ContainableBags.ContainsKey(valid))
                    {
                        temp.Add(bags[i].Name);
                    }
                }
                validBags.UnionWith(temp);

                if (validBags.Count != validBagsNum)
                {
                    i = 0;
                }
            }

            foreach (var item in bags)
            {
                var temp = new HashSet<string>();
                foreach (var valid in validBags)
                {
                    if (item.ContainableBags.ContainsKey(valid))
                    {
                        temp.Add(item.Name);
                    }
                }
                validBags.UnionWith(temp);
            }

            return validBags.Count - 1;
        }

        public static int Solve2(List<Bag> bags, string myBag)
        {
            var children = bags.Find(x => x.Name.Equals(myBag)).ContainableBags.Keys.ToList();
            var val = bags.Find(x => x.Name.Equals(myBag)).ContainableBags.Values.ToList();
            var sum = 0;

            for (int i = 0; i < children.Count; i++)
            {
                sum += val[i] + val[i] * Solve2(bags, children[i]);
            }
            return sum;
        }


        static void Main(string[] args)
        {
            var list = File.ReadAllLines("input.txt").ToList().ConvertAll(Bag.Parse);

            Console.WriteLine(Solve(list, "shiny gold"));

            Console.WriteLine(Solve2(list, "shiny gold"));
        }
    }
}
