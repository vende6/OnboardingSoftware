using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnboardingSoftware.App.ViewModels.Tests
{
    public class PersonalityViewModel : BaseViewModel
    {
        public PersonalityViewModel()
        {

        }

        private bool _isStarted;
        public bool IsStarted
        {
            get { return this._isStarted; }
            set
            {
                this._isStarted = value;
                RaisePropertyChanged(() => IsStarted);
            }
        }

        public ICommand StartCommand => new Command(async test =>
        {
            IsStarted = !IsStarted;
        });

        public ICommand FinishCommand => new Command(async vjestina =>
        {
            await Application.Current.MainPage.DisplayAlert("Done", "Results have been archived.", "OK");
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//home/profile");
        });
    }
}
