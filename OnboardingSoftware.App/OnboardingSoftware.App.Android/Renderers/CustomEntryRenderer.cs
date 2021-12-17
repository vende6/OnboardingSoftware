using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using OnboardingSoftware.App.Controls;
using OnboardingSoftware.App.Droid.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace OnboardingSoftware.App.Droid.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {

        public CustomEntryRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var view = (CustomEntry)Element;

                var _background = new GradientDrawable();

                //set shape, color
                _background.SetShape(ShapeType.Rectangle);
                _background.SetColor(view.BackgroundColor.ToAndroid());

                //stroke thickness
                _background.SetStroke(view.BorderWidth, view.BorderColor.ToAndroid());

                //set radius
                _background.SetCornerRadius(DpToPixels(this.Context, Convert.ToSingle(view.BorderRadius)));

                Control.SetBackground(_background);

                //set padding]
                if (view.LeftPadding == 1.0)
                {
                    Control.SetPadding(
                    (int)DpToPixels(this.Context, Convert.ToSingle(30)),
                    (int)DpToPixels(this.Context, Convert.ToSingle(10)),
                    (int)DpToPixels(this.Context, Convert.ToSingle(10)),
                    (int)DpToPixels(this.Context, Convert.ToSingle(7)));
                }
                else
                {
                    Control.SetPadding(
                    (int)DpToPixels(this.Context, Convert.ToSingle(view.LeftPadding)),
                    (int)DpToPixels(this.Context, Convert.ToSingle(8)),
                    (int)DpToPixels(this.Context, Convert.ToSingle(10)),
                    (int)DpToPixels(this.Context, Convert.ToSingle(7)));
                }
            }
        }

        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}