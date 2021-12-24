using Newtonsoft.Json;
using OnboardingSoftware.App.Resources;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
                Uri uri = new Uri("http://192.168.0.15:5001/");

                SaveAplikantPosaoResource resource = new SaveAplikantPosaoResource
                { Email = x, PosaoID = y };

                string json = JsonConvert.SerializeObject(resource);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(uri + "api/Aplikanti/SavePosao", content);

                if (response.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.DisplayAlert("Done", "Application for the job was success!", "OK");
                    await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAllAsync();
                    Application.Current.MainPage = new AppShell();
                    return;
                }

                await Application.Current.MainPage.DisplayAlert("Done", "Application for the job was unsucessful or you already applied for this position.", "OK");
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