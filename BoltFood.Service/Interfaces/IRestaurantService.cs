using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoltFood.Core.Enums;
using BoltFood.Core.Models.BaseModel;

namespace BoltFood.Service.Interfaces
{
    public interface IRestaurantService
    {
        public Task<string> CreateAsync(int Limit,RestaurantCategory category,string name);
        public Task<string> UpdateAsync(int id,int limit);
        public Task<string> DeleteAsync(int id);
        public Task<List<Restaurant>> GetAllAsync();
        public Task<Restaurant> GetAsync(int id);
        public Task<List<Product>> GetProductByRestaurantAsync(string name);
    }
}
