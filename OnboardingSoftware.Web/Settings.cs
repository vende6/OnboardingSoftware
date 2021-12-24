using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Web
{
    public static class Settings
    {
        public static string userId = "";
        public static string jwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJjNjZiMDNhYy0wZTlkLTQxMjItY2YzZi0wOGQ5YzcwZWJhZmYiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidGVzdEBlbWFpbC5jb20iLCJqdGkiOiIwNmNmOGRiOC0wMzUyLTQ2NTQtYTJhYi1jYmIwOGVmOWE0ZmYiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImM2NmIwM2FjLTBlOWQtNDEyMi1jZjNmLTA4ZDljNzBlYmFmZiIsImV4cCI6MTY0Mjk2NDA1OSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMDgvIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMDgvIn0.lFK7mm7bI_Xlb2gaD2P3jnkh0nL2NZRrtRB49i6FEpw";
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
