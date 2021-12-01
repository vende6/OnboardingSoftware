using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnboardingSoftware.App.ViewModels
{
    public class RegisterViewModel
    {
        public ICommand NavigateCommand
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
