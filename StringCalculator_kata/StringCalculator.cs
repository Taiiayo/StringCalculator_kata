using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator_kata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {            
            List<string> ints = new List<string>();
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            else if (numbers.StartsWith("//"))
            {
                char delimiter = numbers.Skip(2).First();
                numbers = numbers.Split("\n").Last();
                ints.AddRange(numbers.Split(delimiter));
            }
            else
            {
                ints.AddRange(numbers.Split(new Char[] { ',', '\n' }));
            }

            var intArr = ints.Select(int.Parse).ToArray();

            var negativeNumbers = intArr.Where(x => x < 0)
                                              .ToList();
            if (negativeNumbers.Any())
            {
                throw new ArgumentException(string.Format("negatives {0} not allowed",
                                                          string.Join(",",
                                                                      negativeNumbers)));
            }

            if (intArr.Length == 1)
            {
                return int.Parse(numbers);
            }
            else if(intArr.Length > 1)
            {
                return intArr.Sum();
            }


            return 5;
        }
    }
}
