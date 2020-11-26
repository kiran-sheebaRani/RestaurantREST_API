using AutoMapper;
using RestaurantLibrary.Entities;
using RestaurantREST_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantREST_API.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RestaurantInfo, RestaurantDto>();
            CreateMap<RestaurantInfo, RestaurantInfo>();
        }
       
    }
}
