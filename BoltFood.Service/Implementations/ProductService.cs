using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoltFood.Core.Enums;
using BoltFood.Core.Models.BaseModel;
using BoltFood.Core.Repositories.RestaurantRepository;
using BoltFood.Data.Repositories.RestaurantRepository;
using BoltFood.Service.Interfaces;

namespace BoltFood.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IRestaurantRepository _product = new RestaurantRepository();
        public async Task<string> CreateAsync(string productName, int price,ProductCategory category,string restaurantname)
        {
            Restaurant restaurant = await _product.GetAsync(x => x.RestaurantName == restaurantname);

            if (restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Restaurant is not valid!";
            }

            if (restaurant.ProductLimit == restaurant.Products.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Restaurant is full!";
            }

            Product product=new Product(productName,price, category,restaurant);
            restaurant.Products.Add(product);
            Console.ForegroundColor = ConsoleColor.Green;
            return "Succesfully Created";
        }

        public async Task<string> DeleteAsync(int id)
        {
            List<Restaurant> restaurants = await _product.GetAllAsync();

            foreach (var item in restaurants)
            {
                Product product = item.Products.Find(x => x.Id == id);
                if (product != null)
                {
                    item.Products.Remove(product);
                    Console.ForegroundColor = ConsoleColor.Green;
                    return "Succesfully Removed";
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            return "Product is not found!";
        }

        public async Task<List<Product>> GetAllAsync()
        {
            List<Restaurant> restaurants = await _product.GetAllAsync();

            List<Product> products = new List<Product>();
            foreach(Restaurant item in restaurants)
            {
                products.AddRange(item.Products);
            }
            return products;
        }

        public async Task<Product> GetAsync(int id)
        {
            List<Restaurant> restaurants = await _product.GetAllAsync();
            foreach (var item in restaurants)
            {
                Product product = item.Products.Find(x => x.Id == id);
                if (product != null)
                {
                    return product;
                }
            }
            return null;
        }

        public async Task<string> UpdateAsync(int id, string productName, int price)
        {
            List<Restaurant> restaurants = await _product.GetAllAsync();

            foreach (var item in restaurants)
            {
                Product product = item.Products.Find(x => x.Id == id);
                if (product != null)
                {
                    product.ProductName = productName;
                    product.Price = price;
                    Console.ForegroundColor = ConsoleColor.Green;
                    return "Succesfully Updated";
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            return "Product is not found!";
        }
    }
}
