
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

using OnboardingSoftware.App.Views;
using OnboardingSoftware.App.Views.Tests;
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

        //private static MobileServiceClient _mobileServiceClient;

        //public static MobileServiceClient MobileService
        //{
        //    get
        //    {
        //        if (_mobileServiceClient == null)
        //            _mobileServiceClient = new MobileServiceClient("https://xamarinfestquiz.azurewebsites.net");
        //        return _mobileServiceClient;
        //    }
        //}
    }

    public partial class App : Application
    {

        static public double ScreenWidth;
        static public double ScreenHeight;

        public App()
        {
            try
            {
                InitializeComponent();

                Settings.SetPhoneRatio();
                Settings.SelectedTestTypeId = "0";
                Settings.TestTimerValue = "0";
                if (!AppState.IsAuthenticated)
                    Current.MainPage = new NavigationPage(new ViewLogin());
                else
                 MainPage = new AppShell();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=eba7d888-16b0-471e-b740-532e0e1db415;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here}",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
