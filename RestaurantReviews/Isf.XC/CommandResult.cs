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
    }
}
