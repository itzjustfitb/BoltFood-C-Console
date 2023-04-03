using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BoltFood.Core.Enums;
using BoltFood.Core.Models.BaseModel;
using BoltFood.Core.Repositories.RestaurantRepository;
using BoltFood.Data.Repositories.RestaurantRepository;
using BoltFood.Service.Interfaces;

namespace BoltFood.Service.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurant = new RestaurantRepository();
        public async Task<string> CreateAsync(int limit,RestaurantCategory category,string name)
        {
            if (limit < 10 || limit > 20) 
            {
                Console.ForegroundColor= ConsoleColor.Red;
                return "Restaurant limit must be between 10-20!";
            }

            Restaurant restaurant = new Restaurant(category,limit,name);
            Console.ForegroundColor= ConsoleColor.Green;
            await _restaurant.AddAsync(restaurant);
            return "Succesfully Created";
        }

        public async Task<string> DeleteAsync(int id)
        {
            Restaurant restaurant = await _restaurant.GetAsync(x => x.Id == id);

            if (restaurant==null)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                return "Restaurant is not found";
            }
            await _restaurant.RemoveAsync(restaurant);
            Console.ForegroundColor= ConsoleColor.Green;
            return "Succesfully Removed";
        }

        public async Task<List<Restaurant>> GetAllAsync()
        {
            Console.ForegroundColor= ConsoleColor.Cyan;
            return await _restaurant.GetAllAsync();
        }

        public async Task<Restaurant> GetAsync(int id)
        {
            Restaurant restaurant = await _restaurant.GetAsync(x => x.Id == id) ;
            if (restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restaurant is not found!");
            }
            return restaurant;

        }

        public async Task<List<Product>> GetProductByRestaurantAsync(string name)
        {
            Restaurant restaurant = await _restaurant.GetAsync(x => x.RestaurantName == name);
            if (restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restaurant is not found!");
                return null;
            }

            Console.ForegroundColor= ConsoleColor.Green;
            return restaurant.Products;
        }

        public async Task<string> UpdateAsync(int id,int limit)
        {
            Restaurant restaurant = await _restaurant.GetAsync(x => x.Id == id);
            if (restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restaurant is not found!");
            }
            if (limit < 10 || limit > 20) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restaurant limit must be between 10-20!");
            }

            restaurant.ProductLimit= limit;
            await _restaurant.UpdateAsync(restaurant);

            Console.ForegroundColor = ConsoleColor.Green;
            return "Succesfully Updated";
           
        }
    }
}
