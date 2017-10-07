using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantReviews.Core.Entities
{
    public class Restaurant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
