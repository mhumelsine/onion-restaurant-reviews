using Isf.XC.Validation;
using RestaurantReviews.Core.DTOs;
using RestaurantReviews.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Core.Logic.Validations
{
    public class MustNotBeReviewed : ValidatorBase
    {
        private IReviewStore store;

        public MustNotBeReviewed(IReviewStore store)
        {
            this.store = store;
        }
        public override ObjectValidationResult Validate(object objectToValidate, IDictionary<string, object> validationContext = null)
        {
            var result = new ObjectValidationResult();
            var restaurant = (Restaurant)objectToValidate;

            int reviewCount = this.store.GetReviewCount(restaurant.Id);

            if(reviewCount > 0)
            {
                result.AddError("Cannot delete a restaurant if it has been reviewed.", string.Empty);
            }

            return result;
        }
    }
}
