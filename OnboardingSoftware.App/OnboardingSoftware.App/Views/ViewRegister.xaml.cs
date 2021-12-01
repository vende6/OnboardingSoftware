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
    public partial class ViewRegister : ContentPage
    {
        public ViewRegister()
        {
            try
            {
                InitializeComponent();
                var list = new List<string>
            {
                "Hey",
                "Did you check the",
                "The CarouselView",
                "In Xamarin.Forms?"
            };
                TheCarousel.ItemsSource = list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}