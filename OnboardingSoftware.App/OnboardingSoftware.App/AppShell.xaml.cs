using OnboardingSoftware.App.ViewModels;
using OnboardingSoftware.App.Views;
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
            Routing.RegisterRoute(nameof(ViewRegister), typeof(ViewRegister));
            Routing.RegisterRoute(nameof(ViewVerify), typeof(ViewVerify));
            Routing.RegisterRoute(nameof(ViewSkill), typeof(ViewSkill));
            Routing.RegisterRoute(nameof(ViewInterest), typeof(ViewInterest));
            Routing.RegisterRoute(nameof(ViewProfile), typeof(ViewProfile));
        }

    }
}
