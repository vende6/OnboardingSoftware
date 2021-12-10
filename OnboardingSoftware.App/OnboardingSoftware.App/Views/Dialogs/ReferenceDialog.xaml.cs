using Plugin.FilePicker;
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
    public partial class ReferenceDialog : PopupPage
    {
        public ReferenceDialog(string Title, string Text)
        {
            InitializeComponent();
            LabelTitle.Text = Title;
            LabelBody.Text = Text;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var file = await CrossFilePicker.Current.PickFile();

            if (file != null)
            {
                lbl.Text = file.FileName;
            }
        }
    }
}