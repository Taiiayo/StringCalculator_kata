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
            
                
            
            if (ints.Count == 1)
            {
                return int.Parse(numbers);
            }
            else if(ints.Count > 1)
            {
                var intArr = ints.Select(int.Parse).ToArray();
                return intArr.Sum();
            }


            return 5;
        }
    }
}
