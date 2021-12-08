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
    public partial class JobDialog : PopupPage
    {
        public JobDialog(string Title, string Text)
        {
            InitializeComponent();
            LabelTitle.Text = "Back-end developer";
            LabelBody.Text = "TOB, Sarajevo, Federation of Bosnia and Herzegovina";
        }
    }
}