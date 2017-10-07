using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Isf.XC.Validation
{
    public interface IValidator
    {
        Task<ObjectValidationResult> ValidateAsync(object objectToValidate, IDictionary<string, object> validationContext = null);
    }
}
