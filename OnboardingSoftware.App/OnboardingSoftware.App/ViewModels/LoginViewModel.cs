using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OnboardingSoftware.App.Resources;
using OnboardingSoftware.App.Validations;
using OnboardingSoftware.App.Validations.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnboardingSoftware.App.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            InitializeValidation();
        }


        private void InitializeValidation()
        {
            _username = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();

            AddSpecificPropertyValidations();
        }

        #region Properties

        private ValidatableObject<string> _username;
        public ValidatableObject<string> Username => _username;

        private ValidatableObject<string> _password;
        public ValidatableObject<string> Password => _password;

        private bool _isValidForm { get; set; }
        public bool IsValidForm
        {
            get { return _isValidForm; }
            set
            {
                _isValidForm = value;
                RaisePropertyChanged(() => IsValidForm);
            }
        }

        #endregion

        #region Validations

        private bool ValidateForm()
        {
            IsValidForm = _username.IsValid && _password.IsValid;

            return IsValidForm;
        }

        public ICommand ValidateUsernameCommand
        {
            get
            {
                return new Command(() =>
                {
                    Username.Validate();

                    IsValidForm = Username.IsValid && Password.IsValid;
                });

            }
        }

        public ICommand ValidatePasswordCommand
        {
            get
            {
                return new Command(() =>
                {
                    Password.Validate();

                    IsValidForm = Username.IsValid && Password.IsValid;
                });
            }
        }

        private void AddSpecificPropertyValidations()
        {
            //_email.RequireLettersAndDigits();
            //_email.RequireAt();

            //_password.RequireLength();
            //_password.RequireLowercase();
            //_password.RequireUppercase();
            //_password.RequireDigit();
            //_password.RequireNonAlphanumeric();

            _password.UserNotFound();
        }

        #endregion


        public ICommand LoginCommand
        {
            get
            {
                return new Command<string>(async (route) => await LoginUserAsync(route, Username.Value, Password.Value));
            }
        }

        private async Task LoginUserAsync(string route, string email, string password)
        {
            try
            {
                //Username.Validate();
                //Password.Validate();

                //IsValidForm = Username.IsValid && Password.IsValid;

                //if (!IsValidForm)
                //    return;

                //IsBusy = true;

                //HttpClient client = new HttpClient();
                //Uri uri = new Uri("https://a2f2-77-238-220-218.ngrok.io/");


                //UserLoginResource resource = new UserLoginResource
                //{ Email = email, Password = password };


                //string json = JsonConvert.SerializeObject(resource);
                //StringContent content = new StringContent(json, Encoding.UTF8, "application/json");



                //HttpResponseMessage response = null;
                //response = await client.PostAsync(uri + "api/Auth/signin", content);


                //if (response.IsSuccessStatusCode)
                //{
                await Shell.Current.GoToAsync(route);
                //}
                //if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                //{
                //    Password.Validate();
                //}





                IsBusy = false;
               // await Shell.Current.GoToAsync(route);
            }
            catch (Exception ex)
            {
                //Handle it here
                IsBusy = false;
            }


        }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command<string>(async (route) =>
                {


                    await Shell.Current.GoToAsync(route);


                });
            }
        }

    }
}
