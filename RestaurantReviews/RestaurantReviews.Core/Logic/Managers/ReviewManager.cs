using Isf.XC;
using Isf.XC.Validation;
using RestaurantReviews.Core.Entities;
using RestaurantReviews.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Core.Logic.Managers
{
    public class ReviewManager
    {
        private IReviewStore reviewStore;
        private IValidator canAddReviewValidator;

        public ReviewManager(
            IReviewStore reviewStore,
            IValidator canAddReviewValidator)
        {
            this.reviewStore = reviewStore;
            this.canAddReviewValidator = canAddReviewValidator;
        }

        public async Task<CommandResult> AddReviewAsync(Review review)
        {
            var result = new CommandResult();
            var validationResult = await this.canAddReviewValidator.ValidateAsync(review);

            if (!validationResult.IsValid)
            {
                result.ValidationResult = validationResult;
                return result;
            }

            await this.reviewStore.AddAsync(review);
            result.DidComplete = true;
            return result;
        }
    }
}
