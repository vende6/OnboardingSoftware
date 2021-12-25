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

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace OnboardingSoftware.App.Droid.Renderers
{
    public class CustomEditorRenderer : EditorRenderer
    {
        public CustomEditorRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var view = (CustomEditor)Element;

                var background = new GradientDrawable();

                //set shape, color
                background.SetShape(ShapeType.Rectangle);
                background.SetColor(view.BackgroundColor.ToAndroid());

                //stroke thickness
                background.SetStroke(view.BorderWidth, view.BorderColor.ToAndroid());

                //set radius
                background.SetCornerRadius(DpToPixels(this.Context, Convert.ToSingle(view.BorderRadius)));

                Control.SetBackground(background);

                //set padding
                Control.SetPadding(
                    (int)DpToPixels(this.Context, Convert.ToSingle(20)),
                    (int)DpToPixels(this.Context, Convert.ToSingle(20)),
                    (int)DpToPixels(this.Context, Convert.ToSingle(20)),
                    (int)DpToPixels(this.Context, Convert.ToSingle(20)));

                view.Placeholder = view.PlaceholderText;
                view.PlaceholderColor = view.PlaceholderTextColor;

            }
        }

        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}