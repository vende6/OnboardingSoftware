using Newtonsoft.Json;
using OnboardingSoftware.App.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnboardingSoftware.App.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        public ShellViewModel()
        {
            MessagingCenter.Subscribe<Application>(this, "Initialize", async (s) => await OnAppearing());
        }

        private bool _canNavigate = true;
        public bool CanNavigate
        {
            get
            {
                return _canNavigate;
            }
            set
            {
                _canNavigate = value;
                RaisePropertyChanged(() => CanNavigate);
            }
        }

        public override async Task OnAppearing()
        {
            await base.OnAppearing();
            await GetTestsData();
        }

        private ObservableCollection<TestResource> _tests = new ObservableCollection<TestResource>();
        public ObservableCollection<TestResource> Tests
        {
            get
            {
                return _tests;
            }
            set
            {
                _tests = value;
                RaisePropertyChanged(() => Tests);
            }
        }


        private async Task GetTestsData()
        {

            IsBusy = true;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", Settings.AccessToken);

            Uri uri = new Uri("https://onboardingsoftware.azurewebsites.net/");

            HttpResponseMessage response = await client.GetAsync(uri + "api/testovi");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                Tests = new ObservableCollection<TestResource>(JsonConvert.DeserializeObject<List<TestResource>>(content));

            }

            IsBusy = false;
        }
    }

}
