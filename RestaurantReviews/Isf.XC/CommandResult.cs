using Isf.XC.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Isf.XC
{
    public class CommandResult
    {
        public bool DidComplete { get; set; }
        public ObjectValidationResult ValidationResult { get; set; }
        public Exception Exception { get; set; }

        public void RaiseExceptionOnFailure()
        {
            if(this.Exception != null)
            {
                throw this.Exception;
            }
        }

        public static CommandResult Create(ObjectValidationResult validationResult)
        {
            return new CommandResult
            {
                ValidationResult = validationResult,
                DidComplete = false
            };
        }
    }
}
