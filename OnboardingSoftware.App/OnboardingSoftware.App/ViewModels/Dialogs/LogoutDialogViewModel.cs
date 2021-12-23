using OnboardingSoftware.App.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnboardingSoftware.App.ViewModels.Dialogs
{
    public class LogoutDialogViewModel : BaseViewModel
    {

        public async Task CloseInfo()
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
        public ICommand CloseInfoCommand { get { return new Command(async () => await CloseInfo()); } }

        public ICommand NavigateCommand
        {
            get
            {
                return new Command<string>(async (route) =>
                {
                    Settings.SetAccessToken("");
                    await PopupNavigation.Instance.PopAsync(true);
                    Application.Current.MainPage = new NavigationPage(new ViewLogin());


                });
            }
        }

    }
}
