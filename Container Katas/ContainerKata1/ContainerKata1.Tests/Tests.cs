using ContainerKata1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerKata1.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FileExists_ShouldReturnTrue()
        {
            Sorter sort = new Sorter();

            var result = sort.GetFile();

            Assert.AreNotEqual(null, result);
        }

    }
}
