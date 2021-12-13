using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSoftware.Web
{
    public static class Settings
    {
        public static string userId = "";
        public static string jwtToken = "";
        //public static string errorMsg = "User cannot add same link multiple times. " +
        //                    "Each link - tag relation must have a value. " +
        //                    "Link must have at least one tag associated with it. ";
        public static string errorMsg = "Link already exists in that tag category.";
        public static string errorMsgGen = "Selected tag category is not valid.";
    }
    public class ApiEndpoint
    {
        public string AuthEndpointUrl { get; set; }
        public string LinksEndpointUrl { get; set; }
        public string TestsEndpointUrl { get; set; }
        public string TagsEndpointUrl { get; set; }
    }
}
