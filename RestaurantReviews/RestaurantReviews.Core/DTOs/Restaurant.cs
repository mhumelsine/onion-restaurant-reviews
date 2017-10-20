using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantReviews.Core.DTOs
{
    public class Restaurant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
