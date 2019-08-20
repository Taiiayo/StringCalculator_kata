using System;
using Xunit;
using StringCalculator_kata;

namespace StringCalc_kata
{
    public class StringCalculator_Test
    {
        [Fact]
        public void Add()
        {
            StringCalculator stringCalculator = new StringCalculator();

            var actualResult = stringCalculator.Add("");

            Assert.Equal(0, actualResult);
        }

        [Theory]
        [InlineData("1")]
        [InlineData("8")]
        [InlineData("10")]
        public void AddOne(string numbers)
        {
            StringCalculator stringCalculator = new StringCalculator();

            var actualResult = stringCalculator.Add(numbers);

            Assert.Equal(int.Parse(numbers), actualResult);
        }

        [Fact]
        public void AddTwo()
        {
            StringCalculator stringCalculator = new StringCalculator();

            var actualResult = stringCalculator.Add("22,13");

            Assert.Equal(35, actualResult);
        }

        [Fact]
        public void AddUnknown()
        {
            StringCalculator stringCalculator = new StringCalculator();

            var actualResult = stringCalculator.Add("13,2,24,45");

            Assert.Equal(84, actualResult);
        }

        [Fact]
        public void AddWithNewLineDelimiter()
        {
            StringCalculator stringCalculator = new StringCalculator();

            var actualResult = stringCalculator.Add("1\n2,3");

            Assert.Equal(6, actualResult);
        }

        [Fact]
        public void AddCustomDelimiter()
        {
            StringCalculator stringCalculator = new StringCalculator();

            var actualResult = stringCalculator.Add("//;\n1;2");

            Assert.Equal(3, actualResult);
        }

        [Fact]
        public void ThrowExceptionIfNegative()
        {
            StringCalculator stringCalculator = new StringCalculator();

            var ex = Assert.Throws<ArgumentException>(() => stringCalculator.Add("//;\n-11;-2"));

            Assert.Equal("negatives -11,-2 not allowed", ex.Message);
        }

        [Fact]
        public void IgnoreNumbersBiggerThanThousandAtSumming()
        {
            StringCalculator stringCalculator = new StringCalculator();

            var actualResult = stringCalculator.Add("//;\n1;2000");

            Assert.Equal(1, actualResult);
        }

        [Fact]
        public void AddAnyFormatDelimiter()
        {
            StringCalculator stringCalculator = new StringCalculator();

            var actualResult = stringCalculator.Add("//[***]\n1***2***3");

            Assert.Equal(6, actualResult);
        }
    }
}
