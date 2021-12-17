using Newtonsoft.Json;
using OnboardingSoftware.App.Resources;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnboardingSoftware.App.ViewModels.Tests
{
    [QueryProperty("TestID", "testId")]
    public class IntegrityViewModel : BaseViewModel
    {
        public IntegrityViewModel()
        {

        }

        public override Task OnAppearing()
        {
            return base.OnAppearing();
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

        private string _naziv;
        public string Naziv
        {
            get
            {
                return _naziv;
            }
            set
            {
                _naziv = value;
                RaisePropertyChanged(() => Naziv);
            }
        }

        private string _tip;
        public string Tip
        {
            get
            {
                return _tip;
            }
            set
            {
                _tip = value;
                RaisePropertyChanged(() => Tip);
            }
        }

        private string _brojPitanja;
        public string BrojPitanja
        {
            get
            {
                return _brojPitanja;
            }
            set
            {
                _brojPitanja = value;
                RaisePropertyChanged(() => BrojPitanja);
            }
        }

        private string _trajanje;
        public string Trajanje
        {
            get
            {
                return _trajanje;
            }
            set
            {
                _trajanje = value;
                RaisePropertyChanged(() => Trajanje);
            }
        }

        private void BindValues(string testId)
        {
            IsBusy = true;

            try
            {
                //var test = await SwaggerClient.Client.TestGetByIdAsync(testId);


                Naziv = "Test";
                Tip = "Test";
                BrojPitanja = "Test";
                Trajanje = "Test";



                IsBusy = false;
            }
            catch (Exception ex)
            {
                var x = ex;
                IsBusy = false;
            }
        }

        public ICommand GetTestDataCommand
        {
            get
            {
                return new Command<string>(async (route) => await GetTestDataAsync(route));
            }
        }

        private async Task GetTestDataAsync(string route)
        {
            try
            {

                IsBusy = true;

                HttpClient client = new HttpClient();
                Uri uri = new Uri("https://3da9-77-238-220-218.ngrok.io/");


                TestResource resource = new TestResource
                { };


                string json = JsonConvert.SerializeObject(resource);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");



                //HttpResponseMessage response = null;
                // response = await client.PostAsync(uri + "api/Auth/signin", content);


                //if (response.IsSuccessStatusCode)
                //{
                //    await Shell.Current.GoToAsync(route);
                //}
                //if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                //{

                //}





                IsBusy = false;
                // await Shell.Current.GoToAsync(route);
            }
            catch (Exception ex)
            {
                //Handle it here
                IsBusy = false;
            }


        }

        private bool _isStarted;
        public bool IsStarted
        {
            get { return this._isStarted; }
            set
            {
                this._isStarted = value;
                RaisePropertyChanged(() => IsStarted);
            }
        }

        public ICommand StartCommand => new Command(async test =>
        {
            IsStarted = !IsStarted;
        });

        public ICommand FinishCommand => new Command(async vjestina =>
        {
            await Application.Current.MainPage.DisplayAlert("Done", "Results have been archived.", "OK");
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//home/profile");
        });
    }
}
