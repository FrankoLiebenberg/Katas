using NUnit.Framework;
using StringCalculator3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator3.Tests
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
        public void GivenOneandTwo_ShouldReturnThree()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("1,2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void GivenOneandTwoandThree_ShouldReturnSix()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("1,2,3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void GivenRandomNumberOfNumbers_ShouldReturnSum()
        {
            Calculator calc = new Calculator();
            Random rand = new Random();
            List<int> randomNumbers = new List<int>();
            int upperBound = rand.Next(1, 10001);
            string numbers = "";

            for (int i = 0; i < upperBound; i++)
            {
                randomNumbers.Add(rand.Next(1, 1000));
            }

            foreach(int num in randomNumbers)
            {
                if (numbers == "")
                    numbers += Convert.ToString(num);

                else
                    numbers += "," + num;
            }

            var result = calc.Add(numbers);

            Assert.AreEqual(randomNumbers.Sum(), result);
        }

        [Test]
        public void GivenOneandTwoandThreeAndNewLine_ShouldReturnSix()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("1\n2,3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void GivenOneandTwoandThreeWithCustomDelimiter_ShouldReturnSix()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("//;\n1;2;3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void GivenNegative_ShouldThrowException()
        {
            Calculator calc = new Calculator();

            Assert.That(() => calc.Add("-100"), Throws.Exception);


        }

        [Test]
        public void GivenNegatives_ShouldThrowException()
        {
            Calculator calc = new Calculator();

            Assert.That(() => calc.Add("-100,-200"), Throws.Exception);


        }

        [Test]
        public void GivenLargerThan1000_ShouldBeIgnored()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("1001,1");

            Assert.AreEqual(1, result);

        }

        [Test]
        public void GivenOneAndTwoWithMultipleDelimiters_ShouldReturnThree()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("//[;;;]\n1;;;2");

            Assert.AreEqual(3, result);

        }

        [Test]
        public void GivenOneAndTwoAndThreeWithDifferentDelimiters_ShouldReturnSix()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("//[;][!]\n1;2!3");

            Assert.AreEqual(6, result);

        }

        [Test]
        public void GivenOneAndTwoAndThreeWithDifferentDelimitersLongerThanOneChar_ShouldReturnSix()
        {
            Calculator calc = new Calculator();

            var result = calc.Add("//[;;;][!!!]\n1;;;2!!!3");

            Assert.AreEqual(6, result);

        }

    }
}
