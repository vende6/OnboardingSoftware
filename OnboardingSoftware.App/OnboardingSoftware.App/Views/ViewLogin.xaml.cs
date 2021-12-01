using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnboardingSoftware.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewLogin : ContentPage
    {
        public ViewLogin()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}