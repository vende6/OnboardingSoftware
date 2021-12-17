    using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnboardingSoftware.App.Views.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguageDialog : PopupPage
    {

        public LanguageDialog(string Title, string Text)
        {
            try
            {
                InitializeComponent();
                LabelTitle.Text = Title;
                LabelBody.Text = Text;
                LabelTitle.TextColor = Color.Black;
                LabelBody.TextColor = Color.Black;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}