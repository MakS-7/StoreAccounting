using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using ExamProject.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamProject.DAL
{
    public class EfCRUD
    {
        // Добавление товара
        public void AddProduct(Product product)
        {
            using (MyPostgresContext db = new MyPostgresContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }

        // Добавление нескольких товаров
        public void AddProducts(IEnumerable<Product> products)
        {
            using (MyPostgresContext db = new MyPostgresContext())
            {
                foreach (Product product in products)
                {
                    db.Products.Add(product);
                }
                db.SaveChanges();
            }
        }

        // Получение товаров
        public void GetProducts()
        {
            using (MyPostgresContext db = new MyPostgresContext())
            {
                var products = db.Products.ToList();
                Console.WriteLine("Товары в БД:");
                foreach (Product p in products)
                {
                    Console.WriteLine($"{p.Id}. {p.Name} | ID категории: {p.CategoryId} - цена: {p.Price} | количество: {p.Quantity}");
                }
            }
        }

        // Редактирование цены товара
        public int UpdateProductPrice(string name, decimal newPrice)
        {
            using (var db = new MyPostgresContext())
            {
                string nameFragment = $"%{name}%";
                int numberOfRowUpdated = db.Database.ExecuteSqlRaw("UPDATE Products SET Price={0} WHERE Name LIKE {1}", newPrice, nameFragment);
                return numberOfRowUpdated;
            }
        }
        public int UpdateProductPrice(int id, decimal newPrice)
        {
            using (var db = new MyPostgresContext())
            {
                int numberOfRowUpdated = db.Database.ExecuteSqlRaw("UPDATE Products SET Price={0} WHERE Id={1}", newPrice, id);
                return numberOfRowUpdated;
            }
        }

        // Редактирование количество товара
        public int UpdateProductQuantity(string name, int newQuantity)
        {
            using (var db = new MyPostgresContext())
            {
                string nameFragment = $"%{name}%";
                int numberOfRowUpdated = db.Database.ExecuteSqlRaw("UPDATE Products SET Quantity={0} WHERE Name LIKE {1}", newQuantity, nameFragment);
                return numberOfRowUpdated;
            }
        }
        public int UpdateProductQuantity(int id, int newQuantity)
        {
            using (var db = new MyPostgresContext())
            {
                int numberOfRowUpdated = db.Database.ExecuteSqlRaw("UPDATE Products SET Quantity={0} WHERE Id={1}", newQuantity, id);
                return numberOfRowUpdated;
            }
        }

        // Удаление товара
        public int DeleteProduct(int id)
        {
            using (var db = new MyPostgresContext())
            {
                int numberOfRowDeleted = db.Database.ExecuteSqlRaw("DELETE FROM Products WHERE Id={0}", id);
                return numberOfRowDeleted;
            }
        }
        public int DeleteProduct(string name)
        {
            using (var db = new MyPostgresContext())
            {
                string nameFragment = $"%{name}%";
                int numberOfRowDeleted = db.Database.ExecuteSqlRaw("DELETE FROM Products WHERE Name LIKE {0}", nameFragment);
                return numberOfRowDeleted;
            }
        }
    }
}
