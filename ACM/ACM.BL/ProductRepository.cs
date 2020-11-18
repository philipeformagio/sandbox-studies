using System;
using System.Collections.Generic;
using System.Text;

namespace ACM.BL
{
    public class ProductRepository
    {
        /// <summary>
        /// Retrieve one product.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product Retrieve(int productId)
        {
            Object obj = new object();
            Product product = new Product();
            Console.WriteLine($"Object: {obj.ToString()}");
            Console.WriteLine($"Object: {product.ToString()}");
            if (productId == 2)
            {
                product.ProductName = "Sunflowers";
                product.ProductDescription = "Assorted Siz";
                product.CurrentPrice = 15.96M;
            }
            return product;
        }

        /// <summary>
        /// Retrive all products
        /// </summary>
        /// <returns></returns>
        public List<Product> Retrieve()
        {
            return new List<Product>();
        }

        /// <summary>
        /// Saves the current customer.
        /// </summary>
        /// <returns></returns>
        public bool Save(Product product)
        {
            var success = true;
            if (product.HasChanges && product.IsValid)
            {
                if (product.IsNew)
                {
                    // insert here
                }
                else
                {
                    // update here
                }
            }
            return success;
        }
    }
}
