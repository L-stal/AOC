using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_1
{
    internal class Program
    {
        static void Main()
        {
            string relativePath = "inputTest.txt";
            IDictionary<string, int> wordToValue = new Dictionary<string, int>()
            {
                {"zero", 0 },
                {"one", 1 },
                {"two", 2 },
                {"three", 3 },
                {"four", 4 },
                {"five", 5 },
                {"six", 6 },
                {"seven", 7 },
                {"eight", 8 },
                {"nine", 9 },

            };
            if (!File.Exists(relativePath))
            {
                Console.WriteLine("File not found: " + relativePath);
                return;
            }

            string[] lines = File.ReadAllLines(relativePath);
            int totalSum = 0;


            foreach (string line in lines)
            {

                int? firstDigit = null;
                int? lastDigit = null;

                for (int i = 0; i < line.Length; i++)
                {
                    if (char.IsDigit(line[i]))
                    {
                        int digit = line[i] - '0';

                        if (!firstDigit.HasValue)
                        {
                            firstDigit = digit;
                        }
                        lastDigit = digit;
                    }

                    foreach (var wordNumber in wordToValue)
                    {
                        if (line.Substring(i).StartsWith(wordNumber.Key))
                        {
                            int digit = wordNumber.Value;

                            if (!firstDigit.HasValue)
                            {
                                firstDigit = digit;
                            }

                            lastDigit = digit;

                            i += wordNumber.Key.Length - 1;
                            break;
                        }
                    }

                }
                if (firstDigit.HasValue && lastDigit.HasValue)
                {
                    int calibrationValue = firstDigit.Value *10 + lastDigit.Value;
                    totalSum += calibrationValue;
                }
            }

            Console.WriteLine(totalSum);
            Console.ReadLine();
        }
    }
}
