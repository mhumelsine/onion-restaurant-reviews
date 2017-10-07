using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantReviews.Infrastructure.DataAccess;
using RestaurantReviews.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace RestaurantReviews.MVC.Controllers.api
{
    [Produces("application/json")]
    [Route("api/RestaurantApi")]
    public class RestaurantApiController : Controller
    {
        private RestaurantReviewsDbContext db;
        private int pageSize = 10;

        public RestaurantApiController(RestaurantReviewsDbContext db)
        {
            this.db = db;
        }
        // GET: api/RestaurantApi
        [HttpGet]
        public async Task<IEnumerable<Restaurant>> Get(string name, string city, string orderBy, int page = 1)
        {
            var restaurants = await this.db.Restaurants
                .Where(x => x.Name.StartsWith(name))
                .Where(x => x.City.StartsWith(city))
                .OrderBy(x => x.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return restaurants;
        }

        // GET: api/RestaurantApi/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/RestaurantApi
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/RestaurantApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
