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
    new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI2ZGVjNDYzNS0zY2FmLTRiYzgtMDQ1Yi0wOGQ5YzAyMjJmM2YiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiZGFtaXIxQHRvYi5iYSIsImp0aSI6ImViN2Y1NTg0LThjN2QtNDM5MC1iODUxLWE3NzA1ZWU2MDJlYSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiNmRlYzQ2MzUtM2NhZi00YmM4LTA0NWItMDhkOWMwMjIyZjNmIiwiZXhwIjoxNjQyMjI0NzQ1LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjQ0MzA4IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo0NDMwOCJ9.6xPWKMbqS9RLqjwFRt9WvSuGRYwH8zk2L3BjL-6IoeE");

            Uri uri = new Uri("https://23d7-77-238-220-218.ngrok.io/");

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
