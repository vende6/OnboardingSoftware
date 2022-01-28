using Newtonsoft.Json;
using OnboardingSoftware.App.LanguageSupport;
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
    [QueryProperty("TypeID", "typeId")]
    public class TestsViewModel : BaseViewModel
    {
        public TestsViewModel()
        {
            MessagingCenter.Subscribe<Application>(this, "InitializeTests", async (s) => await OnAppearing());
        }

        public override async Task OnAppearing()
        {
            await base.OnAppearing();
            GetTestsData(_typeId);

        }

        private string _typeId;
        public string TypeID
        {
            get
            {
                return _typeId;
            }
            set
            {
                _typeId = Uri.UnescapeDataString(value);
                GetTestsData(_typeId);
            }
        }

        //public ICommand TestDescriptionCommand
        //{
        //    get
        //    {
        //        return new Command<string>(async (route) =>
        //        {
        //            if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Count == 0)
        //                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Views.Dialogs.JobDialog(Translation.Translate("LanguageTitle"), Translation.Translate("LanguageText")));
        //        });
        //    }
        //}

        private ObservableCollection<TestResource> _testovi = new ObservableCollection<TestResource>();
        public ObservableCollection<TestResource> Testovi
        {
            get
            {
                return _testovi;
            }
            set
            {
                _testovi = value;
                RaisePropertyChanged(() => Testovi);
            }
        }

        private async void GetTestsData(string typeId)
        {
            IsBusy = true;

            try
            {
                IsBusy = true;

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", Settings.AccessToken);

                Uri uri = new Uri("https://onboardingsoftwareapi20220128081003.azurewebsites.net/");

                HttpResponseMessage response = await client.GetAsync(uri + "api/testovi");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Testovi = new ObservableCollection<TestResource>(JsonConvert.DeserializeObject<IEnumerable<TestResource>>(content));
                   // Testovi = new ObservableCollection<TestResource>(Testovi.Where(x => x.Tip == typeId).ToList());
                }


                IsBusy = false;
            }
            catch (Exception ex)
            {
                var x = ex;
                IsBusy = false;
            }
        }
    }
}
