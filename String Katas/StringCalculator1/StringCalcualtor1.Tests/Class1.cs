using NUnit.Framework;
using StringCalculator1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalcualtor1.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Add_GivenEmptyString_ShouldReturnZero()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("");

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_GivenOne_ShouldReturnOne()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("1");

            Assert.AreEqual(1, result);
        }

        [Test]
        public void Add_GivenOneAndTwo_ShouldReturnThree()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("1,2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_GivenOneAndTwoAndThree_ShouldReturnSix()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("1,2,3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_GivenRandomAmountOfNumbers_ShouldReturnSum()
        {
            Calculator calc = new Calculator();

            Random rand = new Random();

            string suppliedText = "";

            int upperBound = rand.Next(0 , 101);

            List<int> randomNumbers = new List<int>();

            for(int i = 0; i < upperBound; i++ )
            {
                randomNumbers.Add(rand.Next(0, 101));
            }

            int expectedResult = randomNumbers.Sum();

            foreach(int num in randomNumbers)
            {
                if (suppliedText == "")
                {
                    suppliedText = "" + num;
                }
                else
                {
                    suppliedText = suppliedText + "," + num;
                }
            }

            var result = calc.Add(suppliedText);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void Add_GivenOneAndTwoWithNewLine_ShouldReturnThree()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("1,\n2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_GivenOneAndTwoWithOneNonCommaDelimiter_ShouldReturnThree()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("//.\n1.\n2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_GivenOneAndTwoWithTwoNonCommaDelimiters_ShouldReturnThree()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("//\\\n1\\\n2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_GivenOneAndTwoWithThreeNonCommaDelimiters_ShouldReturnThree()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("//|||\n1|||\n2");

            Assert.AreEqual(3, result);
        }


        [Test]
        public void Add_GivenNegative_ShouldThrowException()
        {
            Calculator calc = new Calculator();

            Assert.That(() => calc.Add("-100,-300"), Throws.Exception);


        }

    }
}
