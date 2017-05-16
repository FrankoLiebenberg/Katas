using NUnit.Framework;
using StringCalculator7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator7.Tests
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
        public void GivenRandomNumberOfNumbers_ShouldReturnSum()
        {
            Calculator calc = new Calculator();
            Random rand = new Random();
            int upperBounds = rand.Next(0, 1001);
            List<int> numberList = new List<int>();
            string message = "";

            for (int i = 0; i < upperBounds; i++)
            {
                numberList.Add(rand.Next(0, 1001));
            }

            foreach(int i in numberList)
            {
                if (message == "")
                    message = "" + i;
                else
                    message += "," + i;
            }


            var result = calc.Add(message);

            Assert.AreEqual(numberList.Sum(), result);
        }

        [Test]
        public void GivenOneAndTwoWithNewLine_ShouldReturnThree()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("1\n2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void GivenOneAndTwoWithCustomDelimiters_ShouldReturnThree()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("//;\n1;2");

            Assert.AreEqual(3, result);
        }

    }
}
