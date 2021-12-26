using Newtonsoft.Json;
using OnboardingSoftware.App.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnboardingSoftware.App.ViewModels.Tests
{
    [QueryProperty("TestID", "testId")]
    public class StartViewModel : BaseViewModel
    {
        public StartViewModel()
        {
            MessagingCenter.Subscribe<Application>(this, "InitializeStart", async (s) => await OnAppearing());
        }

        public override async Task OnAppearing()
        {
            await base.OnAppearing();
            // BindValues(_testId);

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

        public ICommand FinishCommand
        {
            get
            {
                return new Command<string>(async (route) => await FinishAsync());
            }
        }


        private async Task FinishAsync()
        {
            var x = Settings.UserId;
            var y = Convert.ToInt32(TestID);

            if (x != null | !String.IsNullOrEmpty(x))
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);

                Uri uri = new Uri("https://onboardingsoftware.azurewebsites.net/");

                SaveAplikantTestResource resource = new SaveAplikantTestResource
                { Email = x, TestID = y, OsvojeniProcenat = JsonConvert.SerializeObject(Pitanja) };

                string json = JsonConvert.SerializeObject(resource);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(uri + "api/AplikantiTestovi", content);
                Settings.TestTimerValue = "0";

                if (response.IsSuccessStatusCode)
                {
                    if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Count == 0)
                        await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Views.Dialogs.TestDialog("You completed the test", "Eventually, we will notify you on results."));
                }
                else
                {
                    if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Count == 0)
                        await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Views.Dialogs.TestDialog("Fault", "Contact support"));
                }
            }
            else
            {
                Settings.TestTimerValue = "0";
                if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Count == 0)
                    await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Views.Dialogs.TestDialog("Fault", "Contact support"));
            }
        }

        private ObservableCollection<PitanjeResource> _pitanja = new ObservableCollection<PitanjeResource>();
        public ObservableCollection<PitanjeResource> Pitanja
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

                HttpResponseMessage response = await client.GetAsync(uri + "api/pitanja/" + testId);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Pitanja = new ObservableCollection<PitanjeResource>(JsonConvert.DeserializeObject<IEnumerable<PitanjeResource>>(content));

                    foreach (var item in Pitanja)
                    {
                        if (item.Odgovori == null || item.Odgovori.Count() == 0)
                        {
                            item.Position = 1;
                        }
                        else
                        {
                            item.Odgovori = new ObservableCollection<OdgovorResource>()
                            {  new OdgovorResource {
                                PonudjeniOdgovor_1 = item.Odgovori.Last().PonudjeniOdgovor_1,
                                PonudjeniOdgovor_2 = item.Odgovori.Last().PonudjeniOdgovor_2,
                                PonudjeniOdgovor_3 = item.Odgovori.Last().PonudjeniOdgovor_3,
                                PonudjeniOdgovor_4 = item.Odgovori.Last().PonudjeniOdgovor_4,
                            TipPitanja =  item.Odgovori.Last().TipPitanja}
                            };
                        }
                    }

                    var list = Pitanja.Where(x => x.Position != 1).ToList();
                    Pitanja = new ObservableCollection<PitanjeResource>(list);

                    if (Pitanja == null || Pitanja.Count == 0)
                    {
                        await Application.Current.MainPage.DisplayAlert("Inactive", "This test is currently inactive.", "OK");
                        Application.Current.MainPage = new AppShell();
                        await Shell.Current.GoToAsync("//home/tests");
                    }

                    //int i = 0;
                    //Pitanja.Last().IsLast = true;
                    //Duration = Convert.ToDouble(Settings.TestTimerValue);

                    Device.StartTimer(TimeSpan.FromMinutes(1), TimerElapsed);

                    IsBusy = false;
                }
            }
            catch (Exception ex)
            {
                var x = ex;
                IsBusy = false;
            }
        }

        private double _duration = Convert.ToDouble(Settings.TestTimerValue);
        public double Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
                RaisePropertyChanged(() => Duration);
            }
        }

        private bool TimerElapsed()
        {
            if (Settings.TestTimerValue == "0")
                return false;

            Duration -= 1;

            if (Duration == -1)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await FinishAsync();
                });
                return false;
            }
            return true;
        }

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
