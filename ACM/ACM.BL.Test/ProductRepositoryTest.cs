using NUnit.Framework;

namespace ACM.BL.Test
{
    public class ProductRepositoryTest
    {
        [Test]
        public void RetrieveTest()
        {
            //-- Arrange
            var productRepository =  new ProductRepository();
            var expected = new Product(1)
            {
                ProductName = "Sunflowers",
                ProductDescription = "Assorted Siz",
                CurrentPrice = 15.96M
            };

            //-- Act
            var actual = productRepository.Retrieve(2);

            //-- Assert
            Assert.AreEqual(expected.ProductName, actual.ProductName);
            Assert.AreEqual(expected.ProductDescription, actual.ProductDescription);
            Assert.AreEqual(expected.CurrentPrice, actual.CurrentPrice);

        }
    }
}
