using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnboardingSoftware.App.Views.Tests
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewStart : ContentPage
    {
        public ViewStart()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                var x = ex;
                throw;
            }
        }
    }
}