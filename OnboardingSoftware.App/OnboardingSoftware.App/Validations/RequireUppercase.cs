using OnboardingSoftware.App.Validations.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnboardingSoftware.App.Validations
{
    public class RequireUppercase<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value, bool taken = false)
        {
            if (value == null)
                return false;

            var str = value as string;

            return str.Any(c => char.IsUpper(c));
        }
    }

    public static partial class PropertyValidationExtensions
    {
        public static void RequireUppercase(this ValidatableObject<string> property) => property.Validations.Add(new RequireUppercase<string> { ValidationMessage = "Passwords must have at least one uppercase ('A'-'Z')." }); //translations and resource needed here
    }
}
