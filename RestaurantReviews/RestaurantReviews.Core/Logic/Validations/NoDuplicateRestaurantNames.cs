using Isf.XC.Validation;
using RestaurantReviews.Core.DTOs;
using RestaurantReviews.Core.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Core.Logic.Validations
{
    public class NoDuplicateRestaurantNames : ValidatorBase
    {
        private IRestaurantStore store;

        public NoDuplicateRestaurantNames(IRestaurantStore store)
        {
            this.store = store;
        }
        public override ObjectValidationResult Validate(object objectToValidate, IDictionary<string, object> validationContext = null)
        {
            var result = new ObjectValidationResult();
            var restaurant = (Restaurant)objectToValidate;

            var sameNameCity = store.Find(new RestaurantSearch
            {
                Name = restaurant.Name,
                City = restaurant.City
            });

            if (sameNameCity.Any())
            {
                result.AddError(
                    string.Format("A restaurant with the name {0} already exists in {1}",
                    restaurant.Name,
                    restaurant.City),
                    "Name", "City");
            }

            return result;
        }
    }
}
