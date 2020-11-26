using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantREST_API.Models
{
    public class RestaurantDto
    {
        public string RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string RestaurantPopular { get; set; }
        public string RestaurantPhone { get; set; }
        public string RestaurantRating { get; set; }
    }
}
