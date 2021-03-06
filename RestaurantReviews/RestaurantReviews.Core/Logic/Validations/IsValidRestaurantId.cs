﻿using Isf.XC.Validation;
using RestaurantReviews.Core.DTOs;
using RestaurantReviews.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Core.Logic.Validations
{
    public class IsValidRestaurantId : ValidatorBase
    {
        private IRestaurantStore store;
        public IsValidRestaurantId(IRestaurantStore store)
        {
            this.store = store;
        }
        public override ObjectValidationResult Validate(object objectToValidate, IDictionary<string, object> validationContext = null)
        {
            var result = new ObjectValidationResult();

            string restaurantId = string.Empty;

            if(objectToValidate is Restaurant)
            {
                restaurantId = ((Restaurant)objectToValidate).Id;
            }

            if (objectToValidate is Review)
            {
                restaurantId = ((Review)objectToValidate).RestaurantId;
            }            

            var restaurant = store.Find(restaurantId);

            if(restaurant == null)
            {
                result.AddError(
                    string.Format("A restaurant with the ID: {0} could not be found", restaurantId));
            }

            return result;
        }
    }
}
