using Newtonsoft.Json;
using OnboardingSoftware.App.Resources;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;
using static OnboardingSoftware.App.ViewModels.InterestViewModel;

namespace OnboardingSoftware.App.ViewModels.Dialogs
{
    public class InterestDialogViewModel : BaseViewModel
    {
        public InterestDialogViewModel()
        {
            Interesi = new MultiSelectObservableCollection<InteresResource>();
            FillList();



            //InteresResource vjestina = new InteresResource();
            //vjestina.Naziv = "Communication";
            //Interesi.Add(vjestina);

            //Interesi[0].IsSelected = true;

            //vjestina = new Vjestina();
            //vjestina.Naziv = "Leadership";
            //Vjestine.Add(vjestina);

            //vjestina = new Vjestina();
            //vjestina.Naziv = "Critical-thinking";
            //Vjestine.Add(vjestina);

            //vjestina = new Vjestina();
            //vjestina.Naziv = "Problem-solving";
            //Vjestine.Add(vjestina);

            //vjestina = new Vjestina();
            //vjestina.Naziv = "Teamwork";
            //Vjestine.Add(vjestina);
        }

        public async void FillList()
        {
            IsBusy = true;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);

            try
            {

                Uri uri = new Uri("http://192.168.0.15:5001/");

                HttpResponseMessage response = await client.GetAsync(uri + "api/interesi");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var x = new ObservableCollection<InteresResource>(JsonConvert.DeserializeObject<IEnumerable<InteresResource>>(content));

                    foreach (var item in x)
                    {
                        var y = new InteresResource();
                        y.Naziv = item.Naziv;
                        //y.IsSelected = true;
                        Interesi.Add(item);
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            IsBusy = false;

        }

        private MultiSelectObservableCollection<InteresResource> _interesi;
        public MultiSelectObservableCollection<InteresResource> Interesi
        {
            get
            {
                return _interesi;
            }
            set
            {
                _interesi = value;
                OnPropertyChanged("Interesi");
            }
        }

        //public MultiSelectObservableCollection<InteresResource> Interesi { get; set; }

        public ICommand DisplayNameCommand => new Command<Interes>(async interes =>
        {
            await Application.Current.MainPage.DisplayAlert("Selected Name", interes.Naziv, "OK");
        });

        public ICommand FinishCommand => new Command<Interes>(async interes =>
        {
            Debug.WriteLine(Interesi);
            Debug.WriteLine("---------- OnStart called!");
        });

        public async Task CloseInfo()
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
        public ICommand CloseInfoCommand { get { return new Command(async () => await CloseInfo()); } }
    }
}
