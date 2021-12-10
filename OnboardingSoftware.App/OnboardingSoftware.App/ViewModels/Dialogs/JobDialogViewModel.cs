using OnboardingSoftware.App.LanguageSupport;
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

        public ICommand ApplyCommand => new Command<Posao>(async posao =>
        {
           // if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Count == 0)
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Views.Dialogs.ApplyDialog("Apply for TOB", "In some cases, motivational letter and/or skill test completion is required"));

        });

        public async Task CloseInfo()
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
        public ICommand CloseInfoCommand { get { return new Command(async () => await CloseInfo()); } }
    }
}
