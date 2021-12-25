using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OnboardingSoftware.App.Controls
{
    public class CustomEditor : Editor
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

        //Bindable property for color of placeholder text
        public static readonly BindableProperty PlaceholderTextColorProperty =
            BindableProperty.Create("PlaceholderTextColor", typeof(Color), typeof(CustomEntry), Color.Gray);

        public Color PlaceholderTextColor
        {
            get { return (Color)GetValue(PlaceholderTextColorProperty); }
            set { SetValue(PlaceholderTextColorProperty, value); }
        }

        //Bindable property for placeholder text
        public static readonly BindableProperty PlaceholderTextProperty =
            BindableProperty.Create("PlaceholderText", typeof(string), typeof(CustomEntry), default(string));

        public string PlaceholderText
        {
            get { return (string)GetValue(PlaceholderTextProperty); }
            set { SetValue(PlaceholderTextProperty, value); }
        }
    }
}
