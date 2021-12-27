using Microsoft.AppCenter.Crashes;
using OnboardingSoftware.App;

namespace OnboardingSoftware.App
{
    public static class AppState
    {
        public static bool IsVerified => !string.IsNullOrEmpty(Settings.AccessToken) && Settings.IsVerified;
        public static bool IsAuthenticated => !string.IsNullOrEmpty(Settings.AccessToken) && !Settings.IsVerified;

    }
}
