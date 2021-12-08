using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnboardingSoftware.App.ViewModels.Dialogs
{
    public class JobDialogViewModel : BaseViewModel
    {
        public class Posao
        {
            public int ID { get; set; }
            public string Naziv { get; set; }
            public string Tip { get; set; }
            public string Kategorija { get; set; }
            public string Opis { get; set; }
            public string Lokacija { get; set; }

        }

        public ICommand DisplayNameCommand => new Command<Posao>(async posao =>
        {
            await Application.Current.MainPage.DisplayAlert("Selected Name", posao.Naziv, "OK");
        });

        public ICommand FinishCommand => new Command<Posao>(async posao =>
        {
            Debug.WriteLine("---------- OnStart called!");
        });

        public async Task CloseInfo()
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
        public ICommand CloseInfoCommand { get { return new Command(async () => await CloseInfo()); } }
    }
}
