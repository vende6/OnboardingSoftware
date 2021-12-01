using OnboardingSoftware.App.Validations.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSoftware.App.Validations
{
    public class IsValidPassword<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
                return false;

            var str = value as string;

            return !string.IsNullOrEmpty(str) && str.Length > 7;
        }
    }

    public static partial class PropertyValidationExtensions
    {
        public static void AddPasswordValidation(this ValidatableObject<string> property) => property.Validations.Add(new IsValidPassword<string> { ValidationMessage = "Password is not valid!" }); //translations and resource needed here
    }
}
