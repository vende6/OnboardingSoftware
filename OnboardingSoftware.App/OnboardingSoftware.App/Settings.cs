using FFImageLoading.Work;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace OnboardingSoftware.App
{
    public static class Settings
    {
        private const string AccessTokenKey = "access_token_key";
        private static readonly string AccessTokenDefault = string.Empty;

        private const string RefreshTokenKey = "access_token_key";
        private static readonly string RefreshTokenDefault = string.Empty;

        private const string LanguageKey = "language_key";
        private static readonly string LanguageKeyDefault = "en-GB";

        private const string QuestionsLanguageKey = "questions_language_key";
        private static readonly string QuestionsLanguageKeyDefault = "en-GB";

        private const string HasUserSetLanguageKey = "has_user_set_language_key";
        private static readonly bool HasUserSetLanguageKeyDefault = false;

        private const string HasUnansweredQuestionsKey = "has_unanswered_questions_key";
        private static readonly bool HasUnansweredQuestionsKeyDefault = false;

        private const string DefaultMeasurementTemplateIdKey = "measurement_template_id_key";
        private static readonly long DefaultMeasurementTemplateIdKeyDefault = 0;

        private const string UnansweredQuestionsCategoryIdKey = "unanswered_questions_category_id_key";
        private static readonly int UnansweredQuestionsCategoryIdKeyDefault = 0;

        private const string HasAcceptedTermsKey = "hasacceptedterms_key";
        private static readonly bool HasAcceptedTermsKeyDefault = false;

        private const string FirstLoginCompletedKey = "firstlogincompleted_key";
        private static readonly bool FirstLoginCompletedKeyDefault = false;

        private const string PreferencePointsKey = "preference_points_key";
        private static readonly int PreferencePointsKeyDefault = 60;

        private const string PhoneRatioKey = "phone_ratio_key";
        private static readonly double PhoneRatioKeyDefault = 1;

        private const string UserFullnameKey = "user_fullname_key";
        private static readonly string UserFullnameKeyDefault = "";

        private const string UserUiidKey = "user_uiid_key";
        private static readonly string UserUiidKeyDefault = "";

        private const string UserImageKey = "user_image_key";
        private static readonly string UserImageKeyDefault = "";

        private const string LeaderImageKey = "leader_image_key";
        private static readonly string LeaderImageKeyDefault = "";

        private const string LeaderUserNameKey = "leader_username_key";
        private static readonly string LeaderUserNameKeyDefault = "";

        private const string LocalPreferencesKey = "localpreferences_key";
        private static readonly string LocalPreferencesDefault = string.Empty;

        public static void SetupNetworkClient()
        {
          //  Motivation.Client.SwaggerClient.SetupSwaggerClients(AccessToken, GlobalSettings.HttpClientTimeout);
        }

        public static string LeaderUserName
        {
            get
            {
                return Preferences.Get(LeaderUserNameKey, LeaderUserNameKeyDefault);
            }
            set
            {
                Preferences.Set(LeaderUserNameKey, value);
            }
        }

        public static string UserImage
        {
            get
            {
                return Preferences.Get(UserImageKey, UserImageKeyDefault);
            }
            set
            {
                Preferences.Set(UserImageKey, value);
            }
        }

        public static string LeaderImage
        {
            get
            {
                return Preferences.Get(LeaderImageKey, LeaderImageKeyDefault);
            }
            set
            {
                Preferences.Set(LeaderImageKey, value);
            }
        }


        public static string UserUIID
        {
            get
            {
                return Preferences.Get(UserUiidKey, UserUiidKeyDefault);
            }
            set
            {
                Preferences.Set(UserUiidKey, value);
            }
        }


        public static string UserFullname
        {
            get
            {
                return Preferences.Get(UserFullnameKey, UserFullnameKeyDefault);
            }
            set
            {
                Preferences.Set(UserFullnameKey, value);
            }
        }

        public static int PreferencesPointsLeftToAssign
        {
            get
            {
                return Preferences.Get(PreferencePointsKey, PreferencePointsKeyDefault);
            }
            set
            {
                Preferences.Set(PreferencePointsKey, value);
            }
        }

        public static double PhoneRatio
        {
            get
            {
                return Preferences.Get(PhoneRatioKey, PhoneRatioKeyDefault);
            }
            set
            {
                Preferences.Set(PhoneRatioKey, value);
            }
        }

        /// <summary>
        /// Use SetAccessToken to make sure the services are updated with new token if its expires etc. 
        /// Simply put, makes the setting easier to maintain with logic.
        /// </summary>
        public static string AccessToken
        {
            get
            {
                return Preferences.Get(AccessTokenKey, AccessTokenDefault);
            }
            private set
            {
                Preferences.Set(AccessTokenKey, value);
            }
        }

        public static string RefreshToken
        {
            get
            {
                var refreshToken = JwtToken.Claims.Where(x => x.Type == "refreshToken").FirstOrDefault();

                if (refreshToken == null)
                {
                    return "";
                }

                return refreshToken.Value;
            }
            set
            {
                Preferences.Set(RefreshTokenKey, value);
            }
        }

        public static bool HasUnansweredQuestions
        {
            get
            {
                return Preferences.Get(HasUnansweredQuestionsKey, HasUnansweredQuestionsKeyDefault);
            }
            set
            {
                Preferences.Set(HasUnansweredQuestionsKey, value);
            }
        }

        public static long UnansweredQuestionsCategoryId
        {
            get
            {
                return Preferences.Get(UnansweredQuestionsCategoryIdKey, UnansweredQuestionsCategoryIdKeyDefault);
            }
            set
            {
                Preferences.Set(UnansweredQuestionsCategoryIdKey, value);
            }
        }

        public static long DefaultMeasurementTemplateId
        {
            get
            {
                return Preferences.Get(DefaultMeasurementTemplateIdKey, DefaultMeasurementTemplateIdKeyDefault);
            }
            set
            {
                Preferences.Set(DefaultMeasurementTemplateIdKey, value);
            }
        }

        public static bool HasAcceptedTerms
        {
            get
            {
                var termsClaim = JwtToken.Claims.Where(x => x.Type == "acceptedTerms").FirstOrDefault();
                bool termsAccepted = false;
                bool.TryParse(termsClaim.Value, out termsAccepted);
                return termsAccepted;
            }
        }

        public static bool FirstLoginCompleted
        {
            get
            {
                return Preferences.Get(FirstLoginCompletedKey, FirstLoginCompletedKeyDefault);
            }
            set
            {
                Preferences.Set(FirstLoginCompletedKey, value);
            }
        }

        public static string LanguageId
        {
            get
            {
                return Preferences.Get(LanguageKey, LanguageKeyDefault);
            }
            set
            {
                Preferences.Set(LanguageKey, value);
            }
        }

        public static string QuestionsLanguageId
        {
            get
            {
                return Preferences.Get(QuestionsLanguageKey, QuestionsLanguageKeyDefault);
            }
            set
            {
                Preferences.Set(QuestionsLanguageKey, value);
            }
        }

        public static bool HasUserSetLanguage
        {
            get
            {
                return Preferences.Get(HasUserSetLanguageKey, HasUserSetLanguageKeyDefault);
            }
            set
            {
                Preferences.Set(HasUserSetLanguageKey, value);
            }
        }

        public static JwtSecurityToken JwtToken
        {
            get
            {
                return new JwtSecurityToken(AccessToken);
            }
        }

        public static long UserId
        {
            get
            {
                var id = JwtToken.Claims.Where(x => x.Type == "nameid").FirstOrDefault();
                long userId = 0;
                long.TryParse(id.Value, out userId);
                return userId;
            }
        }

        public static long ResponsibleUserId
        {
            get
            {
                var id = JwtToken.Claims.Where(x => x.Type == "leaderId").FirstOrDefault();
                long responsibleUserId = 0;

                if (id == null || id.Value == "")

                {
                    return UserId;
                }

                long.TryParse(id.Value, out responsibleUserId);


                return responsibleUserId;

            }
        }

        public static long CompanyId
        {
            get
            {
                var id = JwtToken.Claims.Where(x => x.Type == "companyId").FirstOrDefault();
                long companyId = 0;
                long.TryParse(id.Value, out companyId);
                return companyId;
            }
        }

        //JSON serialized.
        public static string LocalPreferencesJson
        {
            get
            {
                return Preferences.Get(LocalPreferencesKey, LocalPreferencesDefault);
            }
            set
            {
                Preferences.Set(LocalPreferencesKey, value);
            }
        }

   //     public static void AddLocalPreferences(ObservableCollection<Motivation_Result> preferences)
     //   {
          //  try
         //   {
               // ObservableCollection<Motivation_Result> existingLocalPreferences = new ObservableCollection<Motivation_Result>(preferences);

              //  Settings.LocalPreferencesJson = JsonConvert.SerializeObject(existingLocalPreferences);
          //  }
         //   catch (Exception ex)
         //   {
                //Crashes.TrackError(ex);
           // }
      //  }

      //  public static ObservableCollection<Motivation_Result> GetLocalPreferences()
     //   {
         //   try
        //    {
              //  var localPreferences = new ObservableCollection<Motivation_Result>//(JsonConvert.DeserializeObject<ObservableCollection<Motivation_Result>>(LocalPreferencesJson));

             //   return localPreferences;
       //     }
        //    catch (Exception ex)
        //    {
                //Crashes.TrackError(ex);
        //    }

        //    return null;
      //  }

        //Used to show editprofile on login.
        public static void SetFirstLoginCompleted()
        {
            FirstLoginCompleted = true;
        }

        public static void SetPhoneRatio()
        {
            PhoneRatio = GetRatioNumber();
        }

        private static double GetRatioNumber()
        {
            double volumenOfElement = 2 * App.ScreenHeight + 2 * App.ScreenWidth;
            if (GlobalSettings.DefaultDisplaySurfaceMeasures <= volumenOfElement)
                return 1;


            return GlobalSettings.DefaultDisplaySurfaceMeasures / volumenOfElement;

        }

        public static async Task SetAppLanguage()
        {
            try
            {
                //var result = await SwaggerClient.Client.ApiCompaniesCompanysettingsGetAsync(Settings.CompanyId);
                //if (result != null)
                //{
                //    if (!String.IsNullOrEmpty(result.LanguageId))
                //    {
                //        Settings.LanguageId = result.LanguageId;
                //    }

                //    if (!String.IsNullOrEmpty(result.QuestionLanguages))
                //        Settings.QuestionsLanguageId = result.QuestionLanguages;
                //}
            }
            catch (Exception ex)
            {
                //await AppShell.Current.DisplayAlert(Translation.Translate("LanguageError"), Translation.Translate("LanguageErrorMessage"), "Ok");
            }
        }


        public static void SetAccessToken(string token)
        {
            try
            {
                AccessToken = token;

                if (!String.IsNullOrEmpty(token))
                    //Motivation.Client.SwaggerClient.SetAccessToken(token);

                if (!Settings.HasUserSetLanguage && Settings.CompanyId != 0 && !String.IsNullOrEmpty(token))
                    Task.Run(() => SetAppLanguage()).Wait();
            }
            catch (Exception ex)
            {
                //Crashes.TrackError(ex);
            }
        }

        public static void Logout()
        {
            Settings.SetAccessToken("");
            FirstLoginCompleted = false;
        }

    }
}
