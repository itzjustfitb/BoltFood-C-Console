using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoltFood.Core.Models.BaseModel;
using BoltFood.Core.Repositories.RestaurantRepository;

namespace BoltFood.Data.Repositories.RestaurantRepository
{
    public class RestaurantRepository:Repository<Restaurant>,IRestaurantRepository
    {

    }
}
