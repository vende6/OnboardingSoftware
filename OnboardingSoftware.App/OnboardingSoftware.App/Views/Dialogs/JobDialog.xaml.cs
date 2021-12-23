using Newtonsoft.Json;
using OnboardingSoftware.App.Resources;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static OnboardingSoftware.App.ViewModels.Dialogs.JobDialogViewModel;

namespace OnboardingSoftware.App.Views.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobDialog : PopupPage
    {
        public JobDialog(object Id, string Title, string Text)
        {
            string id = Convert.ToString(Id);
            FillList(id);
            InitializeComponent();
            LabelNaziv.TextColor = Color.Black;
            LabelLokacija.TextColor = Color.Black;
        }

        private PosaoResource _posao;
        public PosaoResource Posao
        {
            get
            {
                return _posao;
            }
            set
            {
                _posao = value;
                OnPropertyChanged("Posao");
            }
        }

        public async void FillList(string posaoId)
        {
            IsBusy = true;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI2ZGVjNDYzNS0zY2FmLTRiYzgtMDQ1Yi0wOGQ5YzAyMjJmM2YiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiZGFtaXIxQHRvYi5iYSIsImp0aSI6ImViN2Y1NTg0LThjN2QtNDM5MC1iODUxLWE3NzA1ZWU2MDJlYSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiNmRlYzQ2MzUtM2NhZi00YmM4LTA0NWItMDhkOWMwMjIyZjNmIiwiZXhwIjoxNjQyMjI0NzQ1LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjQ0MzA4IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo0NDMwOCJ9.6xPWKMbqS9RLqjwFRt9WvSuGRYwH8zk2L3BjL-6IoeE");

            try
            {

                Uri uri = new Uri("https://onboardingsoftwareapi20211220211441.azurewebsites.net/");

                HttpResponseMessage response = await client.GetAsync(uri + "api/poslovi/" + posaoId );
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Posao = JsonConvert.DeserializeObject<PosaoResource>(content);

                    LabelNaziv.Text = Posao.Naziv;
                    LabelLokacija.Text = Posao.Lokacija;
                    LabelKategorija.Text = Posao.Kategorija;
                    LabelOpis.Text = Posao.Opis;
                    LabelTip.Text = Posao.Tip;

                    //if (Settings.SelectedTestTypeId != null && Settings.SelectedTestTypeId != "0")
                    //{
                    //    Poslovi = new ObservableCollection<PosaoResource>(Poslovi.Where(x => x.Tip == Settings.SelectedTestTypeId).ToList());
                    //    Settings.SelectedTestTypeId = "0";
                    //}

                }

            }
            catch (Exception ex)
            {

                throw;
            }

            IsBusy = false;

        }

        public ICommand ApplyCommand => new Command<Posao>(async posao =>
        {
            // if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Count == 0)
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Views.Dialogs.ApplyDialog(Posao.ID.ToString(), "Apply for TOB", "In some cases, motivational letter and/or skill test completion is required"));

        });

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Views.Dialogs.ApplyDialog(Posao.ID.ToString(), "Apply for TOB", "In some cases, motivational letter and/or skill test completion is required"));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}