using OnboardingSoftware.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnboardingSoftware.App.Validations.Common
{
    public class ValidatableObject<T> : ExtendedBindableObject
    {
        private readonly List<IValidationRule<T>> _validations;
        private List<string> _errors;
        private T _value;
        private bool _isValid = false;

        public List<IValidationRule<T>> Validations => _validations;

        public List<string> Errors
        {
            get
            {
                return _errors;
            }
            set
            {
                _errors = value;
                RaisePropertyChanged(() => Errors);
            }
        }

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                RaisePropertyChanged(() => Value);
            }
        }

        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                _isValid = value;
                RaisePropertyChanged(() => IsValid);

            }
        }

        public ValidatableObject()
        {
            _isValid = true;
            _errors = new List<string>();
            _validations = new List<IValidationRule<T>>();
        }

        public bool Validate(bool taken = false, string message = "", string value = "")
        {
            Errors.Clear();

            IEnumerable<string> errors = _validations.Where(v => !v.Check(Value, taken))
                 .Select(v => v.ValidationMessage);

            List<string> list = new List<string>();

            if (taken)
            {
                //if (value == null)
                //    return false;

                //var str = value as string;

                //int count = str.Count(f => f == '@');
                //if (count != 1)
                //    message = "Email '" + value + "' is invalid.";

                //var left = str.Substring(str.LastIndexOf('@') - 1);
                //var right = str.Substring(str.LastIndexOf('@') + 1);

                //if (left == "" || right == "")
                //message = "Email '" + value + "' is invalid.";


                Errors.Clear();
                list.Add(message);
                Errors = list;
            }
            else
            {
                Errors = errors.ToList();
            }

                IsValid = !Errors.Any();

            return this.IsValid;
        }
    }
}
