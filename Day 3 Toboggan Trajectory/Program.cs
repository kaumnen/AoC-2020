using System;

namespace Day_3_Toboggan_Trajectory
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            int indexOfPointer = 0;
            int result = 0;

            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\exnatz\Desktop\advent-of-code-20\Day 3 Toboggan Trajectory\input.txt");

            while ((line = file.ReadLine()) != null)
            {

                if (line[indexOfPointer] == '#')
                {
                    result += 1;
                }
                //going right and checking if index is out of bounds
                indexOfPointer = (indexOfPointer + 3) % line.Length;


             }

            Console.WriteLine(result);
        }
    }
}
