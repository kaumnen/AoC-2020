using System;

namespace Day_3_Toboggan_Trajectory
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            int[] moveToTheRight = new[] { 1, 3, 5, 7, 1 };   
            int[] result = new int[5];
            long submission = 1;

            for (int i = 0; i < moveToTheRight.Length; i++)
            {
                int pointer = 0;
                int j = 0;

                System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\exnatz\Desktop\advent-of-code-20\Day 3 Toboggan Trajectory\input.txt");

                while ((line = file.ReadLine()) != null)
                {
                    if (i == moveToTheRight.Length - 1)
                    {
                        if (j % 2 == 0)
                        {
                            if (line[pointer] == '#')
                            {
                                result[i] += 1;
                            }
                            pointer = (pointer + 1) % line.Length;
                            j += 1;
                        }

                        else
                        {
                            j += 1;
                            continue;
                        }
                    }
                    else
                    {
                        if (line[pointer] == '#')
                        {
                            result[i] += 1;
                        }
                        pointer = (pointer + moveToTheRight[i]) % line.Length;
                    }
                }
                Console.WriteLine(submission);
                submission *= result[i];
                Console.WriteLine($"result of slope: {result[i]}, multiplied result: {submission}");
                
            }
        }
    }
}
