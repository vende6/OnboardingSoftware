using Newtonsoft.Json;
using OnboardingSoftware.App.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace OnboardingSoftware.App.ViewModels
{
    public class JobsViewModel : BaseViewModel
    {

        public JobsViewModel()
        {

        }

        //private ObservableCollection<PosaoResource> _poslovi = new ObservableCollection<PosaoResource>();
        //public ObservableCollection<PosaoResource> Poslovi
        //{
        //    get
        //    {
        //        return _poslovi;
        //    }
        //    set
        //    {
        //        _poslovi = value;
        //        RaisePropertyChanged(() => Poslovi);
        //    }
        //}

        //private async void GetPosloviData(string typeId)
        //{

        //    try
        //    {
        //        IsBusy = true;

        //        HttpClient client = new HttpClient();
        //        client.DefaultRequestHeaders.Authorization =
        //new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI2ZGVjNDYzNS0zY2FmLTRiYzgtMDQ1Yi0wOGQ5YzAyMjJmM2YiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiZGFtaXIxQHRvYi5iYSIsImp0aSI6ImViN2Y1NTg0LThjN2QtNDM5MC1iODUxLWE3NzA1ZWU2MDJlYSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiNmRlYzQ2MzUtM2NhZi00YmM4LTA0NWItMDhkOWMwMjIyZjNmIiwiZXhwIjoxNjQyMjI0NzQ1LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjQ0MzA4IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo0NDMwOCJ9.6xPWKMbqS9RLqjwFRt9WvSuGRYwH8zk2L3BjL-6IoeE");

        //        Uri uri = new Uri("https://onboardingsoftwareapi20211220211441.azurewebsites.net/");

        //        HttpResponseMessage response = await client.GetAsync(uri + "api/poslovi");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string content = await response.Content.ReadAsStringAsync();
        //            Poslovi = new ObservableCollection<PosaoResource>(JsonConvert.DeserializeObject<IEnumerable<PosaoResource>>(content));
        //            // Testovi = new ObservableCollection<TestResource>(Testovi.Where(x => x.Tip == typeId).ToList());
        //        }


        //        IsBusy = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        var x = ex;
        //        IsBusy = false;
        //    }
        //}

    }
}
