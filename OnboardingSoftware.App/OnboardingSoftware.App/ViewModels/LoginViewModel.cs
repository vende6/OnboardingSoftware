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
            _username.AddEmailValidation();
            _password.AddPasswordValidation();
        }

        #endregion


        public ICommand LoginCommand
        {
            get
            {
                return new Command<string>(async (route) => await LoginUserAsync(route, Username.Value, Password.Value));
            }
        }

        private async Task LoginUserAsync(string route, string username, string password)
        {
            try
            {
                IsBusy = true;
                //Narucioci_Result narucilac = await BaseClient.Client.LoginAsync(username);
                //if (narucilac != null && narucilac.LozinkaHash == UIHelper.GenerateHash(narucilac.LozinkaSalt, password))
                //{
                //   var omiljeni = await BaseClient.Client.GetFavouriteAsync((int)narucilac.KorisnikID);
                //    GlobalSettings.logiraniNarucilac = narucilac;
                //    await Shell.Current.GoToAsync(route);
                //}
                IsBusy = false;
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
