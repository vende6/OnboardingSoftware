using Newtonsoft.Json;
using OnboardingSoftware.App.Cards.BusinessLogic;
using OnboardingSoftware.App.Resources;
using OnboardingSotware.App.Cards.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnboardingSoftware.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewJobs : ContentPage
    {
        public ViewJobs()
        {
            InitializeComponent();
            FillList();
        }

        private ObservableCollection<PosaoResource> _poslovi = new ObservableCollection<PosaoResource>();
        public ObservableCollection<PosaoResource> Poslovi
        {
            get
            {
                return _poslovi;
            }
            set
            {
                _poslovi = value;
                OnPropertyChanged("Poslovi");
            }
        }

        public async void FillList()
        {
            IsBusy = true;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", Settings.AccessToken);

            try
            {

                Uri uri = new Uri("https://onboardingsoftware.azurewebsites.net/");

                HttpResponseMessage response = await client.GetAsync(uri + "api/poslovi");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Poslovi = new ObservableCollection<PosaoResource>(JsonConvert.DeserializeObject<IEnumerable<PosaoResource>>(content));

                    //if (Settings.SelectedTestTypeId != null && Settings.SelectedTestTypeId != "0")
                    //{
                    //    Poslovi = new ObservableCollection<PosaoResource>(Poslovi.Where(x => x.Tip == Settings.SelectedTestTypeId).ToList());
                    //    Settings.SelectedTestTypeId = "0";
                    //}

                    Emplist1.ItemsSource = Poslovi;
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            IsBusy = false;

        }
    }
}