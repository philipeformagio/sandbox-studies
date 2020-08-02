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

        public List<Product> GetFruits()
        {
            _products.Add(new Product() { Id = Guid.NewGuid(), Name = "Banana", Quantity = 5, Price = 2, ValidUntil = DateTime.Now.AddDays(5), Category = "Frutas" });
            _products.Add(new Product() { Id = Guid.NewGuid(), Name = "Morango", Quantity = 5, Price = 25, ValidUntil = DateTime.Now.AddDays(2), Category = "Frutas" });
            _products.Add(new Product() { Id = Guid.NewGuid(), Name = "Acabaxi", Quantity = 4, Price = 4, ValidUntil = DateTime.Now.AddDays(4), Category = "Frutas" });
            _products.Add(new Product() { Id = Guid.NewGuid(), Name = "Pera", Quantity = 12, Price = 12, ValidUntil = DateTime.Now.AddDays(3), Category = "Frutas" });
            _products.Add(new Product() { Id = Guid.NewGuid(), Name = "Melao", Quantity = 45, Price = 5, ValidUntil = DateTime.Now.AddYears(1), Category = "Frutas" });

            return _products;
        }

        public List<Product> GetEletronics()
        {
            _products.Add(new Product() { Name = "IPhone", Price = 8000, Category = "Eletronicos" });
            _products.Add(new Product() { Name = "IPhone", Price = 10000, Category = "Eletronicos" });
            _products.Add(new Product() { Name = "Galaxy S7 Edge", Price = 2000, Category = "Eletronicos" });
            _products.Add(new Product() { Name = "Pen Drive", Price = 100, Category = "Eletronicos" });

            return _products;
        }

        public List<Product> GetCloths()
        {
            _products.Add(new Product() { Name = "Jeans", Price = 40, Category = "Cloths" });
            _products.Add(new Product() { Name = "Shoes", Price = 100, Category = "Cloths" });
            _products.Add(new Product() { Name = "T-Shirt", Price = 90, Category = "Cloths" });

            return _products;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime ValidUntil { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
