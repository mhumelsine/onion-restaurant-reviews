using RestaurantReviews.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using Isf.XC;
using RestaurantReviews.Core.DTOs;

namespace RestaurantReviews.Infrastructure.Stores
{
    public class EfRestaurantStore : IRestaurantStore
    {
        public void Add(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public CommandResult CommitChanges()
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> Find(RestaurantSearch search)
        {
            throw new NotImplementedException();
        }

        public Restaurant Find(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(Restaurant entity)
        {
            throw new NotImplementedException();
        }
    }
}
