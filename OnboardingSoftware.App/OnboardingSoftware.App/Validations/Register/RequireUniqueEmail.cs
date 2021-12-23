using OnboardingSoftware.App.Validations.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSoftware.App.Validations
{

    public class RequireUniqueEmail<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value, bool taken = false)
        {
            if (value == null)
                return false;

            if(taken)
            return false;

            return true;
        }
    }

    public static partial class PropertyValidationExtensions
    {
        public static void RequireUniqueEmail(this ValidatableObject<string> property)
        {
            property.Validations.Add(new RequireUniqueEmail<string> { ValidationMessage = "Email is already taken." }); //translations and resource needed here
        }
    }
}
