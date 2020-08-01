using LinqSamples.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

            //var products = new Product().GetProductList();

            //var obj = products.Where(p => p.Name.StartsWith("A") || p.Name.EndsWith("o"))
            //                   //.Select(p => new { p.Name, p.Price })
            //                   //.Select(p => new SelectedProduct { Name = p.Name, Price = p.Price }) //same result as previous line but now it is typed
            //                   .Select(p => new SelectedProduct { Name = p.Name.Substring(0, 3).Insert(3, "-PHILIPE"), Price = p.Price }) //just playing around
            //                   .ToList();

            //obj.ForEach(item =>
            //{
            //    Console.WriteLine(JsonConvert.SerializeObject(item));
            //});

            //var produtos = new Product().GetProductList();

            //var obj = produtos
            //            //.Where(p => p.ValidUntil.Year == 2021)
            //            .Select(p => new SelectedProduct { Name = p.Name, Price = p.Price, ExpiredDay = p.ValidUntil.Day })
            //            .ToList();

            //obj.ForEach(item =>
            //{
            //    Console.WriteLine(JsonConvert.SerializeObject(item));
            //});

            //var produtos = new Product().GetProductList();
            //List<Product> products = new List<Product>();

            ////var produto1 = produtos.First();
            ////var produto2 = produtos.FirstOrDefault();

            ////var produto1 = produtos.Last();
            ////var produto2 = produtos.LastOrDefault();

            //if (produtos.Any(p => p.Quantity > 10))
            //{
            //    Console.WriteLine("Has items with quantity greater than 10.");
            //}

            //produtos.ForEach(item =>
            //{
            //    Console.WriteLine(JsonConvert.SerializeObject(item));
            //});


            //var products1 = new Product().GetProductList();

            //var products2 = new List<Product>();
            //products2.Add(new Product() { Name = "Galaxy", Price = 2500 });
            //products2.Add(new Product() { Name = "IPhoneX", Price = 7900 });

            //products1.AddRange(products2);

            //products1.ForEach(x =>
            //{
            //    Console.WriteLine(JsonConvert.SerializeObject(x.Name));
            //});

            //int[] pairNumbers = { 2, 4, 6, 8, 10 };
            //int[] oddNumbers = { 1, 3, 5, 7, 9 };
            //int[] mixedNumbers = { 1, 2, 3, 4 };

            //var newListSameNumbers = mixedNumbers.Intersect(pairNumbers); //returns a new list with found same same numbers

            //var itemsThatDoestNotExistInTheOtherList = mixedNumbers.Except(pairNumbers); // returns a new list of not found items

            //Range
            //var sequence = Enumerable.Range(10, 3); // return a list starting at 10 and finishing at 12
            //var repeat = Enumerable.Repeat("Philipe", 10); // returns a new list of the first argument times the second argument


            //var products = new Product().GetFruits();
            //var pricestProduct = products.Max(p => p.Price); // pricest product in the list
            //var biggerQuantity = products.Max(p => p.Quantity); // bigger quantity product
            //var averagePrice = products.Average(p => p.Price); // average price of all product's price in the list
            //var minPrice = products.Min(p => p.Price); // minimum price in the list
            //var sum = products.Sum(p => p.Price); // total sum of all prices


            var fruitsList = new Product().GetFruits();
            var eletronicsList = new Product().GetEletronics();
            var clothsList = new Product().GetCloths();

            List<Product> allProducts = new List<Product>();
            allProducts.AddRange(fruitsList);
            allProducts.AddRange(eletronicsList);
            allProducts.AddRange(clothsList);

            //allProducts.ForEach(x =>
            //{
            //    Console.WriteLine(JsonConvert.SerializeObject(x));
            //});

            Console.WriteLine("----------------------------------");
            var result = (from p in allProducts
                         group p by p.Category into grouped
                         select new ProductByCategoryReport
                         {
                             CategoryName = grouped.Key,
                             MinPrice = grouped.Min(x => x.Price),
                             MaxPrice = grouped.Max(x => x.Price),
                             TotalPrice = grouped.Sum(x => x.Price)
                         }).OrderBy(x => x.CategoryName);

            foreach (var item in result)
            {
                Console.WriteLine(JsonConvert.SerializeObject(item));
            }


            Console.ReadKey();
        }
    }

    public class SelectedProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ExpiredDay { get; set; }
    }

    public class ProductByCategoryReport
    {
        public string CategoryName { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
