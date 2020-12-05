using System;
using System.Linq;

namespace Day_5_Binary_Boarding
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\exnatz\Desktop\advent-of-code-20\Day 5 Binary Boarding\input.txt");
            string line;

            int maxID = 0;
            int currentID;

            //seats in plane
            int[] IDs = new int[128 * 8];
            int position = 0;

            //bounds 
            int upper;
            int lower;
            int left;
            int right;

            int rowFinal;
            int columnFinal;

            while ((line = file.ReadLine()) != null)
            {
                string rowLetters = line.Substring(1, 5);
                char columnLetter = line[8];

                //row bounds
                if (line[0] == 'F')
                {
                    lower = 0;
                    upper = 63;
                }
                else
                {
                    lower = 64;
                    upper = 127;
                }

                //column bounds
                if (line[7] == 'L')
                {
                    left = 0;
                    right = 3;
                }
                else
                {
                    left = 4;
                    right = 7;
                }

                //calculating row
                foreach (char letter in rowLetters)
                {
                    if (letter == 'F')
                        upper -= (upper - lower) / 2 + 1;
                    else
                        lower += (upper - lower) / 2 + 1;
                }

                if (line[6] == 'F')
                    rowFinal = lower;
                else
                    rowFinal = upper;

                //calculating column
                if (columnLetter == 'L')
                    right -= (right - left) / 2 + 1;
                else
                    left += (right - left) / 2 + 1;

                if (line[9] == 'L')
                    columnFinal = left;
                else
                    columnFinal = right;

                currentID = rowFinal * 8 + columnFinal;

                if (currentID > maxID)
                {
                    maxID = currentID;
                }

                //part two
                IDs[currentID] = 1;
                position += 1;
            }

            for (int i = 1; i < IDs.Length - 1; i ++)
            {
                if (IDs[i - 1] == 1 && IDs[i + 1] == 1 && IDs[i] == 0)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
            

            Console.WriteLine(maxID);
        }
    }
}
