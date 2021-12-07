using OnboardingSoftware.App.ViewModels.Tests;
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
    public partial class ViewCognitive : ContentPage
    {
        public class CarouselElement
        {
            public string Text { get; set; }
            public string Placeholder1 { get; set; }
            public string Placeholder2 { get; set; }
            public string Placeholder3 { get; set; }
            public string Value1 { get; set; }
            public string Value2 { get; set; }
            public string Value3 { get; set; }
        }

        public ViewCognitive()
        {
            InitializeComponent();
            var list = new List<CarouselElement>
            {
                new CarouselElement{Text="Provide us your contact details", Placeholder1 = "Phonenumber", Placeholder2="Home Address", Placeholder3="Faculty"},
                new CarouselElement{Text="Provide us with more details",  Placeholder1 = "Birth date", Placeholder2="Location", Placeholder3="Photo"}
            };
            TheCarousel.ItemsSource = list;
        }

    }
}