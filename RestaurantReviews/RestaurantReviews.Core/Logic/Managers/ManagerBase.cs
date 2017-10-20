using Isf.XC;
using Isf.XC.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantReviews.Core.Logic.Managers
{
    public abstract class ManagerBase
    {
        public CommandResult TryCommand(Func<ObjectValidationResult> validate, Func<CommandResult> onValid)
        {
            var validationResult = validate();

            if (!validationResult.IsValid)
            {
                return CommandResult.Create(validationResult);
            }
            return onValid();
        }
    }
}
