using Newtonsoft.Json;
using OnboardingSoftware.App.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnboardingSoftware.App.ViewModels.Tests
{
    [QueryProperty("TestID", "testId")]
    public class EndViewModel : BaseViewModel
    {
        public EndViewModel()
        {
          
        }

        public override async Task OnAppearing()
        {
            await base.OnAppearing();
            BindValues(_testId);

        }

        private string _testId;
        public string TestID
        {
            get
            {
                return _testId;
            }
            set
            {
                _testId = Uri.UnescapeDataString(value);
                BindValues(_testId);
            }
        }

        private string _naziv;
        public string Naziv
        {
            get
            {
                return _naziv;
            }
            set
            {
                _naziv = value;
                RaisePropertyChanged(() => Naziv);
            }
        }

        private string _tip;
        public string Tip
        {
            get
            {
                return _tip;
            }
            set
            {
                _tip = value;
                RaisePropertyChanged(() => Tip);
            }
        }

        private ObservableCollection<OdgovorResource> _ponudjeniOdgovori = new ObservableCollection<OdgovorResource>();
        public ObservableCollection<OdgovorResource> PonudjeniOdgovori
        {
            get
            {
                return _ponudjeniOdgovori;
            }
            set
            {
                _ponudjeniOdgovori = value;
                RaisePropertyChanged(() => Tip);
            }
        }

        private string _brojPitanja;
        public string BrojPitanja
        {
            get
            {
                return _brojPitanja;
            }
            set
            {
                _brojPitanja = value;
                RaisePropertyChanged(() => BrojPitanja);
            }
        }

        private string _trajanje;
        public string Trajanje
        {
            get
            {
                return _trajanje;
            }
            set
            {
                _trajanje = value;
                RaisePropertyChanged(() => Trajanje);
            }
        }

        private TestResource _test;
        public TestResource Test
        {
            get
            {
                return _test;
            }
            set
            {
                _test = value;
                RaisePropertyChanged(() => Test);
            }
        }

        private List<PitanjeResource> _pitanja;
        public List<PitanjeResource> Pitanja
        {
            get
            {
                return _pitanja;
            }
            set
            {
                _pitanja = value;
                RaisePropertyChanged(() => Pitanja);
            }
        }

        private async void BindValues(string testId)
        {
            IsBusy = true;

            try
            {
                IsBusy = true;

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", Settings.AccessToken);

                Uri uri = new Uri("https://onboardingsoftware.azurewebsites.net/");

                HttpResponseMessage response = await client.GetAsync(uri + "api/testovi/" + testId);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Test = JsonConvert.DeserializeObject<TestResource>(content);
                }

                Naziv = Test.Naziv;
                Tip = Test.Tip;
                BrojPitanja = Test.BrojPitanja;
                Trajanje = Test.Trajanje;

                //HttpResponseMessage response2 = await client.GetAsync(uri + "api/pitanja/" + testId);
                //if (response2.IsSuccessStatusCode)
                //{
                //    string content = await response2.Content.ReadAsStringAsync();
                //    Pitanja = new List<PitanjeResource>(JsonConvert.DeserializeObject<IEnumerable<PitanjeResource>>(content));
                // Pitanja.Last().IsLast = true;
                // }

                IsBusy = false;
            }
            catch (Exception ex)
            {
                var x = ex;
                IsBusy = false;
            }
        }


        private bool _isStarted = false;
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
            await Shell.Current.GoToAsync("//home/start" + "?testId=" + _testId);
        });




     
    }
}
