using Microsoft.EntityFrameworkCore;
using RestaurantReviews.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantReviews.Infrastructure.DataAccess
{
    public class RestaurantReviewsDbContext : DbContext
    {
        static RestaurantReviewsDbContext() { }

        public DbSet<Restaurant> Restaurants { get; }
        public DbSet<Review> Reviews { get; }
    }
}
