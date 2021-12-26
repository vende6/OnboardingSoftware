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

namespace OnboardingSoftware.App.ViewModels.Dialogs
{
    public class SkillDialogViewModel : BaseViewModel
    {
        public SkillDialogViewModel()
        {
            Vjestine = new MultiSelectObservableCollection<VjestinaResource>();
            FillList();
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
                    Uri uri = new Uri("https://onboardingsoftware.azurewebsites.net/");
                    HttpResponseMessage response = await client.GetAsync(uri + "api/AplikantiVjestine?email=" + HttpUtility.UrlEncode(email));
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var z = JsonConvert.DeserializeObject<AplikantVjestineResource>(content);
                        var x = new ObservableCollection<VjestinaResource>(z.Vjestine);

                        for (int i = 0; i < x.Count; i++)
                        {
                            var y = new VjestinaResource();
                            y.Naziv = x[i].Naziv;
                            Vjestine.Add(x.ElementAt(i));
                            if (x.ElementAt(i).IsSelected)
                                Vjestine[i].IsSelected = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                var exx = ex;
                throw;
            }

            IsBusy = false;

        }

        private MultiSelectObservableCollection<VjestinaResource> _vjestine;
        public MultiSelectObservableCollection<VjestinaResource> Vjestine
        {
            get
            {
                return _vjestine;
            }
            set
            {
                _vjestine = value;
                OnPropertyChanged("Vjestine");
            }
        }

        public async Task CloseInfo()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);

                var email = Settings.UserId;
                if (!String.IsNullOrEmpty(email))
                {

                    SaveAplikantVjestineResource saveVjestinaResources = new SaveAplikantVjestineResource();
                    saveVjestinaResources.Vjestine = new List<SaveVjestinaResource>();
                    Vjestine.Where(x => x.IsSelected).ToList().ForEach(x =>
                    {
                        saveVjestinaResources.Vjestine.Add(new SaveVjestinaResource { VjestinaID = x.Data.ID });
                    });
                    saveVjestinaResources.Email = email;

                    string json = JsonConvert.SerializeObject(saveVjestinaResources);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    Uri uri = new Uri("https://onboardingsoftware.azurewebsites.net/");
                    HttpResponseMessage response = await client.PostAsync(uri + "api/AplikantiVjestine", content);
                    if (response.IsSuccessStatusCode)
                    {
                        await PopupNavigation.Instance.PopAsync(true);

                    }
                }
            }
            catch (Exception ex)
            {
                var exx = ex;
                IsBusy = false;
            }
        }

        public ICommand CloseInfoCommand { get { return new Command(async () => await PopupNavigation.Instance.PopAsync(true)); } }
        public ICommand SubmitCommand { get { return new Command(async () => await CloseInfo()); } }
    }
}
