using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Web
{
    public static class Settings
    {
        public static string userId = "";
        public static string jwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJjNjZiMDNhYy0wZTlkLTQxMjItY2YzZi0wOGQ5YzcwZWJhZmYiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidGVzdEBlbWFpbC5jb20iLCJqdGkiOiIyYzkzMjZhYi1iMjBkLTRlMjItODc0MC0yMWExNDk0ZDI0YTEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImM2NmIwM2FjLTBlOWQtNDEyMi1jZjNmLTA4ZDljNzBlYmFmZiIsImV4cCI6MTY0Mjk4NjQ0NiwiaXNzIjoiaHR0cDovLzE5Mi4xNjguMC4xNTo1MDAxIiwiYXVkIjoiaHR0cDovLzE5Mi4xNjguMC4xNTo1MDAxIn0.4W8UkOTSg5mitqV2sJu_yx2dP66AzHjQQmSMDHtT0Xg";
        //public static string errorMsg = "User cannot add same link multiple times. " +
        //                    "Each link - tag relation must have a value. " +
        //                    "Link must have at least one tag associated with it. ";
        public static string errorMsg = "";
        public static string errorMsgGen = "";
    }
    public class ApiEndpoint
    {
        public string AuthEndpointUrl { get; set; }
        public string JobsEndpointUrl { get; set; }
        public string TestsEndpointUrl { get; set; }
        public string QuestionsEndpointUrl { get; set; }
        public string AnswersEndpointUrl { get; set; }
        public string TagsEndpointUrl { get; set; }
    }
}
