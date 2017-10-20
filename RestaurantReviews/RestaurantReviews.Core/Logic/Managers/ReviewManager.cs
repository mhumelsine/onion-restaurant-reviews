using Isf.XC;
using Isf.XC.Validation;
using RestaurantReviews.Core.DTOs;
using RestaurantReviews.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Core.Logic.Managers
{
    public class ReviewManager : ManagerBase
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

        public CommandResult AddReview(Review review)
        {
            // this is a helper function to handle the validate; execute sequence of simple operations
            return this.TryCommand(
                validate: () => this.canAddReviewValidator.Validate(review),
                onValid: () =>
                {
                    this.reviewStore.Add(review);
                    return this.reviewStore.CommitChanges();
                });
        }
    }
}
