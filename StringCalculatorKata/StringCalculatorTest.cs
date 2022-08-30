using System;
using NUnit.Framework;
using StringCalculator;

namespace StringCalculator.Tests
{
    [TestFixture]
    [Category("StringCalculatorKata")]
    public class StringCalculatorTest
    {
        [TestCase("")]
        [TestCase(null)]
        public void AddReturnZeroWhenSuppliedEmptyOrNullString(string numbers)
        {
            var result = StringCalculator.Add(numbers);
            Assert.That(result, Is.EqualTo(0));
        }


        [TestCase("0", 0)]
        [TestCase("1", 1)]
        [TestCase("2", 2)]
        [TestCase("3", 3)]
        [TestCase("0,1,2,3,4,555", 565)]
        public void AddReturnNumberWhenSuppliedSingleNumberInString(string number, int expectedResult)
        {
            var result = StringCalculator.Add(number);
            Assert.That(result, Is.EqualTo(expectedResult));
        }


        [TestCase("1,2,3", 6)]
        [TestCase("3\n2", 5)]
        [TestCase("1\n2,3", 6)]
        [TestCase("1\n2\n3,4,5", 15)]
        public void AddReturSumWhenSuppliedNumbersInStringWithNewLineAsDelimiter(string numbers, int expectedResult)
        {
            var result = StringCalculator.Add(numbers);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("3,3", 6)]
        [TestCase("0,1", 1)]
        [TestCase("0,1,1", 2)]
        [TestCase("0,2", 2)]
        [TestCase("0,2,2", 4)]
        [TestCase("0,3", 3)]
        [TestCase("0,3,2", 5)]
        [TestCase("0,3,3", 6)]
        [TestCase("5,5,5", 15s)]
        public void AddReturnSumWhenSuppliedMultipleNumbersInString(string numbers, int expectedResult)
        {
            var result = StringCalculator.Add(numbers);
            Assert.That(result, Is.EqualTo(expectedResult));
        }


        [TestCase("0,3,1001", 3)]
        [TestCase("0,3,1000", 1003)]
        [TestCase("1,2,3,4,5", 15)]
        [TestCase("123,1000", 1123)]
        public void AddReturnSumByIgnoringMoreThanThousandWhenSuppliedMultipleNumbersInString(string numbers, int expectedResult)
        {
            var result = StringCalculator.Add(numbers);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("/\n4\\2\\", 6)]
        [TestCase("3//2;;/2\r", 7)]
        [TestCase("//*\n1*2", 3)]
        [TestCase("//;\n1;2", 3)]
        [TestCase("//;\n1;2;3;4;5;6;7;8;9;10", 55)]
        public void AddWhenGivenDefinedDelimiterUsesThatDelimiter(string input, int expectation)
        {
            var result = StringCalculator.Add(input);

            Assert.That(result, Is.EqualTo(expectation));
        }


        [TestCase("1,-1", -1)]
        [TestCase("22,3", 2)]
        [TestCase("-5,1", 6)]
        [TestCase("-10,1", 6)]
        public void AddThrowArgumentExceptionWhenSuppliedStringDoesNotMeetRule(string numbers, int beyondRuleNumber)
        {
            var exception = Assert.Throws<ArgumentException>(() => StringCalculator.Add(numbers));

            Assert.That(exception.Message, Is.EqualTo(string.Format("string contains [{0}], which does not meet rule. entered number should not negative.", beyondRuleNumber)));
        }
    }

}
