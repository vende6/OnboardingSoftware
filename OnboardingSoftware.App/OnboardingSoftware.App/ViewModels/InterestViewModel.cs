using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;

namespace OnboardingSoftware.App.ViewModels
{
    public class InterestViewModel : BaseViewModel
    {
        public class Interes
        {
            public string ID { get; set; }
            public string Naziv { get; set; }
            public string IsSelected { get; set; }
        }

        public MultiSelectObservableCollection<Interes> Interesi { get; }

        public ICommand DisplayNameCommand => new Command<Interes>(async interes =>
        {
            await Application.Current.MainPage.DisplayAlert("Selected Name", interes.Naziv, "OK");
        });

        public ICommand FinishCommand => new Command<Interes>(async interes =>
        {
            Debug.WriteLine(Interesi);
            Debug.WriteLine("---------- OnStart called!");
        });

        public InterestViewModel()
        {
            Interesi = new MultiSelectObservableCollection<Interes>();

            Interes interes = new Interes();
            interes.Naziv = "Bertuzzi1";
            Interesi.Add(interes);

            Interesi[0].IsSelected = true;

            interes = new Interes();
            interes.Naziv = "Bertuzzi2";
            Interesi.Add(interes);

            interes = new Interes();
            interes.Naziv = "Bertuzzi3";
            Interesi.Add(interes);

        }
    }
}
