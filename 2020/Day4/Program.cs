using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day4
{
    class Program
    {
        
        public class Passport
        {
            public int Byr { get; set; } = -1;
            public int Iyr { get; set; } = -1;
            public int Eyr { get; set; } = -1;
            public string Hgt { get; set; } = string.Empty;
            public string Hcl { get; set; } = string.Empty;
            public string Ecl { get; set; } = string.Empty;
            public string Pid { get; set; } = string.Empty;
            public string Cid { get; set; } = string.Empty;

            /*enum EyeColor
            {
                amb,
                blu,
                brn,
                gry,
                grn,
                hzl,
                oth
            }*/

            public bool IsValid()
            {
                return Byr != -1 && Iyr != -1 && Eyr != -1 && !Hgt.Equals(string.Empty) && !Pid.Equals(string.Empty) && !Hcl.Equals(string.Empty) && !Ecl.Equals(string.Empty);
            }

            public bool IsValid2()
            {
                var byr = Byr >= 1920 && Byr <= 2002;

                var iyr = Iyr >= 2010 && Iyr <= 2020;

                var eyr = Eyr >= 2020 && Eyr <= 2030;

                /*var hgt = !Hgt.Equals(string.Empty);

                if (hgt && Hgt.Length > 2)
                {
                    var h = int.Parse(Hgt.Substring(0, Hgt.Length - 2));
                    if (Hgt.Contains("in"))
                    {
                        hgt = hgt && h >= 56 && h <= 76;
                    }
                    else if(Hgt.Contains("cm"))
                    {
                        hgt = hgt && h >= 150 && h <= 193;
                    }
                    else
                    {
                        hgt = false;
                    }
                }*/
                var hgt = new Regex("^(1([5-8][0-9]|9[0-3])cm|(59|6[0-9]|7[0-6])in)$").IsMatch(Hgt);

                /*var hcl = !Hcl.Equals(string.Empty) && Hcl.Length == 7 && Hcl.Substring(0, 1).Equals("#");
                if (hcl)
                {
                    var tempHclsb = Hcl.Substring(1, Hcl.Length - 1).ToCharArray();
                    var charSet = new HashSet<char>();
                    for (int i = 'a'; i <= 'f'; i++)
                    {
                        charSet.Add((char)i);
                    }

                    for (int i = 48; i <= 59; i++)
                    {
                        charSet.Add((char)i);
                    }

                    foreach (var item in tempHclsb)
                    {
                        hcl = hcl && charSet.Contains(item);
                    }
                }*/
                var hcl = new Regex("^#[a-f0-9]{6}$").IsMatch(Hcl);

                /*var ecl = !Ecl.Equals(string.Empty);
                EyeColor result;
                if (!Enum.TryParse(Ecl, out result))
                {
                    ecl = false;
                }*/

                var ecl = new Regex("^(amb|blu|brn|gry|grn|hzl|oth)$").IsMatch(Ecl);

                //var pid = !Pid.Equals(string.Empty) && Pid.Length == 9;
                var pid = new Regex("^[0-9]{9}$").IsMatch(Pid);

                return byr && iyr && eyr && hgt && hcl && ecl && pid;
            }
        }

        public static List<Passport> Parse(List<string> inp)
        {
            var passports = new List<Passport>();

            var tempPassword = new Passport();

            foreach (var item in inp)
            {
                var temp = item.Split(' ');

                foreach (var item2 in temp)
                {
                    var valuePairs = item2.Split(':');

                    switch (valuePairs[0])
                    {

                        case "byr":
                            tempPassword.Byr = int.Parse(valuePairs[1]);
                            break;
                        case "iyr":
                            tempPassword.Iyr = int.Parse(valuePairs[1]);
                            break;
                        case "eyr":
                            tempPassword.Eyr = int.Parse(valuePairs[1]);
                            break;
                        case "hgt":
                            tempPassword.Hgt = valuePairs[1];
                            break;
                        case "hcl":
                            tempPassword.Hcl = valuePairs[1];
                            break;
                        case "ecl":
                            tempPassword.Ecl = valuePairs[1];
                            break;
                        case "pid":
                            tempPassword.Pid = valuePairs[1];
                            break;
                        case "cid":
                            tempPassword.Cid = valuePairs[1];
                            break;
                        default:
                            break;
                    }
                }

                if (item.Length == 0)
                {
                    passports.Add(tempPassword);
                    tempPassword = new Passport();
                }
                   
            }
            passports.Add(tempPassword);

            return passports;
        }

        static void Main(string[] args)
        {
            var inp = File.ReadAllLines("input.txt").ToList();

            Console.WriteLine(Parse(inp).Where(i => i.IsValid()).Count());
            Console.WriteLine(Parse(inp).Where(i => i.IsValid2()).Count());

        }
    }
}
