using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_22_Northwind
{
    class Program
    {
        static List<Product> products;
        static List<Category> categories;
        static void Main(string[] args)
        {
            using (var db = new NorthwindEntities())
            {
                products = db.Products.ToList();
                categories = db.Categories.ToList();
            }
            Console.WriteLine("=== PRODUCTS ===");
            products.ForEach(p =>
            {
                Console.WriteLine($"ID: {p.ProductID, -5} name: {p.ProductName, - 35} price: {p.UnitPrice, - 10} stock: {p.UnitsInStock, -5}");
            });

            //categories
            Console.WriteLine("\n=== CATEGORIES ===");
            categories.ForEach(c =>
            {
                Console.WriteLine($"ID: {c.CategoryID, -5} name: {c.CategoryName, - 20} Description: {c.Description}");
            });

            //products with certain category
            Console.WriteLine("\n=== PRODUCTS IN BEVERAGES CATEGORY ===");
            products.ForEach(p =>
            {   
                if (p.Category.CategoryName.Equals("Beverages"))
                {
                    Console.WriteLine($"ID: {p.ProductID,-5} name: {p.ProductName,-35} Category: {p.Category.CategoryName,-20}" +
                    $" Price: {p.UnitPrice,-10}");
                }
            });

            Console.WriteLine("\n=== PRODUCTS IN SEAFOOD CATEGORY ===");
            products.ForEach(p =>
            {
                if (p.Category.CategoryName.Equals("Seafood"))
                {
                    Console.WriteLine($"ID: {p.ProductID,-5} name: {p.ProductName,-35} Category: {p.Category.CategoryName,-20}" +
                    $" Price: {p.UnitPrice,-10}");
                }
            });
        }
    }
}
