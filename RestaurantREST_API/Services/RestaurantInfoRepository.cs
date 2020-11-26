using Microsoft.EntityFrameworkCore;
using RestaurantLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantREST_API.Services
{
    public class RestaurantInfoRepository : IRestaurantInfoRepository
    {
        private RestaurantContext _context;
        public RestaurantInfoRepository(RestaurantContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RestaurantInfo>> GetRestaurants()
        {
            var result = _context.RestaurantInfo.OrderBy(c => c.RestaurantName);
            return await result.ToListAsync();
        }
        public async Task<RestaurantInfo> GetRestaurantById(String restaurantId)
        {

            IQueryable<RestaurantInfo> result;

            result = _context.RestaurantInfo.Where(c => Equals(c.RestaurantId,restaurantId));

            return await result.FirstOrDefaultAsync();
        }
        public async Task<bool> RestaurantExists(String restaurantId)
        {
            return await _context.RestaurantInfo.AnyAsync<RestaurantInfo>(c => Equals(c.RestaurantId, restaurantId));
        }
        public async Task AddRestaurant(RestaurantInfo restaurant)
        {

            _context.RestaurantInfo.Add(restaurant);
            await _context.SaveChangesAsync();
        }
   
        public void DeleteRestaurant(RestaurantInfo restaurant)
        {
            _context.RestaurantInfo.Remove(restaurant);
        }
        public async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
