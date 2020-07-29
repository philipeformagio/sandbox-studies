using System;
using System.Collections.Generic;

namespace LinqSamples.Domain.Entities
{
    public class Product
    {
        private List<Product> _products;
        public Product()
        {
            _products = new List<Product>();
        }

        public List<Product> GetProductList()
        {
            _products.Add(new Product() { Id = Guid.NewGuid(), Name = "Banana", Quantity = 5, Price = 2, ValidUntil = DateTime.Now.AddDays(5) });
            _products.Add(new Product() { Id = Guid.NewGuid(), Name = "Morango", Quantity = 5, Price = 25, ValidUntil = DateTime.Now.AddDays(2) });
            _products.Add(new Product() { Id = Guid.NewGuid(), Name = "Acabaxi", Quantity = 4, Price = 1, ValidUntil = DateTime.Now.AddDays(4) });
            _products.Add(new Product() { Id = Guid.NewGuid(), Name = "Pera", Quantity = 12, Price = 12, ValidUntil = DateTime.Now.AddDays(3) });
            _products.Add(new Product() { Id = Guid.NewGuid(), Name = "Melao", Quantity = 5, Price = 35, ValidUntil = DateTime.Now.AddYears(1) });

            return _products;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime ValidUntil { get; set; }
        public decimal Price { get; set; }
    }
}
