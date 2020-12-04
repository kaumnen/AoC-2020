using System;
using System.Text.RegularExpressions;

namespace Day_4_Passport_Processing
{
    class Program
    {
        static bool BirthCheck(int year)
        {
            if (!(year >= 1920 && year <= 2002))
            {
                return false;
            }
            return true;
        }

        static bool IssueCheck(int year)
        {
            if (!(year >= 2010 && year <= 2020))
            {
                return false;
            }
            return true;
        }

        static bool ExpirationCheck(int year)
        {
            if (!(year >= 2020 && year <= 2030))
            {
                return false;
            }
            return true;
        }

        static bool HeightCheck(int height, string expr)
        {
            if (expr == "cm")
            {
                if (!(height >= 150 && height <= 193))
                {
                    return false;
                }
                return true;
            }

            else if (expr == "in")
            {
                if (!(height >= 59 && height <= 76))
                {
                    return false;
                }
                return true;
            }

            else
                return false;
        }

        static void Main(string[] args)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\exnatz\Desktop\advent-of-code-20\Day 4 Passport Processing\input.txt");

            string[] documents = file.ReadToEnd().Split("\r\n\r\n");

            int result = 0;

            foreach (string i in documents)
            {

                string pattern = @"(byr:([0-9]{4}))|(iyr:([0-9]{4}))|(eyr:([0-9]{4}))|(ecl:(amb|blu|brn|gry|grn|hzl|oth))|(hcl:#[0-9a-f]{6})|(hgt:([0-9]{2,3})(cm|in))|(pid:[0-9]{9})";
                Regex defaultRegex = new Regex(pattern);

                MatchCollection matches = defaultRegex.Matches(i);;
                
                //check if all are present
                if (matches.Count < 7)
                {
                    continue;
                }

                //if all are present, do the respective checks
                int birthYear = Convert.ToInt32(new Regex(@"byr:([0-9]{4})").Match(i).Groups[1].Value);
                int expirationYear = Convert.ToInt32(new Regex(@"eyr:([0-9]{4})").Match(i).Groups[1].Value);
                int issueYear = Convert.ToInt32(new Regex(@"iyr:([0-9]{4})").Match(i).Groups[1].Value);
                int heightNumber = Convert.ToInt32(new Regex(@"hgt:([0-9]{2,3})(cm|in)").Match(i).Groups[1].Value);
                string heightExpr = Convert.ToString(new Regex(@"hgt:([0-9]{2,3})(cm|in)").Match(i).Groups[2].Value);

                //checks if right format is present
                bool hairColor = new Regex(@"hcl:#[0-9a-f]{6}").Match(i).Success;

                //checks if right format is present
                bool eyeColor = new Regex(@"ecl:(amb|blu|brn|gry|grn|hzl|oth)").Match(i).Success;

                //returns number of PID digits
                int passportID = Convert.ToInt32(new Regex(@"pid:([0-9]*)").Match(i).Groups[1].Length);

                if (Program.BirthCheck(birthYear) && Program.ExpirationCheck(expirationYear) && Program.IssueCheck(issueYear) && Program.HeightCheck(heightNumber, heightExpr) && hairColor && eyeColor && passportID == 9)
                {
                    result += 1;
                }

            }

            Console.WriteLine(result);

        }
    }
}
