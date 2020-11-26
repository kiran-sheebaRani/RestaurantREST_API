using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantLibrary.Entities
{
    public partial class RestaurantInfo
    {
        [Key]
        public string RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string RestaurantPopular { get; set; }
        public string RestaurantPhone { get; set; }
        public string RestaurantRating { get; set; }
    }
}
