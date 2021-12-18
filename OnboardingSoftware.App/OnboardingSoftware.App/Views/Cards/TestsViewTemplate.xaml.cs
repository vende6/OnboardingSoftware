using OnboardingSoftware.App.LanguageSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnboardingSoftware.App.Views.Cards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestsViewTemplate : ContentView
    {
        public TestsViewTemplate()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICommand TestDescriptionCommand
        {
            get
            {
                return new Command<string>(async (route) =>
                {
                    if (Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopupStack.Count == 0)
                        await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Views.Dialogs.JobDialog(Translation.Translate("LanguageTitle"), Translation.Translate("LanguageText")));
                });
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//home/login");
        }

    }
}