using RestaurantReviews.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Core.Stores
{
    public interface IReviewStore : IStore<Review>
    {
        Task<int> GetReviewCountAsync(string restaurantId);
    }
}
