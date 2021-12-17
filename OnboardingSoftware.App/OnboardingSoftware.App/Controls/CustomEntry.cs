using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OnboardingSoftware.App.Controls
{
    public class CustomEntry : Entry
    {
        //Bindable property for color of border
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create("BorderColor", typeof(Color), typeof(CustomEntry), Color.Blue);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        //Bindable property for radius of border
        public static readonly BindableProperty BorderRadiusProperty =
            BindableProperty.Create("BorderRadius", typeof(double), typeof(CustomEntry), 2.0);

        public double BorderRadius
        {
            get { return (double)GetValue(BorderRadiusProperty); }
            set { SetValue(BorderRadiusProperty, value); }
        }

        //Bindable property for border width
        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create("BorderWidth", typeof(int), typeof(CustomEntry), 1);

        public int BorderWidth
        {
            get { return (int)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        //Bindable property for radius of border
        public static readonly BindableProperty LeftPaddingProperty =
            BindableProperty.Create("LeftPadding", typeof(double), typeof(CustomEntry), 1.0);

        public double LeftPadding
        {
            get { return (double)GetValue(LeftPaddingProperty); }
            set { SetValue(LeftPaddingProperty, value); }
        }
    }
}
