using Newtonsoft.Json;
using OnboardingSoftware.App.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnboardingSoftware.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewUpdate : ContentPage
    {
        public ViewUpdate()
        {
            InitializeComponent();
            TheCarousel1.ItemsSource = UpdateAplikantResources;

            //public string BrojTelefona { get; set; }
            //public string MjestoRodjenja { get; set; }
            //public DateTime DatumRodjenja { get; set; }
            //public string Adresa { get; set; }

            //public string Bio { get; set; }
            //public string StatusZaposlenja { get; set; }
            //public string TrenutnaPozicija { get; set; }
            //public string Industrija { get; set; }
            //BindData();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await BindData();
        }
        public async Task BindData()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", Settings.AccessToken);

            var id = Settings.UserId;
            Uri uri = new Uri("https://onboardingsoftware.azurewebsites.net/");
            HttpResponseMessage response = await client.GetAsync(uri + "api/aplikanti/" + HttpUtility.UrlEncode(id));
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                x = new AplikantResource();
                x = JsonConvert.DeserializeObject<AplikantResource>(content);
                //Aplikant = x;
               // OnPropertyChanged("Aplikant");

                UpdateAplikantResources = new ObservableCollection<UpdateAplikantResource>()
             {
           new UpdateAplikantResource {Text="Update your profile contact details ", Placeholder1 = "Phone number", Placeholder2 = "Place of birth", Placeholder3 = "Date of birth [dd.mm.yyyy]", Placeholder4 = "Place of residence", Value1 = x.BrojTelefona, Value3=Convert.ToDateTime(x.DatumRodjenja).ToString("dd.MM.yyyy"), Value2 = x.MjestoRodjenja,
               Value4 = x.Adresa, IsLast=false},
           new UpdateAplikantResource {Text="Update your profile contact details ", Placeholder1 = "Employment status", Placeholder2 = "Current enrolment",
               Placeholder3 = "About", Placeholder4 = "Education", Value1 = x.StatusZaposlenja, Value2 = x.TrenutnaPozicija, Value3 = x.Bio, Value4 = x.Industrija, IsLast=true}
        };
                TheCarousel1.ItemsSource = UpdateAplikantResources;
                OnPropertyChanged("UpdateAplikantResources");
            }
        }

        public AplikantResource _x =  new AplikantResource();
        public AplikantResource x
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
                OnPropertyChanged("x");
            }
        }

        private ObservableCollection<UpdateAplikantResource> _updateAplikantResources; //= new List<UpdateAplikantResource>()
        //     {
        //   new UpdateAplikantResource {Text="Update your profile contact details ", Placeholder1 = "Phone number", Placeholder2 = "Place of birth", Placeholder3 = "Date of birth [dd.mm.yyyy]", Placeholder4 = "Place of residence", IsLast=false},
        //   new UpdateAplikantResource {Text="Update your profile contact details ", Placeholder1 = "Employment status", Placeholder2 = "Current enrolment",
        //       Placeholder3 = "About", Placeholder4 = "Education", IsLast=true}
        //};
        public ObservableCollection<UpdateAplikantResource> UpdateAplikantResources
        {
            get
            {
                return _updateAplikantResources;
            }
            set
            {
                _updateAplikantResources = value;
                OnPropertyChanged("UpdateAplikantResources");
            }
        }

        public async Task Verify()
        {
            IsBusy = true;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                 new AuthenticationHeaderValue("Bearer", Settings.AccessToken);

            try
            {

                Uri uri = new Uri("https://onboardingsoftware.azurewebsites.net/");

                var id = Settings.UserId;
                if (!String.IsNullOrEmpty(id))
                {
                    DateTime.TryParse(UpdateAplikantResources[0].Value3, out DateTime temp);
                    AplikantVerifyResource aplikantVerifyResource = new AplikantVerifyResource
                    {
                        BrojTelefona = UpdateAplikantResources[0].Value1,
                        MjestoRodjenja = UpdateAplikantResources[0].Value2,
                        DatumRodjenja = temp,
                        Adresa = UpdateAplikantResources[0].Value4,
                        StatusZaposlenja = UpdateAplikantResources[1].Value1,
                        TrenutnaPozicija = UpdateAplikantResources[1].Value2,
                        Bio = UpdateAplikantResources[1].Value3,
                        Industrija = UpdateAplikantResources[1].Value4
                    };                    

                    string json = JsonConvert.SerializeObject(aplikantVerifyResource);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    
                    HttpResponseMessage response = await client.PutAsync(uri + "api/Aplikanti?email=" + HttpUtility.UrlEncode(id), content);
                    if (response.IsSuccessStatusCode)
                    {
                    //    //phone or/and email verification before the end of procedure
                    //    //***************
                    //    MailMessage msg = new MailMessage();
                    //    SmtpClient smtp = new SmtpClient();
                    //    string emailId = "damir@onboardingsoftware.info";//id;
                    //    msg.From = new MailAddress("damir.krkalic@edu.fit.ba");
                    //    msg.To.Add(emailId);
                    //    msg.Subject = "[Onboarding confirmation]";
                    //    //For testing replace the local host path with your lost host path and while making online replace with your website domain name
                    //    //string ActivationUrl = "http://localhost:8665/FetchUserId(emailId) & "&EmailId=" & emailId);
                    //    msg.Body = "Thanks for showing interest and registering in <a href='https://www.godaddy.com/en-uk/whatsapp'> https://onboardingsoftware.azurewebsites.net.</a> " +
                    //          " In order to complete the sign-up process, please click the confirmation link.";
                    //    msg.IsBodyHtml = true;
                    //    smtp.Credentials = new NetworkCredential("damir.krkalic@edu.fit.ba", "X38yb4k47banana");
                    //    smtp.Port = 587;//manage TFA
                    //    smtp.Host = "smtp.office365.com";
                    //    smtp.EnableSsl = true;
                    //    //NetworkCredential Credentials = new NetworkCredential("emailaddress@gmail.com", "Super2@17");
                    //    //smtp.UseDefaultCredentials = true;
                    //    smtp.Send(msg);
                    //    //******************
                    //    Settings.IsVerified = true;
                        Application.Current.MainPage = new AppShell();
                    }
                    else
                    {
                        //await Application.Current.MainPage.DisplayAlert("Fault", "We were unable to verify you.", "OK");
                        //Application.Current.MainPage = new AppShell();
                    }
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Fault", "We were unable to update your account.", "OK");
                Application.Current.MainPage = new AppShell();
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Verify();
        }


    }

}