using OnboardingSoftware.App.LanguageSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OnboardingSoftware.App
{
    public static class Helper
    {

        //This method we should everywhere where we need to devide those enum factors (ex. FeedbackAndCommunication)


        public static string InsertSpaceBeforeUpperCase(string str)
        {
            var sb = new StringBuilder();

            char previousChar = char.MinValue; // Unicode '\0'

            foreach (char c in str)
            {
                if (char.IsUpper(c))
                {

                    if (sb.Length != 0 && previousChar != ' ')
                    {
                        sb.Append(' ');
                    }
                }

                sb.Append(c);

                previousChar = c;
            }

            return sb.ToString();
        }

        //public static List<string> GetTranslationFactor()
        //{
        //    var enumList = SortedList.ConvertAll(x => x.ToString()).ToList();
        //    var factorTranslation = new List<string>();
        //    foreach (var factor in enumList)
        //    {
        //        factorTranslation.Add(Translation.Translate(factor));
        //    }

        //    return factorTranslation;
        //}

        //public static List<string> GetListOfEums()
        //{
        //    return new List<string>(Enum.GetNames(typeof(TodoFactorType)).ToList());
        //}

        //public static TodoFactorType ReturnSelectedFactor(string Factor)
        //{
        //    var indexOfFactor = GetTranslationFactor().IndexOf(Factor);
        //    var listOfEnums = Helper.GetListOfEums();

        //    return (TodoFactorType)Enum.Parse(typeof(TodoFactorType), listOfEnums.ElementAt(indexOfFactor));
        //}

        public static bool IsASmallDevice()
        {
            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            // Width (in pixels)
            var width = mainDisplayInfo.Width;
            // Height (in pixels)
            var height = mainDisplayInfo.Height;

            if (Device.RuntimePlatform == Device.Android)
                return (width <= GlobalSettings.smallWidthResolutionAndroid && height <= GlobalSettings.smallHeightResolutionAndroid);

            return (width <= GlobalSettings.smallWidthResolutioniOS && height <= GlobalSettings.smallHeightResolutioniOS);

        }



        //public static List<EmployeeMotivationFactorType> SortedList = new List<EmployeeMotivationFactorType>
        //        {
        //          EmployeeMotivationFactorType.SenseOfAchievement,
        //            EmployeeMotivationFactorType.Involvement,
        //            EmployeeMotivationFactorType.FacilitationAndFlexibility,
        //            EmployeeMotivationFactorType.FeedbackAndCommunication,
        //            EmployeeMotivationFactorType.IdentityAndVision,
        //            EmployeeMotivationFactorType.SocialEnvironment,
        //            EmployeeMotivationFactorType.Development,
        //            EmployeeMotivationFactorType.Salary,
        //            EmployeeMotivationFactorType.ExtraBenefits,
        //            EmployeeMotivationFactorType.RecruitmentAndOnboarding
        //        };

        public static void PrintDebug(string text)
        {
#if __ANDROID__
            Log. with tag.
#endif

#if DEBUG

            Console.WriteLine("MOTIVATION: " + DateTime.Now.ToShortTimeString() + ": " + text);
#endif
        }
    }
}
