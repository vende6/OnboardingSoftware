using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Web
{
    public static class Settings
    {
        public static string userId = "";
        public static string jwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI5ZDAxMTc4ZC1lYjkxLTRhODItNDA0Ny0wOGQ5Y2MzZGFmYzciLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiZGFtaXJAb25ib2FyZGluZ3NvZnR3YXJlLmluZm8iLCJqdGkiOiJjMGE4YzE3Mi02Mzg5LTRmYTAtOWNlMS1lOTU4Zjk2ZTQzMGEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjlkMDExNzhkLWViOTEtNGE4Mi00MDQ3LTA4ZDljYzNkYWZjNyIsImV4cCI6MTY0NTk0NzI4MiwiaXNzIjoiaHR0cHM6Ly9vbmJvYXJkaW5nc29mdHdhcmUuYXp1cmV3ZWJzaXRlcy5uZXQiLCJhdWQiOiJodHRwczovL29uYm9hcmRpbmdzb2Z0d2FyZS5henVyZXdlYnNpdGVzLm5ldCJ9.9vthKOxs8dX1JBKIchi66nk3K5UaXh8krpTOMrPJDZc";
        //public static string errorMsg = "User cannot add same link multiple times. " +
        //                    "Each link - tag relation must have a value. " +
        //                    "Link must have at least one tag associated with it. ";
        public static string errorMsg = "";
        public static string errorMsgGen = "";
    }
    public class ApiEndpoint
    {
        public string AuthEndpointUrl { get; set; }
        public string AplikantiEndpointUrl { get; set; }
        public string JobsEndpointUrl { get; set; }
        public string TestsEndpointUrl { get; set; }
        public string QuestionsEndpointUrl { get; set; }
        public string AnswersEndpointUrl { get; set; }
        public string TagsEndpointUrl { get; set; }
    }
}
