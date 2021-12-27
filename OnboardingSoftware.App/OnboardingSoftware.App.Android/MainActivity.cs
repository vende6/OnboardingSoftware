using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using FFImageLoading.Forms.Platform;
using System.Net;

namespace OnboardingSoftware.App.Droid
{
    [Activity(Label = "tob.app", Icon = "@drawable/logo", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            try
            {
                App.ScreenWidth = (Resources.DisplayMetrics.WidthPixels - 0.5f) / Resources.DisplayMetrics.Density;
                App.ScreenHeight = (Resources.DisplayMetrics.HeightPixels - 0.5f) / Resources.DisplayMetrics.Density;
                Rg.Plugins.Popup.Popup.Init(this);
                FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: true);
                global::Xamarin.Forms.Forms.SetFlags("Shell_Experimental", "Visual_Experimental", "CollectionView_Experimental", "FastRenderers_Experimental", "IndicatorView_Experimental");
                Xamarin.Essentials.Platform.Init(this, savedInstanceState);
                global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
                ServicePointManager.ServerCertificateValidationCallback += (o, cert, chain, errors) => true;
                CachedImageRenderer.Init(true);
                LoadApplication(new App());
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}