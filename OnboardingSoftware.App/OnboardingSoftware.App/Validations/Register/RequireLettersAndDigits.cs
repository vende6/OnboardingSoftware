using OnboardingSoftware.App.Validations.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnboardingSoftware.App.Validations
{
    //damir.krkalic@tob.ba@WDAWDAW' is invalid.

    //Username 'dwdwd@dwwdwd    ' is invalid, can only contain letters or digits.



    public class RequireLettersAndDigits<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value, bool taken = false)
        {
            if (value == null)
                return false;

            var str = value as string;

            return str.Any(c => char.IsLetterOrDigit(c) || !char.IsWhiteSpace(c) || c == '.' || c == '@');
        }
    }

    public static partial class PropertyValidationExtensions
    {
        public static void RequireLettersAndDigits(this ValidatableObject<string> property) => property.Validations.Add(new RequireLettersAndDigits<string> { ValidationMessage = "Username is invalid, can only contain letters or digits." }); //translations and resource needed here
    }
}
