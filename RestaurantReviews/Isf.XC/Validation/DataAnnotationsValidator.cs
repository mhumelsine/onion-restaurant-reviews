using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Isf.XC.Validation
{
    public class DataAnnotationsValidator : IValidator
    {
        public Task<ObjectValidationResult> ValidateAsync(object objectToValidate, IDictionary<string, object> validationContext = null)
        {
            return new Task<ObjectValidationResult>(() =>
           {
               var context = new ValidationContext(objectToValidate);
               var validationResults = new List<ValidationResult>();

               Validator.TryValidateObject(objectToValidate, context, validationResults);

               var result = new ObjectValidationResult();

               if (validationResults.Count > 0)
               {
                   result.AddErrors(validationResults);
               }

               return result;
           });
        }
    }
}
