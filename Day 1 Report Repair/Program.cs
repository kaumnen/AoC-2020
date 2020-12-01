using System;

namespace Day_1_Report_Repair
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;

            int[] splitted_values = new int[200];
            int i = 0;

            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\exnatz\Desktop\advent-of-code-20\Day 1 Report Repair\input.txt");
            while ((line = file.ReadLine()) != null)
            {
                splitted_values[i++] = Convert.ToInt32(line);
            }

            foreach (int j in splitted_values)
            {
                foreach (int z in splitted_values)
                {
                    foreach (int k in splitted_values)
                    {
                        if (j == k || k == z || j == z)
                        {
                            continue;
                        }
                        else
                        {
                            if (j + k + z == 2020)
                            {
                                Console.WriteLine($"{j * k * z}");
                            }
                        }
                    }
                }  
            }
        }
    }
}
