using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OnboardingSoftware.App.Resources;
using OnboardingSoftware.App.Validations;
using OnboardingSoftware.App.Validations.Common;
using OnboardingSoftware.App.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnboardingSoftware.App.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        // public INavigation Navigation { get; set; }

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

        private string _errorMessage { get; set; }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                RaisePropertyChanged(() => ErrorMessage);
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

            // _password.UserNotFound();
            // _password.IncorrectUsernameOrPassword();
        }

        #endregion


        public ICommand LoginCommand
        {
            get
            {
                return new Command<string>(async (route) => await LoginUserAsync(route, Username.Value, Password.Value));
            }
        }

        public ICommand NavigateCommand
        {
            get
            {
                return new Command<string>(async (route) =>
                {
                    Application.Current.MainPage = new NavigationPage(new ViewRegister());
                });
            }
        }

        private async Task LoginUserAsync(string route, string email, string password)
        {
            try
            {
                IsBusy = true;

                //Username.Validate();
                //Password.Validate();

                //IsValidForm = Username.IsValid && Password.IsValid;

                //if (!IsValidForm)
                //    return;


                HttpClient client = new HttpClient();
                Uri uri = new Uri("https://onboardingsoftware.azurewebsites.net/");

                if (email == null)
                    email = String.Empty;
                if (password == null)
                    password = String.Empty;


                UserLoginResource resource = new UserLoginResource
                { Email = email, Password = password };


                string json = JsonConvert.SerializeObject(resource);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");



                HttpResponseMessage response = null;
                response = await client.PostAsync(uri + "api/Auth/signin", content);


                if (response.IsSuccessStatusCode)
                {
                    ErrorMessage = string.Empty;
                    var value = response.Content.ReadAsStringAsync();
                    Settings.SetAccessToken(value.Result);

                    if (!AppState.IsVerified)
                    {
                        var previousPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
                        await Application.Current.MainPage.Navigation.PushAsync(new ViewVerify());
                        Application.Current.MainPage.Navigation.RemovePage(previousPage);
                    }
                    else
                    Application.Current.MainPage = new AppShell();

                }
                else
                {
                    var value = response.Content.ReadAsStringAsync();
                    ErrorMessage = value.Result;
                }

                IsBusy = false;
            }
            catch (Exception ex)
            {
                //Handle it here
                IsBusy = false;
            }


        }


    }
}
