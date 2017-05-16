using NUnit.Framework;
using StringCalculator6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculators.Tests
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
        public void GivenRandomAmountOfNumbers_ShouldReturnSum()
        {
            Calculator calc = new Calculator();
            Random rand = new Random(1234);
            List<int> lstRandomNumbers = new List<int>();
            string message = "";

            for (int i = 0; i < rand.Next(0, 1001); i++)
            {
                lstRandomNumbers.Add(rand.Next(0, 1001));
            }

            foreach (int i in lstRandomNumbers)
            {
                if (message == "")
                    message = "" + i;
                else
                    message += "," + i;
            }


            var result = calc.Add(message);

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
        public void GivenOneAndTwoWithCustomDelimiter_ShouldReturnThree()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("//;\n1;2");

            Assert.AreEqual(3, result);
        }


        [Test]
        public void GivenNegatives_ShouldThrowException()
        {
            Calculator calc = new Calculator();

            Assert.That(() => calc.Add("-100,-200"), Throws.Exception.Message.Contains("Negatives not allowed: -100,-200"));
        }

        [Test]
        public void GivenOneAndOneThousand_ShouldReturnOneThousandAndOne()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("1,1000");

            Assert.AreEqual(1001, result);
        }

        [Test]
        public void GivenOneAndOneThousandAndOne_ShouldReturnOne()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("1,1001");

            Assert.AreEqual(1001, result);
        }

    }
}
