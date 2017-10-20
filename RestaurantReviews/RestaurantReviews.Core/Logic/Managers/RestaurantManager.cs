using Isf.XC;
using Isf.XC.Validation;
using RestaurantReviews.Core.DTOs;
using RestaurantReviews.Core.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Core.Logic.Managers
{
    public class RestaurantManager : ManagerBase
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

        public CommandResult AddRestaurant(Restaurant restaurant)
        {
            // this is a helper function to handle the validate; execute sequence of simple operations
            return this.TryCommand(
                validate: () => this.canAddRestaurantValidator.Validate(restaurant),
                onValid: () =>
                {
                    restaurantStore.Add(restaurant);
                    return restaurantStore.CommitChanges();
                });
        }
    }
}
