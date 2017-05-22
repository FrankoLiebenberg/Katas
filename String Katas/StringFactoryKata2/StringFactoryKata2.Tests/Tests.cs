using NUnit.Framework;
using StringFactoryKata2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringFactoryKata2.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void GivenEmpty_ShouldReturnZero()
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
        public void GivenOneAndTwoWithNewLine_ShouldReturnThree()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("1\n2");

            Assert.AreEqual(3, result);
        }


        [Test]
        public void GivenRandomNumbers_ShouldReturnSum()
        {
            Calculator calc = new Calculator();
            Random rand = new Random(1337);
            int upperBounds = rand.Next(0, 1001);
            List<int> lstNumbers = new List<int>();
            string message = "";

            for (int i = 0; i < upperBounds; i++)
            {
                lstNumbers.Add(rand.Next(0, 1001));
            }

            foreach (int i in lstNumbers)
            {
                if (message == "")
                {
                    message = "" + i;
                }
                else
                {
                    message += "," + i;
                }
            }

            var result = calc.Add(message);

            Assert.AreEqual(lstNumbers.Sum(), result);
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
        public void GivenOneAndOneThousandAndOne_ShouldReturnOne()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("1,1001");

            Assert.AreEqual(1, result);
        }

        [Test]
        public void GivenOneAndOneThousande_ShouldReturnOneThousandAndOne()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("1,1000");

            Assert.AreEqual(1001, result);
        }

        [Test]
        public void GivenOneAndTwoAndThreeWithCustomDelimiters_ShouldReturnSix()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("//[;][.]\n1;2.3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void GivenOneAndTwoAndThreeWithCustomDelimitersOfVaryingLength_ShouldReturnSix()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("//[;;][.....]\n1;;2.....3");

            Assert.AreEqual(6, result);
        }
    }
}
