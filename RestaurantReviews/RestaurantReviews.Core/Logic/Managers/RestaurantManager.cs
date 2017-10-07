using Isf.XC;
using Isf.XC.Validation;
using RestaurantReviews.Core.Entities;
using RestaurantReviews.Core.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Core.Logic.Managers
{
    public class RestaurantManager
    {
        private IValidator canAddRestaurantValidator;
        private IRestaurantStore restaurantStore;

        public RestaurantManager(
            IValidator canAddRestaurantValidator,
            IRestaurantStore restaurantStore)
        {
            this.canAddRestaurantValidator = canAddRestaurantValidator;
            this.restaurantStore = restaurantStore;
        }

        public async Task<CommandResult> AddRestaurantAsync(Restaurant restaurant)
        {
            var result = new CommandResult();
            
            var validationResult = await this.canAddRestaurantValidator.ValidateAsync(restaurant);

            if (!validationResult.IsValid)
            {
                result.ValidationResult = validationResult;
                return result;
            }

            await restaurantStore.AddAsync(restaurant);

            result.DidComplete = true;
            return result;
        }
    }
}
