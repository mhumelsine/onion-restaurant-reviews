using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Isf.XC.Validation
{
    public abstract class ValidatorBase : IValidator
    {
        public abstract ObjectValidationResult Validate(object objectToValidate, IDictionary<string, object> validationContext = null);

        protected object GetEntry(string key, IDictionary<string, object> validationContext)
        {
            return validationContext[key];            
        }

        protected T GetEntry<T>(IDictionary<string, object> validationContext)
        {
            Type type = typeof(T);

            // try to get entry using same name as object
            object entry = validationContext[type.Name];

            // if not found, try getting any object that can be assigned to the type
            if (entry == null)
            {
                entry = validationContext.Values.FirstOrDefault(val => val.GetType().IsAssignableFrom(type));
            }

            T typedEntry = default(T);

            try
            {
                typedEntry = (T)entry;
            }
            catch (Exception) { }

            if (entry == null)
            {
                throw new KeyNotFoundException(string.Format("Entry for key: {0} could not be found", type.Name));
            }

            return typedEntry;
        }
    }
}
