﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Isf.XC.Validation
{
    public class ValidationManager : IValidator
    {
        private IEnumerable<IValidator> validators;
        private bool stopOnFirstFailure;

        public ValidationManager(bool stopOnFirstFailure, params IValidator[] validators)
        {
            this.validators = validators;
            this.stopOnFirstFailure = stopOnFirstFailure;
        }

        public async Task<ObjectValidationResult> ValidateAsync(object objectToValidate, IDictionary<string, object> validationContext = null)
        {
            ObjectValidationResult result = new ObjectValidationResult();

            foreach (var validator in this.validators)
            {
                var validationResult = await validator.ValidateAsync(objectToValidate, validationContext);

                if (!validationResult.IsValid && this.stopOnFirstFailure)
                {
                    return validationResult;
                }
                else
                {
                    result.AddErrors(validationResult.Errors);
                }
            }
            return result;
        }
    }
}
