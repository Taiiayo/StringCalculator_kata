using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator_kata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            int[] intArr = GetIntegerArray(numbers);

            if (!ArrayContainsNegatives(intArr))
            {
                if (intArr.Length == 1 && intArr.First() < 1000)
                {
                    return int.Parse(numbers);
                }
                else if (intArr.Length > 1)
                {
                    return intArr.Where(x => x < 1000).Sum();
                }
            }
            return 5;
        }

        public bool ArrayContainsNegatives(int[] intArr)
        {
            List<int> negativeNumbers = intArr.Where(x => x < 0)
                                              .ToList();
            if (negativeNumbers.Any())
            {
                throw new ArgumentException(string.Format("negatives {0} not allowed",
                                                          string.Join(",",
                                                                      negativeNumbers)));
            }
            else
            {
                return false;
            }
        }

        public int[] GetIntegerArray(string numbers)
        {
            List<string> intsInStringFormat = new List<string>();

            if (numbers.StartsWith("//"))
            {
                if (numbers.StartsWith("//["))
                {
                    intsInStringFormat = SplitByUnknownDelimiter(numbers, intsInStringFormat);
                }
                else
                {
                    intsInStringFormat = SplitByCustomDelimiter(numbers, intsInStringFormat);
                }
            }
            else
            {
                intsInStringFormat.AddRange(numbers.Split(new Char[] { ',', '\n' }));
            }

            return intsInStringFormat.Select(int.Parse).ToArray();
        }

        public List<string> SplitByCustomDelimiter(string numbers, List<string> intsInStringFormat)
        {
            char delimiter = numbers.Skip(2).First();
            numbers = numbers.Split("\n").Last();
            intsInStringFormat.AddRange(numbers.Split(delimiter));
            return intsInStringFormat;
        }

        public List<string> SplitByUnknownDelimiter(string numbers, List<string> intsInStringFormat)
        {
            IEnumerable<char> delimiters = numbers.Skip(3);
            delimiters = delimiters.TakeWhile(i => i != ']');
            string delimiter = string.Join("", delimiters);
            numbers = numbers.Split("\n").Last();
            intsInStringFormat.AddRange(numbers.Split(delimiter.ToArray()));
            return intsInStringFormat;
        }
    }
}
