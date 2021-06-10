using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
             ProductTest();
            //CategortTest();
            
        }

        private static void CategortTest()
        {
            CategoryMenager categoryMenager = new CategoryMenager(new EfCategoryDal());
            foreach (var category in categoryMenager.GetCategories())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductMenager productMenager = new ProductMenager(new EfProductDal());
            foreach (var item in productMenager.GetProductDetails())
            {
                Console.WriteLine(item.ProductName + "/" + item.CategoryName);
            }
        }
    }
}
