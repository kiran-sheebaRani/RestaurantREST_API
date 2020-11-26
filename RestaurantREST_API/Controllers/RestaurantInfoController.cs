using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantLibrary.Entities;
using RestaurantREST_API.Models;
using RestaurantREST_API.Services;

namespace RestaurantREST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantInfoController : ControllerBase
    {
        private IRestaurantInfoRepository _restaurantInfoRepository;
        private readonly IMapper _mapper;

        public RestaurantInfoController(IRestaurantInfoRepository restaurantInfoRepository, IMapper mapper)
        {
            _restaurantInfoRepository = restaurantInfoRepository;
            _mapper = mapper;
        }
        // GET: api/<controller>
        [HttpGet("getall")]
        public async Task<ActionResult<RestaurantInfo>> GetRestaurants()
        {
            var restaurantEntities = await _restaurantInfoRepository.GetRestaurants();
            var results = _mapper.Map<IEnumerable<RestaurantDto>>(restaurantEntities);
            return Ok(results);
        }

        // GET api/<controller>/5
        [HttpGet("getbyid/{id}")]
        public async Task<ActionResult<RestaurantInfo>> GetRestaurantById(String id)
        {
            var restaurant = await _restaurantInfoRepository.GetRestaurantById(id);

            if (restaurant == null)
            {
                return NotFound();
            }


            var restaurantResult = _mapper.Map<RestaurantDto>(restaurant);
            return Ok(restaurantResult);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<RestaurantInfo>> CreateRestaurant([FromBody] RestaurantInfo restaurant)
        {
            if (restaurant == null) return BadRequest();



            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _restaurantInfoRepository.RestaurantExists(restaurant.RestaurantId)) return NotFound();

            var finalRestaurant = _mapper.Map<RestaurantInfo>(restaurant);

            await _restaurantInfoRepository.AddRestaurant(restaurant);

            //_employeeInfoRepository.AddEmployee(employee);
            if (!await _restaurantInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            var createdPointOfInterestToReturn = _mapper.Map<RestaurantDto>(finalRestaurant);

            return CreatedAtAction("GetRestaurantById", new { id = createdPointOfInterestToReturn.RestaurantId }, createdPointOfInterestToReturn);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRestaurant(String id, [FromBody] RestaurantInfo restaurant)
        {
            if (restaurant == null) return BadRequest();



            if (!ModelState.IsValid) return BadRequest(ModelState);



            
            RestaurantInfo restaurant1 = await _restaurantInfoRepository.GetRestaurantById(id);
   
            if (restaurant1 == null) return NotFound();
            _mapper.Map(restaurant, restaurant1);


            if (!await _restaurantInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRestaurant(String id)
        {
            if (!await _restaurantInfoRepository.RestaurantExists(id)) return NotFound();

    
            RestaurantInfo restaurant2Delete = await _restaurantInfoRepository.GetRestaurantById(id);
          
            if (restaurant2Delete == null) return NotFound();
            _restaurantInfoRepository.DeleteRestaurant(restaurant2Delete);

            if (!await _restaurantInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }
    }
}
