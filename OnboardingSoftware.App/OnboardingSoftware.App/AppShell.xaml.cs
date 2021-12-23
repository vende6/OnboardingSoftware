using Newtonsoft.Json;
using OnboardingSoftware.App.Resources;
using OnboardingSoftware.App.ViewModels;
using OnboardingSoftware.App.Views;
using OnboardingSoftware.App.Views.Tests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OnboardingSoftware.App
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {

                throw;
            }

            MessagingCenter.Send<Xamarin.Forms.Application>(Xamarin.Forms.Application.Current, "Initialize");

           // Routing.RegisterRoute(nameof(ViewLogin), typeof(ViewLogin));
            Routing.RegisterRoute("logout", typeof(ViewLogin));
            Routing.RegisterRoute(nameof(ViewRegister), typeof(ViewRegister));
            Routing.RegisterRoute(nameof(ViewVerify), typeof(ViewVerify));
            Routing.RegisterRoute(nameof(ViewSkill), typeof(ViewSkill));
            Routing.RegisterRoute(nameof(ViewInterest), typeof(ViewInterest));
            Routing.RegisterRoute(nameof(ViewProfile), typeof(ViewProfile));

            Routing.RegisterRoute(nameof(ViewTests), typeof(ViewTests));
            Routing.RegisterRoute(nameof(ViewStart), typeof(ViewStart));
            Routing.RegisterRoute(nameof(ViewTest), typeof(ViewTest));
            Routing.RegisterRoute(nameof(ViewEnd), typeof(ViewEnd));


        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
          

            base.OnNavigated(args);
        }

        protected override async void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);
        }
    }
}
