using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;

namespace OnboardingSoftware.App.ViewModels.Dialogs
{
    public class ReferenceDialogViewModel : BaseViewModel
    {
       
        public ReferenceDialogViewModel()
        {
            Vjestine = new MultiSelectObservableCollection<Vjestina>();

            Vjestina vjestina = new Vjestina();
            vjestina.Naziv = "Communication";
            Vjestine.Add(vjestina);

            Vjestine[0].IsSelected = true;

            vjestina = new Vjestina();
            vjestina.Naziv = "Leadership";
            Vjestine.Add(vjestina);

            vjestina = new Vjestina();
            vjestina.Naziv = "Creativity";
            Vjestine.Add(vjestina);

            vjestina = new Vjestina();
            vjestina.Naziv = "Adaptability";
            Vjestine.Add(vjestina);
        }

        public class Vjestina
        {
            public string ID { get; set; }
            public string Naziv { get; set; }
            public string IsSelected { get; set; }
        }

        public MultiSelectObservableCollection<Vjestina> Vjestine { get; }

        public ICommand DisplayNameCommand => new Command<Vjestina>(async vjestina =>
        {
            await Application.Current.MainPage.DisplayAlert("Selected Name", vjestina.Naziv, "OK");
        });

        public ICommand FinishCommand => new Command<Vjestina>(async vjestina =>
        {
            Debug.WriteLine(Vjestine);
            Debug.WriteLine("---------- OnStart called!");
        });

        public async Task CloseInfo()
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
        public ICommand CloseInfoCommand { get { return new Command(async () => await CloseInfo()); } }
    }
}
