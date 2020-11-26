using RestaurantLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantREST_API.Services
{
    public interface IRestaurantInfoRepository
    {
        Task<IEnumerable<RestaurantInfo>> GetRestaurants();
        Task<RestaurantInfo> GetRestaurantById(String restaurantId);
        Task<bool> RestaurantExists(String restaurantId);
        Task AddRestaurant(RestaurantInfo restaurants);
        //void AddEmployee(Employees employees);
        void DeleteRestaurant(RestaurantInfo restaurants);
        Task<bool> Save();
    }
}
