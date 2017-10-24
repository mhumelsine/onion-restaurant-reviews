using Isf.XC.Validation;
using RestaurantReviews.Core.Logic.Managers;
using RestaurantReviews.Core.Logic.Validations;
using RestaurantReviews.Core.Stores;
using RestaurantReviews.Infrastructure.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantReviews.Infrastructure.Factories
{
    public interface IRestaurantManagerFactory
    {
        RestaurantManager CreateInstance();
    }
    public class RestaurantManagerFactory : IRestaurantManagerFactory
    {
        public RestaurantManager CreateInstance()
        {
            IRestaurantStore restaurantStore = new XmlRestaurantStore();

            IValidator canAddRestaurantValidator = new ValidationManager(true,                
                new DataAnnotationsValidator(),
                new NoDuplicateRestaurantNames(restaurantStore));

            return new RestaurantManager(canAddRestaurantValidator, restaurantStore);
        }
    }
}
