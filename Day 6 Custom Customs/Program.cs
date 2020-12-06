using System;

namespace Day_6_Custom_Customs
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\exnatz\Desktop\advent-of-code-20\Day 6 Custom Customs\input.txt");

            string[] answerGroups = file.ReadToEnd().Split("\r\n\r\n");
            char[] letters = new[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            int result = 0;

            foreach (string answers in answerGroups)
            {
                foreach (char i in letters)
                {
                    if (answers.Contains(i))
                    {
                        result += 1;
                    }
                }

            }

            Console.WriteLine(result);
        }
    }
}
