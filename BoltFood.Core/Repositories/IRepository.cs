using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Core.Repositories
{
    public interface IRepository<T>
    {
        public Task AddAsync(T data);
        public Task RemoveAsync(T data);
        public Task<List<T>> GetAllAsync();
        public Task<T> GetAsync(Func<T,bool> ex);
        public Task UpdateAsync(T data);
            
    }
}
