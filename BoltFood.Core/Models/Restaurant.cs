using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoltFood.Core.Enums;

namespace BoltFood.Core.Models.BaseModel
{
    public class Restaurant:BaseModel
    {
        private static int _id = 0;
        public string RestaurantName { get; set; }
        public RestaurantCategory Category { get; set; }
        public int ProductLimit { get; set; }
        public List<Product> Products { get; set; }

        public Restaurant(RestaurantCategory category,int limit,string name)
        {
            _id++;
            Id = _id;
            Products= new List<Product>();
            Category= category;
            ProductLimit = limit;
            RestaurantName= name;
        }

        public override string ToString()
        {
            Console.ForegroundColor= ConsoleColor.Cyan;
            return $"Id: {Id}    Restaurant Name: {RestaurantName}    Category: {Category}    Limit: {ProductLimit}";
        }

    }
}
