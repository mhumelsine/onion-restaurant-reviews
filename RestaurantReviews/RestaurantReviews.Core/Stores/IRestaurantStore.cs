using RestaurantReviews.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Core.Stores
{
    public interface IRestaurantStore : IStore<Restaurant>
    {
        IEnumerable<Restaurant> Find(RestaurantSearch search);
    }
}
