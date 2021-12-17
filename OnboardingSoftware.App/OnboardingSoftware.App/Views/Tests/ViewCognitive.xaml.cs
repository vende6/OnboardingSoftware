using OnboardingSoftware.App.ViewModels;
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
            public bool IsLast { get; set; }
        }

        public ViewCognitive()
        {
            try
            {
                InitializeComponent();
                MessagingCenter.Send<Xamarin.Forms.Application>(Xamarin.Forms.Application.Current, "InitializeCognitive");

                var list = new List<CarouselElement>
            {
                new CarouselElement{Text="Question_01", Placeholder1 = "Phonenumber", Placeholder2="Home Address", Placeholder3="Faculty", IsLast=false},
                new CarouselElement{Text="Question_02",  Placeholder1 = "Birth date", Placeholder2="Location", Placeholder3="Photo", IsLast=true}
            };
                TheCarousel.ItemsSource = list;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (this.BindingContext is BaseViewModel viewModel)
                await viewModel.OnAppearing();
        }

        protected async override void OnDisappearing()
        {
            base.OnDisappearing();
            if (this.BindingContext is BaseViewModel viewModel)
                await viewModel.OnDisappearing();
        }

    }
}