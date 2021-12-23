using Microsoft.AppCenter.Crashes;
using OnboardingSoftware.App;

namespace OnboardingSoftware.App
{
    public static class AppState
    {
        public static bool IsAuthenticated => !string.IsNullOrEmpty(Settings.AccessToken);

    }
}
