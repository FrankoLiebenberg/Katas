using System.Collections.Generic;
using NUnit.Framework;

namespace ContainerKata4.Tests
{
    [TestFixture]
    public class Inputs
    {
        readonly string[] _arrOriginalInput =
        {
            "A",
            "CBACBACBACBACBA",
            "CCCCBBBBAAAA",
            "ACMICPC",
            "end"
        };

        [Test]
        public void GivenTextFileReader_ShouldReturnOriginalTestInputData()
        {
            FileReader fr = new FileReader();

            Assert.AreEqual(_arrOriginalInput, fr.GetInput());
        }

        [Test]
        public void GivenCsvReader_ShouldReturnOriginalTestInputData()
        {
            CsvReader cr = new CsvReader();

            Assert.AreEqual(_arrOriginalInput, cr.GetInput());
        }
    }

    [TestFixture]
    public class StackerTests
    {

        [Test]
        public void GivenInputs_ShouldReturnIntList()
        {
            Stacker stacker = new Stacker();
            var result = stacker.GetCharacterCounts("CBACBACBACBACBA");

            Dictionary<string, int> expectedOutput = new Dictionary<string, int> { { "C", 5 }, { "B", 5 }, { "A", 5 } };

            Assert.AreEqual(expectedOutput, result);

        }

        [Test]
        public void GivenInput_ShouldReturnThree()
        {
            Stacker stacker = new Stacker();
            var result = stacker.StackContainers("CBACBACBACBACBA");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void GivenInput_ShouldReturnOne()
        {
            Stacker stacker = new Stacker();
            var result = stacker.StackContainers("AAAA");

            Assert.AreEqual(1, result);
        }

        [Test]
        public void GivenLongerInput_ShouldReturnOne()
        {
            Stacker stacker = new Stacker();
            var result = stacker.StackContainers("CCCCBBBBAAAA");

            Assert.AreEqual(1, result);
        }

        [Test]
        public void GivenMixedInput_ShouldReturnOne()
        {
            Stacker stacker = new Stacker();
            var result = stacker.StackContainers("ACMICPC");

            Assert.AreEqual(4, result);
        }

        [Test]
        public void GivenCSVReader_ShouldReturnExpectedOutputMessages()
        {
            CsvReader reader = new CsvReader();
            Stacker stacker = new Stacker();
            var result = stacker.RunInput(reader);

            List<string> expected = new List<string> { "Case 1: 1", "Case 2: 3", "Case 3: 1", "Case 4: 4" };

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenFileReader_ShouldReturnExpectedOutputMessages()
        {
            FileReader reader = new FileReader();
            Stacker stacker = new Stacker();
            var result = stacker.RunInput(reader);

            List<string> expected = new List<string> { "Case 1: 1", "Case 2: 3", "Case 3: 1", "Case 4: 4" };

            Assert.AreEqual(expected, result);
        }
    }
}
