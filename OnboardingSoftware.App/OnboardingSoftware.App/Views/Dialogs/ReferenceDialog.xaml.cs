
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
            LabelTitle.TextColor = Color.Black;
            LabelBody.TextColor = Color.Black;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //var file = await CrossFilePicker.Current.PickFile();

            //if (file != null)
            //{
            //    lbl.Text = file.FileName;
            //}
            try
            {
                var result = await FilePicker.PickAsync(PickOptions.Default);
                if (result != null)
                {
                    lbl.Text = $"File Name: {result.FileName}";
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        var stream = await result.OpenReadAsync();
                        //  Image = ImageSource.FromStream(() => stream);
                    }
                }
            }
            catch (Exception ex)
            {
                var exx = ex;
                throw;
            }
        }
    }
}