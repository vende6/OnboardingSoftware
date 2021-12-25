using Newtonsoft.Json;
using OnboardingSoftware.App.Resources;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
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
                var email = Settings.UserId;
                if (!String.IsNullOrEmpty(email))
                {
                    Uri uri = new Uri("http://192.168.0.15:5001/");
                    HttpResponseMessage response = await client.GetAsync(uri + "api/AplikantiInteresi?email=" + HttpUtility.UrlEncode(email));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var z = JsonConvert.DeserializeObject<AplikantInteresiResource>(content);
                        var x = new ObservableCollection<InteresResource>(z.Interesi);

                        for (int i = 0; i < x.Count; i++)
                        {
                            var y = new InteresResource();
                            y.Naziv = x[i].Naziv;
                            Interesi.Add(x.ElementAt(i));
                            if (x.ElementAt(i).IsSelected)
                                Interesi[i].IsSelected = true;
                        }
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
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);

                var email = Settings.UserId;
                if (!String.IsNullOrEmpty(email))
                {

                    SaveAplikantInteresiResource saveInteresResources = new SaveAplikantInteresiResource();
                    saveInteresResources.Interesi = new List<SaveInteresResource>();
                    Interesi.Where(x => x.IsSelected).ToList().ForEach(x =>
                    {
                        saveInteresResources.Interesi.Add(new SaveInteresResource { InteresID = x.Data.ID });
                    });
                    saveInteresResources.Email = email;

                    string json = JsonConvert.SerializeObject(saveInteresResources);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    Uri uri = new Uri("http://192.168.0.15:5001/");
                    HttpResponseMessage response = await client.PostAsync(uri + "api/AplikantiInteresi", content);
                    if (response.IsSuccessStatusCode)
                    {
                        await PopupNavigation.Instance.PopAsync(true);

                    }
                }
            }
            catch (Exception ex)
            {

                IsBusy = false;
            }
        }

        public ICommand CloseInfoCommand { get { return new Command(async () => await PopupNavigation.Instance.PopAsync(true)); } }
        public ICommand SubmitCommand { get { return new Command(async () => await CloseInfo()); } }
    }
}
