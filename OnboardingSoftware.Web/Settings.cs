using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Web
{
    public static class Settings
    {
        public static string userId = "";
        public static string jwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhZTY1MjI1Yy0yNGQ5LTQ2NjAtZjNjNS0wOGQ5YzhiZGRkODEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidGVzdCs3QGVtYWlsLmNvbSIsImp0aSI6ImI0YWI5YzljLTNmMTYtNGI0NS05M2UwLTVhMzQ4MDE2MTJmZCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiYWU2NTIyNWMtMjRkOS00NjYwLWYzYzUtMDhkOWM4YmRkZDgxIiwiZXhwIjoxNjQzMjAzMDcxLCJpc3MiOiJodHRwczovL29uYm9hcmRpbmdzb2Z0d2FyZS5henVyZXdlYnNpdGVzLm5ldCIsImF1ZCI6Imh0dHBzOi8vb25ib2FyZGluZ3NvZnR3YXJlLmF6dXJld2Vic2l0ZXMubmV0In0.kCWw9e6SaZFnwKe0jq72_QDNswrSrYwpBHv1ZPnfTe4";
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
