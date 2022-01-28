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

namespace OnboardingSoftware.App.Views.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApplyDialog : PopupPage
    {
        public ApplyDialog(string ID, string Title, string Text)
        {
            InitializeComponent();
            LabelID.Text = ID;
            LabelTitle.Text = Title;
            LabelBody.Text = Text;
            LabelTitle.TextColor = Color.Black;
            LabelBody.TextColor = Color.Black;
        }

        private async void Button_Clicked1(object sender, EventArgs e)
        {
            var x = Settings.UserId;
            var y = Convert.ToInt32(LabelID.Text);

            if (x != null | !String.IsNullOrEmpty(x))
            {

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);

                Uri uri = new Uri("https://onboardingsoftwareapi20220128081003.azurewebsites.net/");

                SaveAplikantPosaoResource resource = new SaveAplikantPosaoResource
                { Email = x, PosaoID = y };

                string json = JsonConvert.SerializeObject(resource);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(uri + "api/AplikantiPoslovi", content);

                if (response.IsSuccessStatusCode)
                {
                    //if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Count == 0) TODO
                    await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAllAsync();
                    await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Views.Dialogs.TestDialog("Application successful", "We will get back to you."));
                    //await Application.Current.MainPage.DisplayAlert("Application successful", "We will get back to you.", "OK");
                    //  await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAllAsync();
                    Application.Current.MainPage = new AppShell();
                    return;
                }

                //if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Count == 0) TODO
                //    await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Views.Dialogs.TestDialog("Application unsuccessful", "You already applied for this position."));
                await Application.Current.MainPage.DisplayAlert("Fault", "Application for the job was unsucessful or you already applied for this position.", "OK");
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAllAsync();
                Application.Current.MainPage = new AppShell();
            }
        }
            private async void Button_Clicked2(object sender, EventArgs e)
            {
                await PopupNavigation.Instance.PopAsync(true);
            }
        }
    }