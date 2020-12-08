using System;
using System.Collections.Generic;

namespace Day_7_Handy_Haversacks
{
    class Program
    {
        static List<string> BagSearcher(string bagName, string[] bags, out int numOfNew)
        {
            List<string> result = new List<string>();
            numOfNew = 0;

            foreach (string bag in bags)
            {
                if (bag.Split("contain")[1].Contains(bagName))
                {
                    string newBag = bag.Split(" ")[0] + " " + bag.Split(" ")[1];
                    if (!result.Contains(newBag))
                    {
                        result.Add(newBag);
                        numOfNew += 1;
                    }

                }
            }

            return result;
        }
        static void Main(string[] args)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\exnatz\Desktop\advent-of-code-20\Day 7 Handy Haversacks\input.txt");


            List<string> valuableCases = new List<string>();
            valuableCases.Add("shiny gold");

            int mainResult = 0;
            string[] lines = file.ReadToEnd().Split("\r\n");

            for (int i = 0; i < valuableCases.Count; i ++)
            {
                Console.WriteLine(valuableCases[i]);
                List<string> freshBags = BagSearcher(valuableCases[i], lines, out int result);
                foreach (string bag in freshBags)
                {
                    if (!valuableCases.Contains(bag))
                    {
                        valuableCases.Add(bag);
                    }
                    else
                        result -= 1;
                }
                mainResult += result;
            }

            Console.WriteLine(mainResult);
        }
    }
}
