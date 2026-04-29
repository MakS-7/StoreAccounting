using System;
using ExamProject.DAL;
using ExamProject.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamProject;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            int n = 1;

            while (n != 0)
            {
                Console.WriteLine("1. Просмотреть все товары");
                Console.WriteLine("2. Поиск товара по id или части названия");
                Console.WriteLine("3. Поиск товаров по категории");
                Console.WriteLine("4. Поиск товаров по поставщику");
                Console.WriteLine("5. Добавить товар(ы)");
                Console.WriteLine("6. Изменить цену товара");
                Console.WriteLine("7. Изменить количество единиц товара");
                Console.WriteLine("8. Удалить товар");
                Console.WriteLine("9. Посмотреть общую стоимость всех товаров");
                Console.WriteLine("10. Топ 3 товара по стоимости");
                Console.WriteLine("11. Просмотреть количество видов товаров в каждой категории");
                Console.WriteLine("0. Выход\n");
                Console.WriteLine("Введите номер действия:");

                n = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (n)
                {
                    case 1:
                        {
                            EfCRUD.GetProducts();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Выберите способ поиска: 1. по id; 2. по названию");
                            int i = Convert.ToInt32(Console.ReadLine());
                            if (i == 1)
                            {
                                Console.WriteLine("Введите id:");
                                int id = Convert.ToInt32(Console.ReadLine());
                                EfSearchFilters.ProductSearchId(id);
                            }
                            else if (i == 2)
                            {
                                Console.WriteLine("Введите название или его часть:");
                                string name = Console.ReadLine();
                                EfSearchFilters.ProductSearchName(name);
                            }
                            else Console.WriteLine("Ошибка! Неверное значение!");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Введите id категории:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            EfSearchFilters.CategoryProducts(id);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Введите id поставщика:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            EfSearchFilters.SupplierProducts(id);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Выберите добавить: 1. Один товар; 2. Несколько");
                            int i = Convert.ToInt32(Console.ReadLine());
                            if (i == 1)
                            {
                                Product product = new Product();
                                Console.WriteLine("Введите название товара:");
                                product.Name = Console.ReadLine();
                                Console.WriteLine("Введите цену товара:");
                                product.Price = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите количество единиц товара:");
                                product.Quantity = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите id категории товара:");
                                product.CategoryId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите id поставщика товара:");
                                product.SupplierId = Convert.ToInt32(Console.ReadLine());

                                EfCRUD.AddProduct(product);
                            }
                            else if (i == 2) 
                            {
                                int j = 1;
                                List<Product> products = new List<Product>();
                                while (j != 0)
                                {
                                    Product product = new Product();
                                    Console.WriteLine("Введите название товара:");
                                    product.Name = Console.ReadLine();
                                    Console.WriteLine("Введите цену товара:");
                                    product.Price = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Введите количество единиц товара:");
                                    product.Quantity = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Введите id категории товара:");
                                    product.CategoryId = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Введите id поставщика товара:");
                                    product.SupplierId = Convert.ToInt32(Console.ReadLine());

                                    products.Add(product);

                                    Console.WriteLine("Добавить ещё товар? 1. Да; 0. Нет");
                                    j = Convert.ToInt32(Console.ReadLine());
                                }
                                EfCRUD.AddProducts(products);
                            }
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Введите id товара для изменения цены:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите новую цену товара:");
                            int price = Convert.ToInt32(Console.ReadLine());
                            EfCRUD.UpdateProductPrice(id, price);
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Введите id товара для изменения количества:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите новое количество товара:");
                            int quantity = Convert.ToInt32(Console.ReadLine());
                            EfCRUD.UpdateProductPrice(id, quantity);
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Введите id товара для удаления:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            EfCRUD.DeleteProduct(id);
                            break;
                        }
                    case 9:
                        {
                            EfReportStatistic.ProductPriceSum();
                            break;
                        }
                    case 10:
                        {
                            EfReportStatistic.ProductTopPrice();
                            break;
                        }
                    case 11:
                        {
                            EfReportStatistic.GroupCategory();
                            break;
                        }
                    case 0:
                        {
                            n = 0;
                            Console.WriteLine("До свидания!");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Этого значения нет в списке(");
                            break;
                        }
                }
                
                Console.WriteLine("Нажмите Enter чтобы продолжить:");
                Console.ReadLine();
                Console.Clear();
            }




        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}