using OnboardingSoftware.App.Services;
using OnboardingSoftware.App.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnboardingSoftware.App
{
    public partial class App : Application
    {

        static public double ScreenWidth;
        static public double ScreenHeight;

        public App()
        {
            InitializeComponent();

            Settings.SetPhoneRatio();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
