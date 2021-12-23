using OnboardingSoftware.App.Validations.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSoftware.App.Validations
{
    public class IncorrectUsernameOrPassword<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value, bool taken = false)
        {
            //if (value == null)
            //    return false;
            //var str = value as string;

            //if (str == "True")
            //    return true;

            return false;

            //var str = value as string;
            //Implement incorrect username or password
            // return str.Any(c => char.IsDigit(c));
        }

    }

    public static partial class PropertyValidationExtensions
    {
        public static void IncorrectUsernameOrPassword(this ValidatableObject<string> property) => property.Validations.Add(new IncorrectUsernameOrPassword<string> { ValidationMessage = "Incorrect username or password." }); //translations and resource needed here
    }
}
