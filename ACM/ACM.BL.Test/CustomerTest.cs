using NUnit.Framework;

namespace ACM.BL.Test
{
    public class CustomerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FullNameTestValid()
        {
            // -- Arrange
            Customer customer = new Customer();
            customer.FirstName = "Bildo";
            customer.LastName = "Baggins";

            string expected = "Baggins, Bildo";

            // -- Act
            string actual = customer.FullName;

            // -- Assert

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FullNameFirstNameEmpty()
        {
            // -- Arrange
            Customer customer = new Customer();            
            customer.LastName = "Baggins";

            string expected = "Baggins";

            // -- Act
            string actual = customer.FullName;

            // -- Assert

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FullNameLastNameEmpty()
        {
            // -- Arrange
            Customer customer = new Customer();
            customer.FirstName = "Bildo";            

            string expected = "Bildo";

            // -- Act
            string actual = customer.FullName;

            // -- Assert

            Assert.AreEqual(expected, actual);
        }
    }
}