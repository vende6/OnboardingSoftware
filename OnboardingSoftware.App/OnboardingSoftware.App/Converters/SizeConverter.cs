using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OnboardingSoftware.App.Converters
{
    public class SizeConverter : IValueConverter
    {
       
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value==null)
            {
                return null;
            }
            
            double finalNum = 0;
            double size = System.Convert.ToDouble(value, CultureInfo.InvariantCulture);
            
            finalNum = size / (Settings.PhoneRatio);

            if (finalNum >= App.ScreenWidth)
                return App.ScreenWidth - 50;

            

            return finalNum;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
