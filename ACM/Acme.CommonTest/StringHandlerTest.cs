using Acme.Common;
using NUnit.Framework;

namespace Acme.CommonTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InsertSpacesTestValid()
        {
            //-- Arrange
            var source = "SonicScrewdriver";
            var expected = "Sonic Screwdriver";

            //-- Act
            var actual = source.InsertSpaces();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InsertSpacesTestWithExistingSpace()
        {
            //-- Arrange
            var source = "Sonic Screwdriver";
            var expected = "Sonic Screwdriver";

            //-- Act
            var actual = source.InsertSpaces();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}