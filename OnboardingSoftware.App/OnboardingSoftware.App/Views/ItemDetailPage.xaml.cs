using OnboardingSoftware.App.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace OnboardingSoftware.App.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}