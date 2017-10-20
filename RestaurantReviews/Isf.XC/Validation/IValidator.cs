using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Isf.XC.Validation
{
    public interface IValidator
    {
        ObjectValidationResult Validate(object objectToValidate, IDictionary<string, object> validationContext = null);
    }
}
