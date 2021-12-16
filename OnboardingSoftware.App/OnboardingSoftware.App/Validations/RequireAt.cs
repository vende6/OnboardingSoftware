using OnboardingSoftware.App.Validations.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnboardingSoftware.App.Validations
{
    //Email 'dawdawddawd' is invalid.
    public class RequireAt<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value, bool taken = false)
        {
            if (value == null)
                return false;

            var str = value as string;

            int count = str.Count(f => f == '@');
            if (count != 1)
                return false;

            var left = str.Substring(str.LastIndexOf('@') - 1);
            var right = str.Substring(str.LastIndexOf('@') + 1);

            if (left == "" || right == "")
                return false;

            return true;
        }
    }

    public static partial class PropertyValidationExtensions
    {
        public static void RequireAt(this ValidatableObject<string> property)
        {
            var x = property.Value;
            property.Validations.Add(new RequireAt<string> { ValidationMessage = "Email is invalid." }); //translations and resource needed here
        }
    }
}
