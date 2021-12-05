using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnboardingSoftware.App.LanguageSupport
{ 
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return null;

            var translatedString = Translation.Translate(Text);
            if (string.IsNullOrEmpty(translatedString))
                translatedString = "MissingTranslation: " + Text;

            return translatedString;
        }
    }
    public static class Translation
    {
        /// <summary>
        /// Is this slow? Static etc should it be implemented abit different?
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Translate(string key)
        {
            if (key == null)
                return "Missing translation key!";

            var assembly = typeof(Translation).GetTypeInfo().Assembly;      
            var assemblyName = assembly.GetName();
            ResourceManager resourceManager = new ResourceManager($"{assemblyName.Name}.LanguageSupport." + Settings.LanguageId, assembly);

            string translatedString = "MissingTranslation: " + key;

            try
            {
                translatedString = resourceManager.GetString(key, CultureInfo.CurrentCulture);

                return translatedString;
            }
            catch(Exception ex)
            {
                #if !__DEBUG__
                    //Crashes.TrackError(ex);
                #endif
            }

            if (string.IsNullOrEmpty(translatedString))
                return translatedString;


            return translatedString;

        }

        
    }
}