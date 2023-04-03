using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoltFood.Core.Enums;

namespace BoltFood.Core.Models.BaseModel
{
    public class Product:BaseModel
    {
        private static int _id = 0;
        public string ProductName { get; set; }
        public int Price { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public Restaurant Restaurant { get; set; }

        public Product(string name,int price,ProductCategory category,Restaurant restaurant)
        {
            _id++;
            Id= _id;
            ProductName = name;
            Price = price;
            Restaurant = restaurant;
            ProductCategory = category;
        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            return $"Id: {Id}    Product Name: {ProductName}    Restaurant: {Restaurant.RestaurantName}    Category: {ProductCategory}    Price: {Price}";
        }
    }
}
