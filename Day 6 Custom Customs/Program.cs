using System;
using System.Linq;

namespace Day_6_Custom_Customs
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\exnatz\Desktop\advent-of-code-20\Day 6 Custom Customs\input.txt");

            string[] answerGroups = file.ReadToEnd().Split("\r\n\r\n");

            int result = 0;
            bool sameAnswer = false;

            foreach (string answers in answerGroups)
            {
                //take all letters from first person
                foreach (char answer in answers.Split("\r\n")[0])
                {
                    //cycle through all persons to see if all of them got that answer
                    foreach (string ans in answers.Split("\r\n"))
                    {

                        if (ans.Contains(answer))
                        {
                            sameAnswer = true;
                        }
                        else
                        {
                            sameAnswer = false;
                            break;
                        }  
                    }

                    if (sameAnswer)
                        result += 1;
                }
            }

            Console.WriteLine(result);
        }
    }
}
