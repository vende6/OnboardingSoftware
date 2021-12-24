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
            new AuthenticationHeaderValue("Bearer", Settings.AccessToken);

            try
            {

                Uri uri = new Uri("http://192.168.0.15:5001/");

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