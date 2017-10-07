using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Isf.XC.Validation
{
    public class ObjectValidationResult
    {
        public object Object { get; set; }
        public bool IsValid { get { return this.errors == null; } }
        public IEnumerable<ValidationResult> Errors { get { return this.errors.ToList(); } }

        private List<ValidationResult> errors;

        public void AddError(string errorMessage, params string[] properties)
        {
            this.EnsureList();
            this.errors.Add(new ValidationResult(errorMessage, properties));
        }
        public void AddErrors(IEnumerable<ValidationResult> errorsMessages)
        {
            this.EnsureList();
            this.errors.AddRange(errorsMessages);
        }

        private void EnsureList()
        {
            if(this.errors == null)
            {
                this.errors = new List<ValidationResult>();
            }
        }
    }
}
