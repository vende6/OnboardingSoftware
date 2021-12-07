using Microsoft.WindowsAzure.MobileServices;
using OnboardingSoftware.App.Services;
using OnboardingSoftware.App.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnboardingSoftware.App
{
    public class AppSettings
    {
        public const int QUESTIONS_COUNT = 3;
        public static int CurrentQuestion = 1;
        public static int Score = 0;
        public static string Username = "";

        private static MobileServiceClient _mobileServiceClient;

        public static MobileServiceClient MobileService
        {
            get
            {
                if (_mobileServiceClient == null)
                    _mobileServiceClient = new MobileServiceClient("https://xamarinfestquiz.azurewebsites.net");
                return _mobileServiceClient;
            }
        }
    }

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
