using NUnit.Framework;
using StringCalculator2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator2.Tests
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
        public void GivenRandomNumbers_ShouldReturnSum()
        {
            Calculator calc = new Calculator();

            Random rand = new Random();
            List<int> randomNumbers = new List<int>();
            int upperBounds = rand.Next(1, 1001);
            string numbers = "";

            for (int i = 0; i < upperBounds; i++)
            {
                randomNumbers.Add(rand.Next(1, 1000));
            }

            foreach (int num in randomNumbers)
            {
                if (numbers == "")
                    numbers = Convert.ToString(num);
                else
                    numbers += "," + num;
            }

            var result = calc.Add(numbers);

            Assert.AreEqual(randomNumbers.Sum(), result);
        }

        [Test]
        public void GivenOneTwoThreeAndNewLine_ShouldReturnSix()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("1\n2,3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void GivenOneTwoThreeAndDifferentDelimiter_ShouldReturnSix()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("//;\n1\n2,3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_GivenNegative_ShouldThrowException()
        {
            Calculator calc = new Calculator();

            Assert.That(() => calc.Add("-100,-300"), Throws.Exception);


        }
    }
}
