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
            InitializeComponent();

            MessagingCenter.Send<Xamarin.Forms.Application>(Xamarin.Forms.Application.Current, "Initialize");

            Routing.RegisterRoute(nameof(ViewLogin), typeof(ViewLogin));
            Routing.RegisterRoute("logout", typeof(ViewLogin));
            Routing.RegisterRoute(nameof(ViewRegister), typeof(ViewRegister));
            Routing.RegisterRoute(nameof(ViewVerify), typeof(ViewVerify));
            Routing.RegisterRoute(nameof(ViewSkill), typeof(ViewSkill));
            Routing.RegisterRoute(nameof(ViewInterest), typeof(ViewInterest));
            Routing.RegisterRoute(nameof(ViewProfile), typeof(ViewProfile));

            Routing.RegisterRoute(nameof(ViewCognitive), typeof(ViewCognitive));
            Routing.RegisterRoute(nameof(ViewPersonality), typeof(ViewPersonality));
            Routing.RegisterRoute(nameof(ViewIntegrity), typeof(ViewIntegrity));
            Routing.RegisterRoute(nameof(ViewEmotional), typeof(ViewEmotional));

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
