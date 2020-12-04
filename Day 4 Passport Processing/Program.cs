using System;

namespace Day_4_Passport_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\exnatz\Desktop\advent-of-code-20\Day 4 Passport Processing\input.txt");

            string[] documents = file.ReadToEnd().Split("\r\n\r\n");

            string[] requirements = new[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            int result = 0;
            bool valid = true;

            foreach (string i in documents)
            {
                foreach (string req in requirements)
                {
                    if (!(i.Contains(req)))
                    {
                        valid = false;
                        break;
                    }
                    else
                    {
                        valid = true;
                    }
                }

                if (valid)
                {
                    result += 1;
                }
            }

            Console.WriteLine(result);

        }
    }
}
