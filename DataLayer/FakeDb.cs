using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DataLayer
{
    public static class FakeDb
    {
        private static List<Category> _categories = new List<Category>();
        private static List<Product> _products = new List<Product>();
        private static string[] _words;
        private static Random _rnd = new Random();

        static FakeDb()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream("DataLayer.words.txt");
            var reader = new StreamReader(stream);
            _words = reader.ReadToEnd().Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 1; i <= 20; i++)
            {
                Category c = new Category();
                c.Id = i;
                c.Name = _words[_rnd.Next(_words.Length)];
                _categories.Add(c);
                for (int j = 1; j <= 20; j++)
                {
                    Product p = new Product();
                    p.Id = j;
                    p.CategoryId = i;
                    p.Name = _words[_rnd.Next(_words.Length)];
                    _products.Add(p);
                }

            }


        }

        public static IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public static Category GetCategoryById(int id)
        {
            return _categories.First(c => c.Id == id);
        }

        public static IEnumerable<Product> GetProductsByCategoryId(int id)
        {
            return _products.Where(p => p.CategoryId == id);
        }
    }
}