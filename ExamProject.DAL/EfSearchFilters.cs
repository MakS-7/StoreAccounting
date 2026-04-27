using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamProject.DAL
{
    public class EfSearchFilters
    {
        // Поиск товаров по фрагменту названия
        public void ProductSearchName(string ProductName)
        {
            using (var db = new MyPostgresContext())
            {
                string name = $"%{ProductName}%";
                var products = db.Products.FromSqlRaw("SELECT * FROM Products WHERE Name LIKE {0}", name).ToList();
                Console.WriteLine($"Товары с фрагментом в названии: {ProductName}");
                foreach (var p in products)
                {
                    Console.WriteLine($"{p.Id}. {p.Name} | ID категории: {p.CategoryId} - цена: {p.Price} | количество: {p.Quantity}");
                }
            }
        }
        // Поиск товара по id
        public void ProductSearchId(int id)
        {
            using (var db = new MyPostgresContext())
            {
                var products = db.Products.FromSqlRaw("SELECT * FROM Products WHERE Id={0}", id).ToList();
                Console.WriteLine($"Товары с id: {id}");
                foreach (var p in products)
                {
                    Console.WriteLine($"{p.Id}. {p.Name} | ID категории: {p.CategoryId} - цена: {p.Price} | количество: {p.Quantity}");
                }
            }
        }

        // Фильтр товаров по категории
        public void CategoryProducts(int categoryId)
        {
            using (var db = new MyPostgresContext())
            {
                var products = db.Products.FromSqlRaw("SELECT * FROM Products WHERE CategoryId={0}", categoryId).ToList();
                Console.WriteLine($"Товары из категории с id: {categoryId}");
                foreach (var p in products)
                {
                    Console.WriteLine($"{p.Id}. {p.Name} - цена: {p.Price} | количество: {p.Quantity}");
                }
            }
        }
        //Фильтр товаров по поставщику
        public void SupplierProducts(int supplierId)
        {
            using (var db = new MyPostgresContext())
            {
                var products = db.Products.FromSqlRaw("SELECT * FROM Products WHERE SupplierId={0}", supplierId).ToList();
                Console.WriteLine($"Товары поставщика с id: {supplierId}");
                foreach (var p in products)
                {
                    Console.WriteLine($"{p.Id}. {p.Name} - цена: {p.Price} | количество: {p.Quantity}");
                }
            }
        }
    }
}
