
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OnboardingSoftware.App.Resources;
using OnboardingSoftware.App.Validations;
using OnboardingSoftware.App.Validations.Common;
using OnboardingSoftware.App.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnboardingSoftware.App.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {

        public RegisterViewModel()
        {
            InitializeValidation();
        }

        private void InitializeValidation()
        {
            _email = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();
            _firstname = new ValidatableObject<string>();
            _lastname = new ValidatableObject<string>();

            AddSpecificPropertyValidations();
        }

        #region Properties

        private ValidatableObject<string> _email;
        public ValidatableObject<string> Email => _email;

        private ValidatableObject<string> _password;
        public ValidatableObject<string> Password => _password;

        private ValidatableObject<string> _firstname;
        public ValidatableObject<string> Firstname => _firstname;

        private ValidatableObject<string> _lastname;
        public ValidatableObject<string> Lastname => _lastname;

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
            IsValidForm = Email.IsValid && Password.IsValid && Firstname.IsValid && Lastname.IsValid;

            return IsValidForm;
        }

        public ICommand ValidateEmailCommand
        {
            get
            {
                return new Command(() =>
                {
                    Email.Validate();
                    IsValidForm = Email.IsValid && Password.IsValid && Firstname.IsValid && Lastname.IsValid;
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
                    IsValidForm = Email.IsValid && Password.IsValid && Firstname.IsValid && Lastname.IsValid;
                });
            }
        }

        public ICommand ValidateFirstnameCommand
        {
            get
            {
                return new Command(() =>
                {
                    Firstname.Validate();

                    IsValidForm = Email.IsValid && Password.IsValid && Firstname.IsValid && Lastname.IsValid;
                });
            }
        }

        public ICommand ValidateLastnameCommand
        {
            get
            {
                return new Command(() =>
                {
                    Lastname.Validate();

                    IsValidForm = Email.IsValid && Password.IsValid && Firstname.IsValid && Lastname.IsValid;
                });
            }
        }

        private void AddSpecificPropertyValidations()
        {

            //_email.RequireUniqueEmail();
            _email.RequireLettersAndDigits();
            _email.RequireAt();

            _password.RequireLength();
            _password.RequireLowercase();
            _password.RequireUppercase();
            _password.RequireDigit();
            _password.RequireNonAlphanumeric();
        }

        #endregion

        public ICommand RegisterCommand
        {
            get
            {
                return new Command<string>(async (route) => await RegisterUserAsync(route, Email.Value, Password.Value, Firstname.Value, Lastname.Value));
            }
        }




        private async Task RegisterUserAsync(string route, string email, string password, string firstname, string lastname)
        {
            try
            {
                IsBusy = true;

                Email.Validate();
                Password.Validate();

                IsValidForm = Email.IsValid && Password.IsValid && Firstname.IsValid && Lastname.IsValid;

                if (!IsValidForm)
                    return;


                HttpClient client = new HttpClient();
                Uri uri = new Uri("http://192.168.0.15:5001/");


                UserSignUpResource resource = new UserSignUpResource
                { Email = email, Password = password, FirstName = firstname, LastName = lastname };


                string json = JsonConvert.SerializeObject(resource);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                //var request = new HttpMessageRequest(yourUrl);
                //request.Content = yourContent;
                //var response = await client.SendAsync(request,
                //HttpCompletionOption.ResponseHeadersRead);


                HttpResponseMessage response = null;
                response = await client.PostAsync(uri + "api/Auth/signup", content);

                if (response.IsSuccessStatusCode)
                {
                    Application.Current.MainPage = new NavigationPage(new ViewLogin());
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    JObject o = JObject.Parse(error);

                    //This will be "Apple"
                    string message = (string)o["detail"];

                    //This will be "Lemon"
                    if (message.Contains("taken") || message.Contains("invalid"))
                        Email.Validate(true, message, resource.Email);

                }


                IsBusy = false;

            }
            catch (Exception ex)
            {
                //Handle it here
                Debug.WriteLine(ex);
                IsBusy = false;
            }


        }


        public ICommand NavigateCommand
        {
            get
            {
                return new Command<string>(async (route) =>
                {

                    Application.Current.MainPage = new NavigationPage(new ViewLogin());


                });
            }
        }
    }
}
