using LinqSamples.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace LinqSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //var product = new Product();

            //var products = product.GetProductList().Where(x => x.Price > 4);

            //foreach (var prod in products)
            //{
            //    Console.WriteLine(prod.Name);
            //}

            //new Product().GetProductList().Where(x => x.Price > 4).ToList().ForEach(x =>
            //{
            //    Console.WriteLine(x.Name);
            //    Console.WriteLine(x.Price);
            //});

            var products = new Product().GetProductList();

            var obj = products.Where(p => p.Name.StartsWith("A") || p.Name.EndsWith("o"))
                               //.Select(p => new { p.Name, p.Price })
                               //.Select(p => new SelectedProduct { Name = p.Name, Price = p.Price }) //same result as previous line but now it is typed
                               .Select(p => new SelectedProduct { Name = p.Name.Substring(0, 3).Insert(3, "-PHILIPE"), Price = p.Price }) //just playing around
                               .ToList();

            obj.ForEach(item =>
            {
                Console.WriteLine(JsonConvert.SerializeObject(item));
                Console.WriteLine(" ----------------------- ");
            });

            Console.ReadKey();
        }
    }

    public class SelectedProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
