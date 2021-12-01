using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSoftware.App.Validations.Common
{
    /// <summary>
    /// https://blog.xamarin.com/validation-xamarin-forms-enterprise-apps/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidationRule<T>
    {
        string ValidationMessage { get; set; }
        bool Check(T value);
    }
}
