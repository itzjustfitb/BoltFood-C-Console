using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BoltFood.Core.Enums;
using BoltFood.Core.Models.BaseModel;
using BoltFood.Service.Interfaces;

namespace BoltFood.Service.Implementations
{
    public class MenuService : IMenuService
    {
        private readonly IRestaurantService _restaurantService = new RestaurantService();
        private readonly IProductService _productService = new ProductService();

        public async Task ShowMenuAsync()
        {
            Welcome();
            Show();

            int.TryParse(Console.ReadLine(), out int request);
            while (request != 0)
            {
                switch (request)
                {
                    case 1:
                        Console.Clear();
                        await CreateRestaurant();
                        break;
                    case 2:
                        Console.Clear();
                        await ShowAllRestaurant();
                        break;
                    case 3:
                        Console.Clear();
                        await ShowRestaurant();
                        break;
                    case 4:
                        Console.Clear();
                        await UpdateRestaurant();
                        break;
                    case 5:
                        Console.Clear();
                        await RemoveRestaurant();
                        break;
                    case 6:
                        Console.Clear();
                        await CreateProduct();
                        break;
                    case 7:
                        Console.Clear();
                        await ShowAllProducts();
                        break;
                    case 8:
                        Console.Clear();
                        await GetProductById();
                        break;
                    case 9:
                        Console.Clear();
                        await UpdateProduct();
                        break;
                    case 10:
                        Console.Clear();
                        await RemoveProduct();
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please choose valid option!");
                        break;
                }
                Show();
                int.TryParse(Console.ReadLine(), out request);
            }
        }
        private void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Welcome to BoltFood App");
            Thread.Sleep(1000);
            Console.Clear();

            while (true)
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Loading");
                    Thread.Sleep(100);
                    Console.Write(".");
                    Thread.Sleep(100);
                    Console.Write(".");
                    Thread.Sleep(100);
                    Console.Write(".");
                    Thread.Sleep(100);
                    Console.Write(".");
                    Console.Clear();
                }
                Console.Clear();
                break;
            }
        }
        private void Show()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("----------------");
            Thread.Sleep(100);
            Console.WriteLine("1.Create Restaurant");
            Thread.Sleep(100);
            Console.WriteLine("2.Show All Restaurant");
            Thread.Sleep(100);
            Console.WriteLine("3.Get Restaurant by Id");
            Thread.Sleep(100);
            Console.WriteLine("4.Update Restaurant");
            Thread.Sleep(100);
            Console.WriteLine("5.Remove Restaurant");
            Thread.Sleep(100);
            Console.WriteLine("6.Create Product");
            Thread.Sleep(100);
            Console.WriteLine("7.Show All Products");
            Thread.Sleep(100);
            Console.WriteLine("8.Get Product By Id");
            Thread.Sleep(100);
            Console.WriteLine("9.Update Product");
            Thread.Sleep(100);
            Console.WriteLine("10.Remove Product");
            Thread.Sleep(100);
            Console.WriteLine("0.Left");
            Thread.Sleep(100);
            Console.WriteLine("----------------");

            Console.ForegroundColor = ConsoleColor.Yellow;
            string message = "Choose your request:";
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(20);
            }

        }

        private async Task CreateRestaurant()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Add Restaurant Name: ");
            string name = Console.ReadLine();
            while (!char.IsUpper(name[0]) || name.Any(char.IsDigit) || name == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter name properly!");
                name = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Add Product Limit: ");
            string limit = Console.ReadLine();
            int.TryParse(limit, out int count);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Choose Restaurant Category: ");
            var category = Enum.GetValues(typeof(RestaurantCategory));
            foreach (var item in category)
            {
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.WriteLine((int)item + "." + item);
            }
            int.TryParse(Console.ReadLine(), out int rescategory);

            try
            {
                category.GetValue(rescategory - 1);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Restaurant Category is not valid!");
                return;
            }
            string message = await _restaurantService.CreateAsync(count, (RestaurantCategory)rescategory, name);
            Console.WriteLine(message);
        }

        private async Task ShowAllRestaurant()
        {
            List<Restaurant> restaurants = await _restaurantService.GetAllAsync();
            if (restaurants.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no restaurant!");
            }
            else
            {
                foreach (var item in restaurants)
                {

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(item);
                }
            }

        }
        private async Task ShowRestaurant()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter Restaurant ID: ");
            int.TryParse(Console.ReadLine(), out int id);

            Restaurant restaurant = await _restaurantService.GetAsync(id);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(restaurant);
        }
        private async Task UpdateRestaurant()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter Restaurant ID: ");
            int.TryParse(Console.ReadLine(), out int id);

            Console.WriteLine("Add Restaurant Limit: ");
            int.TryParse(Console.ReadLine(), out int limit);

            string message = await _restaurantService.UpdateAsync(id, limit);
            Console.WriteLine(message);

        }
        private async Task RemoveRestaurant()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter Restaurant ID:");
            int.TryParse(Console.ReadLine(), out int id);

            string message = await _restaurantService.DeleteAsync(id);
            Console.WriteLine(message);
        }
        private async Task CreateProduct()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter Product Name:");
            string name = Console.ReadLine();
            while (!char.IsUpper(name[0]) || name.Any(char.IsDigit) || name == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter Name properly!");
                name = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Choose Product Category: ");
            var category = Enum.GetValues(typeof(ProductCategory));
            foreach (var item in category)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine((int)item + "." + item);
            }
            int.TryParse(Console.ReadLine(), out int procategory);

            try
            {
                category.GetValue(procategory - 1);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Product Category is not valid!");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter Price: ");
            int.TryParse(Console.ReadLine(), out int price);

            Console.WriteLine("Enter Restaurant name: ");
            string resname = Console.ReadLine();
            while (resname==null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter Restaurant Name properly!");
                resname = Console.ReadLine();
            }

            string message = await _productService.CreateAsync(name, price,(ProductCategory)procategory,resname);
            Console.WriteLine(message);
        }
        private async Task ShowAllProducts()    
        {
            List<Product> Products = await _productService.GetAllAsync();
            Console.ForegroundColor = ConsoleColor.Blue;
            if (Products.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no restaurant!");
            }
            else
            {
                foreach (var item in Products)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(item);
                }
            }
        }
        private async Task GetProductById()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter Product ID:");
            int.TryParse(Console.ReadLine(), out int id);
            Product product = await _productService.GetAsync(id);
            Console.WriteLine(product);
        }
        private async Task UpdateProduct()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter ID:");
            int.TryParse(Console.ReadLine(), out int id);

            Console.WriteLine("Enter Product Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Product Price:");
            int.TryParse(Console.ReadLine(), out int price);

            string message = await _productService.UpdateAsync(id, name, price);
            Console.WriteLine(message);
        }
        private async Task RemoveProduct()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter Product ID:");

            int.TryParse(Console.ReadLine(), out int id);
            string message = await _productService.DeleteAsync(id);
            Console.WriteLine(message);
        }
    }

}