using System;
using System.Collections.Generic;
using System.Text;

namespace ExamProject.DAL
{
    public class EfReportStatistic
    {
        // Сумма стоимости всех имеющихся товраов
        public static void ProductPriceSum()
        {
            using (var db = new MyPostgresContext())
            {
                var sum = db.Products.Sum(p => p.Price * p.Quantity);
                Console.WriteLine($"Стоимость всех товаров на складе: {sum}");
            }
        }

        // Топ 3 товара по стоимости (самые дорогие)
        public static void ProductTopPrice()
        {
            using (var db = new MyPostgresContext())
            {
                var products = db.Products.OrderByDescending(p => p.Price).ToList();
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"{products[i].Id}. {products[i].Name} | ID категории: {products[i].CategoryId} " +
                        $"- цена: {products[i].Price} | количество: {products[i].Quantity}");
                }
            }
        }

        // Группировка продуктов по категориям (категория - количество товаров)
        public static void GroupCategory()
        {
            using (var db = new MyPostgresContext())
            {
                var groups = db.Products.GroupBy(p => p.CategoryId).Select(g => new { g.Key, Count = g.Count() });
                foreach (var group in groups)
                {
                    Console.WriteLine($"ID категории: {group.Key} - видов товаров: {group.Count}");
                }
            }
        }
    }
}
