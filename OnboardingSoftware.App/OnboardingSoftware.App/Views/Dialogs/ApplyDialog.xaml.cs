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
    public partial class ApplyDialog : PopupPage
    {
        public ApplyDialog(string Title, string Text)
        {
            InitializeComponent();
            LabelTitle.Text = Title;
            LabelBody.Text = Text;
            LabelTitle.TextColor = Color.Black;
            LabelBody.TextColor = Color.Black;
        }
    }
}