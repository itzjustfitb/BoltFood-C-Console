using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoltFood.Core.Enums;
using BoltFood.Core.Models.BaseModel;

namespace BoltFood.Service.Interfaces
{
    public interface IProductService
    {
        public Task<string> CreateAsync(string productName, int price,ProductCategory category ,string restaurantname);
        public Task<string> UpdateAsync(int id,string productName,int price);
        public Task<string> DeleteAsync(int id);
        public Task<Product> GetAsync(int id);
        public Task<List<Product>> GetAllAsync();
    }
}
