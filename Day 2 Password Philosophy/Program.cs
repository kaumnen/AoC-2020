using System;
using System.Collections.Generic;

namespace Day_2_Password_Philosophy
{
    class Program
    {
        static void Main(string[] args)
        { 
            //PART ONE
            
            string line;
            int partOneResult = 0;
            int partTwoResult = 0;

            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\exnatz\Desktop\advent-of-code-20\Day 2 Password Philosophy\input.txt");

            while ((line = file.ReadLine()) != null)
            {
                string[] KeyValuePair = line.Split(": ");
                string word = KeyValuePair[1];

                string[] parameters = KeyValuePair[0].Split(" ");

                char letterParameter = Convert.ToChar(parameters[1]);

                string[] occurencyLimits = parameters[0].Split("-");
                int firstLimit = Convert.ToInt32(occurencyLimits[0]);
                int secondLimit = Convert.ToInt32(occurencyLimits[1]);

                int letterOccurency = 0;


                foreach (char c in KeyValuePair[1])
                {
                    if (c == letterParameter)
                    {
                        letterOccurency += 1;
                    }

                    if (letterOccurency > secondLimit)
                    {
                        continue;
                    }
                }

                if (firstLimit <= letterOccurency && letterOccurency <= secondLimit)
                {
                    partOneResult += 1;
                }

                //PART TWO
                if (word[firstLimit - 1] == letterParameter && word[secondLimit - 1] == letterParameter)
                {
                    continue;
                }
                else if (word[firstLimit - 1] == letterParameter || word[secondLimit - 1] == letterParameter)
                {
                    partTwoResult += 1;
                }
            }

            Console.WriteLine(partOneResult);
            Console.WriteLine(partTwoResult);
        }
    }
}
