using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BoltFood.Core.Models;
using BoltFood.Core.Models.BaseModel;
using BoltFood.Core.Repositories;

namespace BoltFood.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private static List<T> _list=new List<T>();
        public List<T> List { get { return _list; } }
        public async Task AddAsync(T data)
        {
            List.Add(data);
        }

        public async Task RemoveAsync(T data)
        {
            List.Remove(data);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return List;  
        }

        public async Task<T> GetAsync(Func<T,bool> ex)
        {   
            return List.FirstOrDefault(ex);
        }

        public async Task UpdateAsync(T data)
        {
            for (int i = 0; i < _list.Count; i++)
            {   
                if (_list[i].Id == data.Id)
                {
                    _list[i] = data;
                }
            }
        }
    }
}  