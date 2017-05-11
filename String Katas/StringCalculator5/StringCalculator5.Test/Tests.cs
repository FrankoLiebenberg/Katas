using NUnit.Framework;
using StringCalculator5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator5.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void GivenEmptyString_ShouldReturnZero()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("");

            Assert.AreEqual(0, result);
        }

        [Test]
        public void GivenOne_ShouldReturnOne()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("1");

            Assert.AreEqual(1, result);
        }

        [Test]
        public void GivenOneAndTwo_ShouldReturnThree()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("1,2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void GivenRandomSeededAmountBetweenOneAndAThousand_ShouldReturnSum()
        {
            Calculator calc = new Calculator();
            Random rand = new Random(1337);

            int upperBounds = rand.Next(0, 1001);
            List<int> lstRandomNumbers = new List<int>();
            string numbers = "";

            for (int i = 0; i < upperBounds; i++)
            {
                lstRandomNumbers.Add(rand.Next(0, 1001));
            }

            foreach (int i in lstRandomNumbers)
            {
                if (numbers != "")
                    numbers += "," + i;
                else
                    numbers = "" + i;
            }

            var result = calc.Add(numbers);

            Assert.AreEqual(lstRandomNumbers.Sum(), result);
        }

        [Test]
        public void GivenOneAndTwoAndThreeWithNewLine_ShouldReturnSix()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("1,2\n3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void GivenOneAndTwoAWithCustomDelimiter_ShouldReturnThree()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("//;\n1;2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void GivenOneAndTwoAWithCustomDelimiters_ShouldReturnSix()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("//[;][.]\n1;2.3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void GivenOneAndTwoAWithCustomLengthDelimiters_ShouldReturnSix()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("//[;;;;][...]\n1;;;;2...3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void GivenNegative_ShouldThrowException()
        {
            Calculator calc = new Calculator();

            Assert.That(() => calc.Add("-100,-200"), Throws.Exception.Message.Contains("Negatives not allowed: -100,-200"));

        }
    }
}
