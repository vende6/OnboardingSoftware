using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var y = LabelID.Text;
            if (x != null | !String.IsNullOrEmpty(x))
            {
                //create test aplicant
                await Application.Current.MainPage.DisplayAlert("Done", "Application for the job was success!", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Done", "Application for the job was unsucessful.", "OK");
            }

            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAllAsync();
            Application.Current.MainPage = new AppShell();
            //await Shell.Current.GoToAsync("//home/profile");
        }

        private async void Button_Clicked2(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}