using OnboardingSoftware.App.Validations.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnboardingSoftware.App.Validations
{

    public class RequireDigit<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value, bool taken = false)
        {
            if (value == null)
                return false;

            var str = value as string;

            return str.Any(c => char.IsDigit(c));
        }
    }

        public static partial class PropertyValidationExtensions
        {
            public static void RequireDigit(this ValidatableObject<string> property) => property.Validations.Add(new RequireDigit<string> { ValidationMessage = "Passwords must have at least one digit ('0'-'9')." }); //translations and resource needed here
        }
    
}
