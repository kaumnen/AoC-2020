using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day_7_Handy_Haversacks
{
    class Program
    {
        static List<string> BagSearcher(string bagName, string[] bags, out int numOfNew, out string shinyBagContainer)
        {
            List<string> result = new List<string>();
            numOfNew = 0;
            shinyBagContainer = "";

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

                if (bag.Split("contain")[0].Contains("shiny gold"))
                    shinyBagContainer = bag;
            }

            return result;
        }

        static void Main(string[] args)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\exnatz\Desktop\advent-of-code-20\Day 7 Handy Haversacks\input.txt");


            List<string> valuableCases = new List<string>();
            List<string> inputRows = new List<string>();

            Dictionary<string, int> bagValues = new Dictionary<string, int>();
            Dictionary<string, int> bagMultipl = new Dictionary<string, int>();

            valuableCases.Add("shiny gold");

            string[] lines = file.ReadToEnd().Split("\r\n");

            for (int i = 0; i < valuableCases.Count; i ++)
            {

                foreach (string bag in lines)
                {
                    if (bag.Split("contain")[0].Contains(valuableCases[i]))
                    {
                        inputRows.Add(bag);

                        foreach (string containingBags in bag.Split("contain ")[1].Split(", "))
                        {
                            if (!(containingBags.Split(" ")[1] + " " + containingBags.Split(" ")[2] == "other bags.") && !valuableCases.Contains(containingBags.Split(" ")[1] + " " + containingBags.Split(" ")[2]))
                                valuableCases.Add(containingBags.Split(" ")[1] + " " + containingBags.Split(" ")[2]);
                        }
                    }
                }
            }

            foreach (string s in inputRows)
            {
                Console.WriteLine(s);
                if (s.Contains("no other bags"))
                {
                    bagValues.Add(s.Split(" bags")[0], 1);
                }
            }

            //populating dictionary with key value pairs, key being name of bag
            foreach (string s in inputRows)
            {
                foreach (string k in s.Split("contain ")[1].Split(", "))
                {
                    string temp = k.Split(" bag")[0];

                    if (temp != "no other")
                        //Console.WriteLine(temp);
                        if (!bagMultipl.ContainsKey(temp.Split(" ")[1] + " " + temp.Split(" ")[2]))
                            bagMultipl.Add(temp.Split(" ")[1] + " " + temp.Split(" ")[2], Convert.ToInt32(temp.Split(" ")[0]));
                }
            }

            //dict check
            foreach (KeyValuePair<string, int> ky in bagValues)
            {
                Console.WriteLine($"this is bag name {ky.Key}, this is value {ky.Value}");
            }

            foreach (KeyValuePair<string, int> ky in bagMultipl)
            {
                Console.WriteLine($"this is key {ky.Key}, this is multipication value {ky.Value}");
            }

            while (bagValues.Count != inputRows.Count - 1)
            {



            }

        }
    }
}
