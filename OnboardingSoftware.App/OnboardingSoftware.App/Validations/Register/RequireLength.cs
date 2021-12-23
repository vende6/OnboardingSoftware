using OnboardingSoftware.App.Validations.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSoftware.App.Validations
{
    public class RequireLength<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value, bool taken = false)
        {
            if (value == null)
                return false;

            var str = value as string;

            return str.Length > 7;
        }
    }

    public static partial class PropertyValidationExtensions
    {
        public static void RequireLength(this ValidatableObject<string> property) => property.Validations.Add(new RequireLength<string> { ValidationMessage = "Passwords must be at least 8 characters." }); //translations and resource needed here
    }
}
