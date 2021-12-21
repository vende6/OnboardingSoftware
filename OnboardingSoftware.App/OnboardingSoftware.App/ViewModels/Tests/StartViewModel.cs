using Newtonsoft.Json;
using OnboardingSoftware.App.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ICommand FinishCommand => new Command(async vjestina =>
        {
            await Application.Current.MainPage.DisplayAlert("Done", "Results have been archived.", "OK");
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//home/profile");
        });

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
        new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI2ZGVjNDYzNS0zY2FmLTRiYzgtMDQ1Yi0wOGQ5YzAyMjJmM2YiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiZGFtaXIxQHRvYi5iYSIsImp0aSI6ImViN2Y1NTg0LThjN2QtNDM5MC1iODUxLWE3NzA1ZWU2MDJlYSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiNmRlYzQ2MzUtM2NhZi00YmM4LTA0NWItMDhkOWMwMjIyZjNmIiwiZXhwIjoxNjQyMjI0NzQ1LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjQ0MzA4IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo0NDMwOCJ9.6xPWKMbqS9RLqjwFRt9WvSuGRYwH8zk2L3BjL-6IoeE");

                Uri uri = new Uri("https://onboardingsoftwareapi20211220211441.azurewebsites.net/");

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

                    int i = 0;
                    Pitanja.Last().IsLast = true;

                    IsBusy = false;
                }
            }    
            catch (Exception ex)
            {
                var x = ex;
                IsBusy = false;
            }
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
