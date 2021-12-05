using FFImageLoading.Work;

namespace OnboardingSoftware.App
{
    public static class GlobalSettings
    {
        public const int HttpClientTimeout = 20; 

        public const int TotalPreferencesPoints = 60;
        public const int DefaultDepartmentId = 1;
        public static double DefaultDisplaySurfaceMeasures = 2 * 683.28 + 2 * 411.28;

        public const int smallWidthResolutionAndroid = 768;
        public const int smallHeightResolutionAndroid = 1520; 
        public const int smallWidthResolutioniOS = 828;
        public const int smallHeightResolutioniOS = 1792;

        public const string MissingTemplateErrorMessage = "company_missing_active_measurement";
        public const string JwtEncodedMessage = "jwtEncodedString";

        public const string AppCenterKey_Debug = "android=caf45c87-ec86-4e87-bcb2-f9e02c48792f;" +
          "uwp={Your UWP App secret here};" +
            "ios=2ba5beb7-e9fe-4081-a730-7afa05cf050a";

        public const string AppCenterKey_Release = "android=bee48718-618c-4765-905e-1821adfb67dd;" +
            "uwp={Your UWP App secret here};" +
            "ios=04d1af2a-d662-46f9-b734-3201f1c28e10;";
    }
}
