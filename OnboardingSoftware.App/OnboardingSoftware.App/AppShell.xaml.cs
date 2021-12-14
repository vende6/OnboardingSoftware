using OnboardingSoftware.App.ViewModels;
using OnboardingSoftware.App.Views;
using OnboardingSoftware.App.Views.Tests;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace OnboardingSoftware.App
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
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

    }
}
