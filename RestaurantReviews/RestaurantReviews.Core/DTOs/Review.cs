using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantReviews.Core.DTOs
{
    public class Review
    {
        public string Id { get; set; }
        public string RestaurantId { get; set; }
        public int Rating { get; set; }
        public string Body { get; set; }

        public Reviewer Reviewer { get; set; }
    }
}
