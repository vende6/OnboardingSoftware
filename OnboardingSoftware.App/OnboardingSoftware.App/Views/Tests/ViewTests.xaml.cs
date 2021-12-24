using Newtonsoft.Json;
using OnboardingSoftware.App.Cards.BusinessLogic;
using OnboardingSoftware.App.LanguageSupport;
using OnboardingSoftware.App.Resources;
using OnboardingSoftware.App.ViewModels;
using OnboardingSotware.App.Cards.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnboardingSoftware.App.Views.Tests
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewTests : ContentPage
    {

        private ObservableCollection<TestResource> _testovi;
        public ObservableCollection<TestResource> Testovi
        {
            get
            {
                return _testovi;
            }
            set
            {
                _testovi = value;
                OnPropertyChanged("Testovi");
            }
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
                _typeId = value;
                _typeId = Uri.UnescapeDataString(value);
               //FillList();
               // OnPropertyChanged("TypeID");
            }
        }

        public ViewTests()
        {
            InitializeComponent();
            FillList();
            MessagingCenter.Subscribe<Application>(this, "InitializeT", async (s) => FillList());

        }

        public async void FillList()
        {
            IsBusy = true;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", Settings.AccessToken);

            try
            {

                Uri uri = new Uri("http://192.168.0.15:5001/");

                HttpResponseMessage response = await client.GetAsync(uri + "api/testovi");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Testovi = new ObservableCollection<TestResource>(JsonConvert.DeserializeObject<IEnumerable<TestResource>>(content));

                    if (Settings.SelectedTestTypeId != null && Settings.SelectedTestTypeId != "0")
                    {
                        Testovi = new ObservableCollection<TestResource>(Testovi.Where(x => x.Tip == Settings.SelectedTestTypeId).ToList());
                        Settings.SelectedTestTypeId = "0";
                    }

                        Emplist2.ItemsSource = Testovi;
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            IsBusy = false;

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

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            if (this.BindingContext is BaseViewModel viewModel)
                await viewModel.OnAppearing();
        }

        protected async override void OnDisappearing()
        {
            //MessagingCenter.Send<Xamarin.Forms.Application>(Xamarin.Forms.Application.Current, "InitializeT");
            base.OnDisappearing();
            if (this.BindingContext is BaseViewModel viewModel)
                await viewModel.OnDisappearing();
        }

        
    }
}