using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator_kata
{
    public class StringCalculator
    {
        private const char delimiter = ',';

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var ints = numbers.Split(delimiter).ToList();
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
